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
    public partial class MisCompas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                CargarCompras();
            }
        }

        private void CargarCompras()
        {

            Usuario user = (Usuario)Session["Usuario"];

            VentaNegocio negocio = new VentaNegocio();
            List<Venta> lista = negocio.ListarVentasPorCliente(user.Id);

            if (lista.Count > 0)
            {
                gvMisCompras.DataSource = lista;
                gvMisCompras.DataBind();
            }
            else
            {
                gvMisCompras.Visible = false;
                lblMensaje.Visible = true;
            }
        }
    }
}