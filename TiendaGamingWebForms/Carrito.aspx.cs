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
            if (!IsPostBack)
            {
                if (Session["Carrito"] != null)
                {
                    listaCarrito = (List<ItemCarrito>)Session["Carrito"];
                }
                else
                {
                    listaCarrito = new List<ItemCarrito>();
                }

                rptCarrito.DataSource = listaCarrito;
                rptCarrito.DataBind();

                decimal subtotal = 0;
                foreach (ItemCarrito item in listaCarrito)
                {
                    subtotal += item.Producto.Precio * item.Cantidad;
                }

        
                decimal envio = 15;
                decimal impuestos = subtotal * 0.10m; 
                decimal total = subtotal + envio + impuestos;

            
                litSubtotal.Text = subtotal.ToString("C"); 
                litTotal.Text = total.ToString("C");


            }
        }
    }
}