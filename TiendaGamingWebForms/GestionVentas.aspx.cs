using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaGamingWebForms
{
    public partial class GestionVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.EsAdmin(Session["Usuario"]))
            {
                Response.Redirect("Default.aspx");
            }

            if (!IsPostBack)
            {
                CargarVentas();
            }
        }

        private void CargarVentas()
        {
            VentaNegocio negocio = new VentaNegocio();
            gvVentas.DataSource = negocio.ListarVentas();
            gvVentas.DataBind();
        }

        protected void gvVentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ActualizarEstado")
            {
                int idVenta = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
                DropDownList ddl = (DropDownList)row.FindControl("ddlEstadoGrid");
                string nuevoEstado = ddl.SelectedValue;

                VentaNegocio negocio = new VentaNegocio();
                negocio.ActualizarEstado(idVenta, nuevoEstado);

                CargarVentas();
            }
        }
    }
}