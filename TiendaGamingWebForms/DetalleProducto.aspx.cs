using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaGamingWebForms
{
    public partial class DetalleProducto : System.Web.UI.Page
    {
        public Producto ProductoSeleccionado { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {           
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(id))
                {
                    ProductoNegocio negocio = new ProductoNegocio();
                    ProductoSeleccionado = negocio.BuscarPorId(Convert.ToInt32(id));

                    if (ProductoSeleccionado != null)
                    {
                        Page.DataBind();
                    }
                }
            }
        }

        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            try
            {
                string id = Request.QueryString["id"];
                if (string.IsNullOrEmpty(id))
                {
                    return;
                }

                List<ItemCarrito> listaCarrito = Session["Carrito"] as List<ItemCarrito> ?? new List<ItemCarrito>();

                int cantidad = Convert.ToInt32(ddlCantidad.SelectedValue);
                ItemCarrito itemExistente = listaCarrito.Find(item => item.Producto.Id == Convert.ToInt32(id));

                if (itemExistente != null)
                {
                    itemExistente.Cantidad += cantidad;
                }
                else
                {
                    ProductoNegocio negocio = new ProductoNegocio();
                    Producto productoAAgregar = negocio.BuscarPorId(Convert.ToInt32(id));

                    if (productoAAgregar != null)
                    {
                        ItemCarrito nuevoItem = new ItemCarrito();
                        nuevoItem.Producto = productoAAgregar;
                        nuevoItem.Cantidad = cantidad;
                        listaCarrito.Add(nuevoItem);
                    }
                }

                Session["Carrito"] = listaCarrito;

                Response.Redirect("Carrito.aspx", false);
            }
            catch (Exception ex)
            {
                Response.Redirect("Default.aspx", false);
            }
        }

    }
}