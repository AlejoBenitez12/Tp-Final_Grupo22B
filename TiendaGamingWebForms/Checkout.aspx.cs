using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
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
                decimal total = carrito.Sum(x => x.Producto.Precio * x.Cantidad);
                decimal totalFinal = total * 1.10m + 15;
                lblTotal.Text = totalFinal.ToString("C");
            }
        }

        protected void btnConfirmarCompra_Click(object sender, EventArgs e)
        {

            string tarjeta = txtTarjeta.Text.Replace(" ", ""); 
            if (!Regex.IsMatch(tarjeta, @"^\d{16}$"))
            {
                lblError.Text = "El número de tarjeta debe tener 16 dígitos numéricos.";
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
                lblError.Text = "Formato de fecha inválido. Use MM/AA (ej: 12/25).";
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

            decimal total = carrito.Sum(x => x.Producto.Precio * x.Cantidad);
            decimal totalFinal = total * 1.10m + 15;

            Venta nuevaVenta = new Venta();
            nuevaVenta.IdUsuario = user.Id;
            nuevaVenta.Total = totalFinal;
            nuevaVenta.Fecha = DateTime.Now;

            foreach (var item in carrito)
            {
                DetalleVenta detalle = new DetalleVenta();
                detalle.IdProducto = item.Producto.Id;
                detalle.Cantidad = item.Cantidad;
                detalle.PrecioUnitario = item.Producto.Precio;
                nuevaVenta.Items.Add(detalle);
            }

            VentaNegocio negocio = new VentaNegocio();
            negocio.FinalizarVenta(nuevaVenta);
        }
    }
}