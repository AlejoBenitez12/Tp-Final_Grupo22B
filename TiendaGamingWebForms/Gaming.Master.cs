using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaGamingWebForms
{
    public partial class Gaming : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string terminoBuscado = txtBuscar.Text;

            if (!string.IsNullOrEmpty(terminoBuscado))
            {
                Response.Redirect("~/ResultadosBusqueda.aspx?q=" + terminoBuscado);
            }
        }
    }
}