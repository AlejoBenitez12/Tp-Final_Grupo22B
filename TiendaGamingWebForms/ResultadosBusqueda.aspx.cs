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
                // 1. Leemos el término de búsqueda de la URL (el "?q=...")
                string busqueda = Request.QueryString["q"];

                // 2. Mostramos el término en el <h2> (si no es nulo)
                if (!string.IsNullOrEmpty(busqueda))
                {
                    lblTerminoBuscado.Text = "\"" + busqueda + "\"";

                    ProductoNegocio negocio = new ProductoNegocio();

                    // 3. Llamamos al nuevo método de búsqueda
                    List<Producto> listaProductos = negocio.ListarPorBusqueda(busqueda);

                    // 4. Mostramos los resultados en el Repeater
                    rptProductos.DataSource = listaProductos;
                    rptProductos.DataBind();
                }
                else
                {
                    // Si no hay término de búsqueda, mostramos un mensaje
                    lblTerminoBuscado.Text = "No se especificó una búsqueda.";
                }
            }
        }
    }
}