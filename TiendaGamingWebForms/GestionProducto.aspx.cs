using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaGamingWebForms
{
    public partial class GestionProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.EsAdmin(Session["Usuario"]))
            {
                Session.Add("error", "Se requieren permisos de administrador.");
                Response.Redirect("Default.aspx");
            }

            if (Session["Mensaje"] != null)
            {
                lblMensaje.Text = Session["Mensaje"].ToString();
                pnlMensaje.Visible = true;
                Session.Remove("Mensaje");
            }

            if (!IsPostBack)
            {
                CargarGrilla();
            }
        }

        private void CargarGrilla()
        {
            ProductoNegocio negocio = new ProductoNegocio();
            gvGestionProductos.DataSource = negocio.Listar();
            gvGestionProductos.DataBind();
        }

        protected void gvGestionProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = gvGestionProductos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioProducto.aspx?id=" + id);
        }

        protected void gvGestionProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvGestionProductos.DataKeys[e.RowIndex].Value);

            ProductoNegocio negocio = new ProductoNegocio();

            negocio.Eliminar(id);

            CargarGrilla();
        }
    }
}