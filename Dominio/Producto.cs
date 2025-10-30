using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Marca Marca { get; set; }          // Objeto Marca anidado
        public Categoria Categoria { get; set; }  // Objeto Categoria anidado
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public List<string> Imagenes { get; set; } // Lista de URLs de imágenes

        // Constructor para inicializar la lista de imágenes
        public Producto()
        {
            Imagenes = new List<string>();
        }
    }
}
