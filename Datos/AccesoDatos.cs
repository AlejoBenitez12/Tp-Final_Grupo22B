using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class AccesoDatos
    {
        private readonly string connectionString = "server=.\\SQLEXPRESS; database=TIENDA_GAMING_DB; integrated security=true;";

        public List<Producto> ListarProductos()
        {
            List<Producto> lista = new List<Producto>();
            var productosDiccionario = new Dictionary<int, Producto>();

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string consulta = @"
                    SELECT 
                        P.Id, P.Codigo, P.Nombre, P.Descripcion, P.Precio, P.Stock,
                        M.Id AS IdMarca, M.Descripcion AS DescripcionMarca,
                        C.Id AS IdCategoria, C.Descripcion AS DescripcionCategoria,
                        I.ImagenUrl
                    FROM PRODUCTOS P
                    LEFT JOIN MARCAS M ON P.IdMarca = M.Id
                    LEFT JOIN CATEGORIAS C ON P.IdCategoria = C.Id
                    LEFT JOIN IMAGENES I ON P.Id = I.IdProducto
                    ORDER BY P.Id";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    try
                    {
                        conexion.Open();
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                int idProducto = (int)lector["Id"];
                                Producto productoActual;

                                if (!productosDiccionario.ContainsKey(idProducto))
                                {
                                    productoActual = new Producto();
                                    productoActual.Id = idProducto;
                                    productoActual.Codigo = (string)lector["Codigo"];
                                    productoActual.Nombre = (string)lector["Nombre"];
                                    productoActual.Descripcion = (string)lector["Descripcion"];
                                    if (lector["Precio"] != DBNull.Value)
                                        productoActual.Precio = (decimal)lector["Precio"];
                                    productoActual.Stock = (int)lector["Stock"];

                                    if (lector["IdMarca"] != DBNull.Value)
                                        productoActual.Marca = new Marca { Id = (int)lector["IdMarca"], Descripcion = (string)lector["DescripcionMarca"] };
                                    else
                                        productoActual.Marca = new Marca { Descripcion = "Sin Marca" };

                                    if (lector["IdCategoria"] != DBNull.Value)
                                        productoActual.Categoria = new Categoria { Id = (int)lector["IdCategoria"], Descripcion = (string)lector["DescripcionCategoria"] };
                                    else
                                        productoActual.Categoria = new Categoria { Descripcion = "Sin Categoría" };

                                    productosDiccionario.Add(idProducto, productoActual);
                                }
                                else
                                {
                                    productoActual = productosDiccionario[idProducto];
                                }

                                if (lector["ImagenUrl"] != DBNull.Value)
                                    productoActual.Imagenes.Add((string)lector["ImagenUrl"]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al leer productos.", ex);
                    }
                }
            }
            lista = new List<Producto>(productosDiccionario.Values);
            return lista;
        }
    }
}
