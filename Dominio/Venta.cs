using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Venta
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }

        public string EmailUsuario { get; set; }

        // Una venta tiene una lista de items
        public List<DetalleVenta> Items { get; set; }

        public Venta()
        {
            Items = new List<DetalleVenta>();
        }
    }
}
