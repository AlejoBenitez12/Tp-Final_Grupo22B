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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPasswordRegistro.Text != txtConfirmarPassword.Text)
                {
                    lblError.Text = "Las contraseñas no coinciden.";
                    lblError.Visible = true;
                    return;
                }

                Usuario nuevoUsuario = new Usuario();
                nuevoUsuario.Email = txtEmailRegistro.Text;
                nuevoUsuario.Password = txtPasswordRegistro.Text;

                UsuarioNegocio negocio = new UsuarioNegocio();
                negocio.Registrar(nuevoUsuario);
                Response.Redirect("Login.aspx", false);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }
        }
    }
}