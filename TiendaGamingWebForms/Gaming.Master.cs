using Dominio;
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
        private const string cssBaseIcono = "flex max-w-[480px] cursor-pointer items-center justify-center overflow-hidden rounded-lg h-10 transition-colors gap-2 text-sm font-bold leading-normal tracking-[0.015em] min-w-0 px-2.5";
        private const string cssIconoInactivo = "bg-white/5 text-white/80 hover:text-white hover:bg-white/10";
        private const string cssIconoActivo = "bg-primary text-white hover:bg-primary/90";

        protected void Page_Load(object sender, EventArgs e)
        {
            List<ItemCarrito> listaCarrito = Session["Carrito"] as List<ItemCarrito>;
            if (listaCarrito != null && listaCarrito.Count > 0)
                lnkCarritoIcono.CssClass = cssBaseIcono + " " + cssIconoActivo;
            else
                lnkCarritoIcono.CssClass = cssBaseIcono + " " + cssIconoInactivo;
            List<int> listaDeseos = Session["Wishlist"] as List<int>;
            if (listaDeseos != null && listaDeseos.Count > 0)
                lnkFavoritosIcono.CssClass = cssBaseIcono + " " + cssIconoActivo;
            else
                lnkFavoritosIcono.CssClass = cssBaseIcono + " " + cssIconoInactivo;

            if (Session["Usuario"] != null)
            {
                Usuario user = (Usuario)Session["Usuario"];
                string nombreMostrar = user.Email.Split('@')[0];

                lnkLogin.Text = "<span class='material-symbols-outlined text-xl'>person</span> <span>" + nombreMostrar + "</span>";
                lnkLogin.NavigateUrl = "#";
                btnSalir.Visible = true;
                lnkMisCompras.Visible = true;

                if (user.IsAdmin)
                {


                    lnkAdmin.Visible = true;
                    lnkAdminVentas.Visible = true;
                }
                else
                {
                    lnkAdmin.Visible = false;
                    lnkAdminVentas.Visible = false;
                }
            }
            else
            {
                lnkLogin.Text = "<span class='material-symbols-outlined text-xl'>person</span> <span>Ingresá</span>";
                lnkLogin.NavigateUrl = "~/Login.aspx";
                btnSalir.Visible = false;
                lnkAdmin.Visible = false;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string terminoBuscado = txtBuscar.Text;
            if (!string.IsNullOrEmpty(terminoBuscado))
            {
                Response.Redirect("~/ResultadosBusqueda.aspx?q=" + terminoBuscado);
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
    }
}