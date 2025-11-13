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
    public partial class Componentes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProductoNegocio negocio = new ProductoNegocio();

                // ¡Cambiamos 1 (Consolas) por 4 (Hardware/Componentes)!
                List<Producto> listaProductos = negocio.ListarPorCategoria(4);

                rptProductos.DataSource = listaProductos;
                rptProductos.DataBind();
            }
        }
    }
}