using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Seguridad
    {
        public static bool EsAdmin(object user)
        {
            Usuario usuario = user != null ? (Usuario)user : null;

            return usuario != null && usuario.IsAdmin;
        }
    }
}
