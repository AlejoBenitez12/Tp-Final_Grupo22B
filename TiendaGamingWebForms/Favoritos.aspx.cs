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
    public partial class Favoritos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx", false);
                return; 
            }

            if (!IsPostBack)
            {
                List<int> listaIds = Session["Wishlist"] as List<int>;

                if (listaIds != null && listaIds.Count > 0)
                {
                    ProductoNegocio negocio = new ProductoNegocio();
                    List<Producto> listaFavoritos = negocio.ListarPorListaDeIds(listaIds);

                    rptProductos.DataSource = listaFavoritos;
                    rptProductos.DataBind();
                }
                else
                {
                    lblMensajeVacio.Visible = true;
                }
            }
        }
    }
}