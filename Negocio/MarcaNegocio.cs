using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio; 
using Datos;

namespace Negocio
{
    public class MarcaNegocio
    {
        public List<Marca> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                return datos.ListarMarcas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
