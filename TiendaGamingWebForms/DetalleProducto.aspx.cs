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

                List<ItemCarrito> listaCarrito;
                if (Session["Carrito"] != null)
                {
                    listaCarrito = (List<ItemCarrito>)Session["Carrito"];
                }
                else
                {
                    listaCarrito = new List<ItemCarrito>();
                }

                int cantidad = Convert.ToInt32(ddlCantidad.SelectedValue);

                ItemCarrito itemExistente = listaCarrito.Find(item => item.Producto.Id == Convert.ToInt32(id));

                if (itemExistente != null)
                {
                    itemExistente.Cantidad += cantidad;
                }
                else
                {
                    if (ProductoSeleccionado != null)
                    {
                        ItemCarrito nuevoItem = new ItemCarrito();
                        nuevoItem.Producto = ProductoSeleccionado;
                        nuevoItem.Cantidad = cantidad;
                        listaCarrito.Add(nuevoItem);
                    }
                }

                Session["Carrito"] = listaCarrito;

                Response.Redirect("Carrito.aspx");
            }
            catch (Exception ex)
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}