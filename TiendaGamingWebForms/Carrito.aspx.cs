using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace TiendaGamingWebForms
{
    public partial class Carrito : System.Web.UI.Page
    {
        public List<ItemCarrito> listaCarrito { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            listaCarrito = Session["Carrito"] as List<ItemCarrito> ?? new List<ItemCarrito>();

            if (!IsPostBack)
            {
              
                BindData();
            }
        }


        protected void rptCarrito_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
 
            int idProducto = Convert.ToInt32(e.CommandArgument);


            ItemCarrito item = listaCarrito.Find(i => i.Producto.Id == idProducto);
            if (item == null) return; 

            if (e.CommandName == "Eliminar")
            {
                listaCarrito.Remove(item);
            }
            else if (e.CommandName == "Sumar")
            {
                item.Cantidad++;
            }
            else if (e.CommandName == "Restar")
            {
                item.Cantidad--;
                if (item.Cantidad <= 0) 
                {
                    listaCarrito.Remove(item);
                }
            }

      
            Session["Carrito"] = listaCarrito;

        
            BindData();
        }


        protected void lnkVaciarCarrito_Click(object sender, EventArgs e)
        {
            Session["Carrito"] = null;
            Response.Redirect("Carrito.aspx", false);
        }


        private void BindData()
        {

            rptCarrito.DataSource = listaCarrito;
            rptCarrito.DataBind();


            decimal subtotal = listaCarrito.Sum(item => item.Producto.Precio * item.Cantidad);
            decimal envio = (subtotal > 0) ? 15.00m : 0m;
            decimal impuestos = subtotal * 0.10m;
            decimal total = subtotal + envio + impuestos;

            litSubtotal.Text = subtotal.ToString("C");
            litEnvio.Text = envio.ToString("C");  
            litImpuestos.Text = impuestos.ToString("C");
            litTotal.Text = total.ToString("C");
        }

        protected void btnProcederPago_Click(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx", false);
            }
            else
            {
                // Si SÍ está logueado, acá iría la lógica de compra (Hito 3/4).
                // Por ahora, podemos redirigir a una página de "CompraExitosa" o "Checkout".
                // Como no la tenemos, dejemos un comentario o redirijamos al Home por ahora.
                Response.Redirect("Default.aspx", false);
            }
        }
    }
}