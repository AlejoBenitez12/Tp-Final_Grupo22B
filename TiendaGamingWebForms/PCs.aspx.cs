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
    public partial class PCs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProductoNegocio negocio = new ProductoNegocio();

                List<Producto> listaProductos = negocio.ListarPorCategoria(7);

                rptProductos.DataSource = listaProductos;
                rptProductos.DataBind();
            }
        }
    }
}