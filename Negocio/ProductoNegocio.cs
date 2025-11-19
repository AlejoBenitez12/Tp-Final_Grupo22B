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

        public Producto BuscarPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                return datos.BuscarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar por ID desde Negocio.", ex);
            }
        }

        public List<Producto> ListarPorCategoria(int idCategoria)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                return datos.ListarPorCategoria(idCategoria); 
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar por categoría desde Negocio.", ex);
            }
        }

        public List<Producto> ListarPorBusqueda(string termino)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                return datos.ListarPorBusqueda(termino);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar desde Negocio.", ex);
            }
        }

        public List<Producto> ListarPorListaDeIds(List<int> listaIds)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                return datos.ListarPorListaDeIds(listaIds);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar por IDs desde Negocio.", ex);
            }
        }
    }
}
