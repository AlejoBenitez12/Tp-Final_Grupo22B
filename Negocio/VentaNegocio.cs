using Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class VentaNegocio
    {
        public void FinalizarVenta(Venta venta)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.GuardarVenta(venta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Venta> ListarVentas()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                return datos.ListarVentas();
            }
            catch (Exception ex) { throw ex; }
        }

        public Venta TraerVentaPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                return datos.TraerVentaPorId(id);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
