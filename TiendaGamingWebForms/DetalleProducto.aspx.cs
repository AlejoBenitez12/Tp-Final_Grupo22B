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
    }
}