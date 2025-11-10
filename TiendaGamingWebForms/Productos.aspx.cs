using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio; 
using Dominio;

namespace TiendaGamingWebForms // Asegúrate que coincida con tu proyecto
{
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // Solo la primera vez que carga
            {
                ProductoNegocio negocio = new ProductoNegocio();
                List<Producto> listaProductos = negocio.Listar();

                rptProductos.DataSource = listaProductos; 
                rptProductos.DataBind();
            }
        }
    }
}