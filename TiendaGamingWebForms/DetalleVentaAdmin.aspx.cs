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
    public partial class DetalleVentaAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(id))
                {
                    VentaNegocio negocio = new VentaNegocio();
                    Venta venta = negocio.TraerVentaPorId(int.Parse(id));

                    if (venta != null)
                    {
                        Usuario user = (Usuario)Session["Usuario"];

                        if (!user.IsAdmin && venta.IdUsuario != user.Id)
                        {
                            Response.Redirect("Default.aspx");
                            return;
                        }

                        lblIdVenta.Text = venta.Id.ToString();
                        lblCliente.Text = venta.EmailUsuario;
                        lblFecha.Text = venta.Fecha.ToString("dd/MM/yyyy HH:mm");
                        lblEstado.Text = venta.Estado;
                        lblTotal.Text = venta.Total.ToString("C");

                        gvDetalle.DataSource = venta.Items;
                        gvDetalle.DataBind();
                    }
                }
            }
        }
    }
}