using Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public void Registrar(Usuario nuevo)
        {
            if (!ValidarContrasenaFuerte(nuevo.Password))
            {
                throw new Exception("La contraseña es débil. Debe tener al menos 8 caracteres, una mayúscula, una minúscula, un número y un carácter especial.");
            }

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.InsertarUsuario(nuevo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ValidarContrasenaFuerte(string password)
        {

            string patron = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}$";
            return Regex.IsMatch(password, patron);
        }

        public Usuario Loguear(string email, string pass)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                return datos.Loguear(email, pass);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
