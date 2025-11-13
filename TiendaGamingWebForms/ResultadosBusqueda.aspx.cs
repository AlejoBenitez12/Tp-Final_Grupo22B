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
    public partial class ResultadosBusqueda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string busqueda = Request.QueryString["q"];

                if (!string.IsNullOrEmpty(busqueda))
                {
                    lblTerminoBuscado.Text = "\"" + busqueda + "\"";

                    ProductoNegocio negocio = new ProductoNegocio();

                    List<Producto> listaProductos = negocio.ListarPorBusqueda(busqueda);

                    rptProductos.DataSource = listaProductos;
                    rptProductos.DataBind();
                }
                else
                {
                    lblTerminoBuscado.Text = "No se especificó una búsqueda.";
                }
            }
        }
    }
}