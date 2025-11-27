using Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CategorioaNegocio
    {
        public List<Categoria> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                return datos.ListarCategorias();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
