using System;
using System.Collections.Generic;
using System.Linq;
using Dominio;
using Negocio;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaGamingWebForms
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            List<ItemCarrito> carrito = Session["Carrito"] as List<ItemCarrito>;
            if (carrito == null || carrito.Count == 0)
            {
                Response.Redirect("Productos.aspx");
                return;
            }

            if (!IsPostBack)
            {
                ActualizarTotal();
            }
        }

        protected void ddlEnvio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEnvio.SelectedValue == "Envio")
                pnlDireccion.Visible = true;
            else
                pnlDireccion.Visible = false;

            ActualizarTotal();
        }


        protected void ddlPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPago.SelectedValue == "Tarjeta")
                pnlTarjeta.Visible = true;
            else
                pnlTarjeta.Visible = false;
        }

        private void ActualizarTotal()
        {
            List<ItemCarrito> carrito = (List<ItemCarrito>)Session["Carrito"];
            decimal subtotal = carrito.Sum(x => x.Producto.Precio * x.Cantidad);

            decimal costoEnvio = (ddlEnvio.SelectedValue == "Envio") ? 15.00m : 0m;

            decimal impuestos = subtotal * 0.10m;

            decimal totalFinal = subtotal + impuestos + costoEnvio;
            lblTotal.Text = totalFinal.ToString("C");
        }

        protected void btnConfirmarCompra_Click(object sender, EventArgs e)
        {
            if (ddlEnvio.SelectedValue == "Envio")
            {
                if (string.IsNullOrEmpty(txtCalle.Text) || string.IsNullOrEmpty(txtCP.Text))
                {
                    lblError.Text = "Debe completar la dirección y código postal.";
                    lblError.Visible = true;
                    return;
                }
                if (!Regex.IsMatch(txtCP.Text, @"^\d{4}$"))
                {
                    lblError.Text = "El código postal debe tener 4 números.";
                    lblError.Visible = true;
                    return;
                }
            }

            if (ddlPago.SelectedValue == "Tarjeta")
            {
                string tarjeta = txtTarjeta.Text.Replace(" ", "");
                if (!Regex.IsMatch(tarjeta, @"^\d{16}$"))
                {
                    lblError.Text = "El número de tarjeta debe tener 16 dígitos.";
                    lblError.Visible = true;
                    return;
                }
                if (!Regex.IsMatch(txtCVV.Text, @"^\d{3}$"))
                {
                    lblError.Text = "El código de seguridad debe tener 3 dígitos.";
                    lblError.Visible = true;
                    return;
                }
                if (!ValidarFechaVencimiento(txtVencimiento.Text))
                {
                    lblError.Visible = true;
                    return;
                }
            }

            try
            {
                GuardarCompraEnBaseDeDatos();

                Session["Carrito"] = null;
                Response.Redirect("Exito.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = "Hubo un error al procesar el pago. Intente nuevamente.";
                lblError.Visible = true;
            }
        }

        private bool ValidarFechaVencimiento(string fecha)
        {
            if (!Regex.IsMatch(fecha, @"^(0[1-9]|1[0-2])\/\d{2}$"))
            {
                lblError.Text = "Formato de fecha inválido. Use MM/AA.";
                return false;
            }
            string[] partes = fecha.Split('/');
            int mes = int.Parse(partes[0]);
            int anio = int.Parse("20" + partes[1]);

            DateTime fechaVencimiento = new DateTime(anio, mes, 1).AddMonths(1).AddDays(-1);

            if (fechaVencimiento < DateTime.Now)
            {
                lblError.Text = "La tarjeta está vencida.";
                return false;
            }
            return true;
        }

        private void GuardarCompraEnBaseDeDatos()
        {
            Usuario user = (Usuario)Session["Usuario"];
            List<ItemCarrito> carrito = (List<ItemCarrito>)Session["Carrito"];

            decimal subtotal = carrito.Sum(x => x.Producto.Precio * x.Cantidad);
            decimal costoEnvio = (ddlEnvio.SelectedValue == "Envio") ? 15.00m : 0m;
            decimal totalFinal = subtotal + (subtotal * 0.10m) + costoEnvio;

            Venta nuevaVenta = new Venta();
            nuevaVenta.IdUsuario = user.Id;
            nuevaVenta.Total = totalFinal;
            nuevaVenta.Fecha = DateTime.Now;

            nuevaVenta.FormaPago = ddlPago.SelectedValue;
            nuevaVenta.TipoEnvio = ddlEnvio.SelectedValue;

            if (ddlEnvio.SelectedValue == "Envio")
                nuevaVenta.DireccionEnvio = $"{ddlProvincia.SelectedValue}, {txtCalle.Text}, CP: {txtCP.Text}";
            else
                nuevaVenta.DireccionEnvio = "Retiro en Local";


            foreach (var item in carrito)
            {
                DetalleVenta detalle = new DetalleVenta();
                detalle.IdProducto = item.Producto.Id;
                detalle.NombreProducto = item.Producto.Nombre;
                detalle.Cantidad = item.Cantidad;
                detalle.PrecioUnitario = item.Producto.Precio;
                nuevaVenta.Items.Add(detalle);
            }

            VentaNegocio negocio = new VentaNegocio();
            negocio.FinalizarVenta(nuevaVenta);

            try
            {
                EmailService emailService = new EmailService();
                emailService.EnviarConfirmacionCompra(nuevaVenta, user.Email);
            }
            catch (Exception ex) { }
        }
    }
}