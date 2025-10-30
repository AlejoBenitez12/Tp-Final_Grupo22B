using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Datos;

namespace Negocio
{
    public class ProductoNegocio
    {
        public List<Producto> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                return datos.ListarProductos(); 
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar productos desde Negocio.", ex);
            }
        }
    }
}
