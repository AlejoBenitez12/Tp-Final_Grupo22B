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
                    WHERE P.Activo = 1
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

        public Producto BuscarPorId(int id)
        {
            Producto encontrado = null; 

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
            WHERE P.Id = @id AND P.Activo = 1"; 

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    try
                    {
                        conexion.Open();
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {

                                if (encontrado == null)
                                {
                                    encontrado = new Producto();
                                    encontrado.Id = (int)lector["Id"];
                                    encontrado.Codigo = (string)lector["Codigo"];
                                    encontrado.Nombre = (string)lector["Nombre"];

                                    encontrado.Descripcion = (string)lector["Descripcion"];
                                    if (lector["Precio"] != DBNull.Value)
                                        encontrado.Precio = (decimal)lector["Precio"];
                                    encontrado.Stock = (int)lector["Stock"];


                                    if (lector["IdMarca"] != DBNull.Value)
                                        encontrado.Marca = new Marca { Id = (int)lector["IdMarca"], Descripcion = (string)lector["DescripcionMarca"] };
                                    else
                                        encontrado.Marca = new Marca { Descripcion = "Sin Marca" };

                                    if (lector["IdCategoria"] != DBNull.Value)
                                        encontrado.Categoria = new Categoria { Id = (int)lector["IdCategoria"], Descripcion = (string)lector["DescripcionCategoria"] };
                                    else
                                        encontrado.Categoria = new Categoria { Descripcion = "Sin Categoría" };
                                }


                                if (lector["ImagenUrl"] != DBNull.Value)
                                {
                                    encontrado.Imagenes.Add((string)lector["ImagenUrl"]);
                                }
                            }
                        }
                    }
                    catch (Exception ex) { throw new Exception("Error al buscar producto por ID.", ex); }
                }
            }
            return encontrado; 
        }

        public List<Producto> ListarPorCategoria(int idCategoria)
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
            WHERE P.IdCategoria = @idCategoria AND P.Activo = 1
            ORDER BY P.Id";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idCategoria", idCategoria); 
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
                                {
                                    productoActual.Imagenes.Add((string)lector["ImagenUrl"]);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al listar por categoría.", ex);
                    }
                }
            }
            lista = new List<Producto>(productosDiccionario.Values);
            return lista;
        }

        public List<Producto> ListarPorBusqueda(string termino)
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
             WHERE (P.Nombre LIKE @termino 
                OR P.Descripcion LIKE @termino 
                OR M.Descripcion LIKE @termino 
                OR C.Descripcion LIKE @termino) 
                AND P.Activo = 1  
                ORDER BY P.Id";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@termino", "%" + termino + "%");
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
                                {
                                    productoActual.Imagenes.Add((string)lector["ImagenUrl"]);
                                }
                            }
                        }
                    }
                    catch (Exception ex) { throw new Exception("Error al buscar.", ex); }
                }
            }
            lista = new List<Producto>(productosDiccionario.Values);
            return lista;
        }

        public List<Producto> ListarPorListaDeIds(List<int> listaIds)
        {
            List<Producto> lista = new List<Producto>();
            var productosDiccionario = new Dictionary<int, Producto>();

            if (listaIds == null || listaIds.Count == 0)
                return lista;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                var parametrosSql = new List<SqlParameter>();
                var listaNombresParametros = new List<string>();
                int i = 0;
                foreach (int id in listaIds)
                {
                    string paramName = "@id" + i;
                    listaNombresParametros.Add(paramName);
                    parametrosSql.Add(new SqlParameter(paramName, id));
                    i++;
                }

                string consulta = $@"
            SELECT 
                P.Id, P.Codigo, P.Nombre, P.Descripcion, P.Precio, P.Stock,
                M.Id AS IdMarca, M.Descripcion AS DescripcionMarca,
                C.Id AS IdCategoria, C.Descripcion AS DescripcionCategoria,
                I.ImagenUrl
            FROM PRODUCTOS P
            LEFT JOIN MARCAS M ON P.IdMarca = M.Id
            LEFT JOIN CATEGORIAS C ON P.IdCategoria = C.Id
            LEFT JOIN IMAGENES I ON P.Id = I.IdProducto
            WHERE P.Id IN ({string.Join(", ", listaNombresParametros)})
            AND P.Activo = 1
            ORDER BY P.Id";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddRange(parametrosSql.ToArray());
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
                                {
                                    productoActual.Imagenes.Add((string)lector["ImagenUrl"]);
                                }
                            }
                        }
                    }
                    catch (Exception ex) { throw new Exception("Error al listar por IDs.", ex); }
                }
            }
            lista = new List<Producto>(productosDiccionario.Values);
            return lista;
        }

        public void InsertarUsuario(Usuario nuevo)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string consulta = "INSERT INTO USUARIOS (Email, Password, IsAdmin) VALUES (@Email, @Password, 0)";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@Email", nuevo.Email);
                    comando.Parameters.AddWithValue("@Password", nuevo.Password);
                    try
                    {
                        conexion.Open();
                        comando.ExecuteNonQuery(); 
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al insertar usuario en la DB.", ex);
                    }
                }
            }
        }

        public Usuario Loguear(string email, string pass)
        {
            Usuario usuario = null;
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string consulta = "SELECT Id, Email, IsAdmin FROM USUARIOS WHERE Email = @email AND Password = @pass";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@email", email);
                    comando.Parameters.AddWithValue("@pass", pass);

                    try
                    {
                        conexion.Open();
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                usuario = new Usuario();
                                usuario.Id = (int)lector["Id"];
                                usuario.Email = (string)lector["Email"];
                                usuario.Password = pass;
                                usuario.IsAdmin = (bool)lector["IsAdmin"];
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al intentar loguear.", ex);
                    }
                }
            }
            return usuario;
        }

        public void GuardarVenta(Venta nuevaVenta)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                SqlTransaction transaccion = conexion.BeginTransaction();

                try
                {
                    string consultaVenta = "INSERT INTO VENTAS (IdUsuario, Total, FechaVenta, Estado) VALUES (@IdUsuario, @Total, GETDATE(), 'Pagado'); SELECT CAST(SCOPE_IDENTITY() AS INT);";

                    int idVentaGenerado;
                    using (SqlCommand cmdVenta = new SqlCommand(consultaVenta, conexion, transaccion))
                    {
                        cmdVenta.Parameters.AddWithValue("@IdUsuario", nuevaVenta.IdUsuario);
                        cmdVenta.Parameters.AddWithValue("@Total", nuevaVenta.Total);
                        idVentaGenerado = (int)cmdVenta.ExecuteScalar();
                    }

                    string consultaDetalle = "INSERT INTO DETALLE_VENTAS (IdVenta, IdProducto, Cantidad, PrecioUnitario) VALUES (@IdVenta, @IdProducto, @Cantidad, @PrecioUnitario)";
                    string consultaStock = "UPDATE PRODUCTOS SET Stock = Stock - @Cantidad WHERE Id = @IdProducto";

                    foreach (var item in nuevaVenta.Items)
                    {
                        using (SqlCommand cmdDetalle = new SqlCommand(consultaDetalle, conexion, transaccion))
                        {
                            cmdDetalle.Parameters.AddWithValue("@IdVenta", idVentaGenerado);
                            cmdDetalle.Parameters.AddWithValue("@IdProducto", item.IdProducto);
                            cmdDetalle.Parameters.AddWithValue("@Cantidad", item.Cantidad);
                            cmdDetalle.Parameters.AddWithValue("@PrecioUnitario", item.PrecioUnitario);
                            cmdDetalle.ExecuteNonQuery();
                        }

                        using (SqlCommand cmdStock = new SqlCommand(consultaStock, conexion, transaccion))
                        {
                            cmdStock.Parameters.AddWithValue("@Cantidad", item.Cantidad);
                            cmdStock.Parameters.AddWithValue("@IdProducto", item.IdProducto);
                            cmdStock.ExecuteNonQuery();
                        }
                    }

                    transaccion.Commit();
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    throw new Exception("Error al registrar la venta. Transacción cancelada.", ex);
                }
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string consulta = @"
            DELETE FROM IMAGENES WHERE IdProducto = @id;
            DELETE FROM PRODUCTOS WHERE Id = @id;";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    try
                    {
                        conexion.Open();
                        comando.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al eliminar el producto.", ex);
                    }
                }
            }
        }

        public void Agregar(Producto nuevo)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();

                string consultaProducto = "INSERT INTO PRODUCTOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio, Stock, Activo) VALUES (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @Precio, @Stock, 1); SELECT CAST(SCOPE_IDENTITY() AS INT);";

                int idProductoGenerado;

                using (SqlCommand comando = new SqlCommand(consultaProducto, conexion))
                {
                    comando.Parameters.AddWithValue("@Codigo", nuevo.Codigo);
                    comando.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
                    comando.Parameters.AddWithValue("@Descripcion", nuevo.Descripcion);
                    comando.Parameters.AddWithValue("@IdMarca", nuevo.Marca.Id);
                    comando.Parameters.AddWithValue("@IdCategoria", nuevo.Categoria.Id);
                    comando.Parameters.AddWithValue("@Precio", nuevo.Precio);
                    comando.Parameters.AddWithValue("@Stock", nuevo.Stock);

                    try
                    {
                        idProductoGenerado = (int)comando.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al insertar producto.", ex);
                    }
                }

                if (nuevo.Imagenes != null && nuevo.Imagenes.Count > 0)
                {
                    string consultaImagen = "INSERT INTO IMAGENES (IdProducto, ImagenUrl) VALUES (@IdProducto, @ImagenUrl)";
                    using (SqlCommand cmdImagen = new SqlCommand(consultaImagen, conexion))
                    {
                        cmdImagen.Parameters.AddWithValue("@IdProducto", idProductoGenerado);
                        cmdImagen.Parameters.AddWithValue("@ImagenUrl", nuevo.Imagenes[0]);
                        cmdImagen.ExecuteNonQuery();
                    }
                }
            }
        }

        public List<Producto> ListarPorMarca(int idMarca)
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
            WHERE P.IdMarca = @idMarca  -- ¡AQUÍ ESTÁ EL CAMBIO!
            AND P.Activo = 1
            ORDER BY P.Id";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idMarca", idMarca);
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
                                {
                                    productoActual.Imagenes.Add((string)lector["ImagenUrl"]);
                                }
                            }
                        }
                    }
                    catch (Exception ex) { throw new Exception("Error al listar por marca.", ex); }
                }
            }
            lista = new List<Producto>(productosDiccionario.Values);
            return lista;
        }

        public void Modificar(Producto producto)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string consulta = "UPDATE PRODUCTOS SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, Precio = @Precio, Stock = @Stock WHERE Id = @Id";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@Codigo", producto.Codigo);
                    comando.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    comando.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    comando.Parameters.AddWithValue("@IdMarca", producto.Marca.Id);
                    comando.Parameters.AddWithValue("@IdCategoria", producto.Categoria.Id);
                    comando.Parameters.AddWithValue("@Precio", producto.Precio);
                    comando.Parameters.AddWithValue("@Stock", producto.Stock);
                    comando.Parameters.AddWithValue("@Id", producto.Id); 

                    try
                    {
                        conexion.Open();
                        comando.ExecuteNonQuery();
                    }
                    catch (Exception ex) { throw new Exception("Error al modificar producto.", ex); }
                }
                if (producto.Imagenes != null && producto.Imagenes.Count > 0)
                {
                    string consultaBorrarImg = "DELETE FROM IMAGENES WHERE IdProducto = @Id";
                    string consultaInsertarImg = "INSERT INTO IMAGENES (IdProducto, ImagenUrl) VALUES (@Id, @Url)";

                    using (SqlCommand cmdBorrar = new SqlCommand(consultaBorrarImg, conexion))
                    {
                        cmdBorrar.Parameters.AddWithValue("@Id", producto.Id);
                        cmdBorrar.ExecuteNonQuery();
                    }

                    using (SqlCommand cmdInsertar = new SqlCommand(consultaInsertarImg, conexion))
                    {
                        cmdInsertar.Parameters.AddWithValue("@Id", producto.Id);
                        cmdInsertar.Parameters.AddWithValue("@Url", producto.Imagenes[0]);
                        cmdInsertar.ExecuteNonQuery();
                    }
                }
            }
        }

        public List<Categoria> ListarCategorias()
        {
            List<Categoria> lista = new List<Categoria>();
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string consulta = "SELECT Id, Descripcion FROM CATEGORIAS";
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    try
                    {
                        conexion.Open();
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                lista.Add(new Categoria
                                {
                                    Id = (int)lector["Id"],
                                    Descripcion = (string)lector["Descripcion"]
                                });
                            }
                        }
                    }
                    catch (Exception ex) { throw new Exception("Error al listar categorías.", ex); }
                }
            }
            return lista;
        }

        public List<Marca> ListarMarcas()
        {
            List<Marca> lista = new List<Marca>();
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string consulta = "SELECT Id, Descripcion FROM MARCAS";
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    try
                    {
                        conexion.Open();
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                lista.Add(new Marca
                                {
                                    Id = (int)lector["Id"],
                                    Descripcion = (string)lector["Descripcion"]
                                });
                            }
                        }
                    }
                    catch (Exception ex) { throw new Exception("Error al listar marcas.", ex); }
                }
            }
            return lista;
        }

        public bool ExisteProducto(string codigo, string nombre, int idExcluir)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string consulta = "SELECT COUNT(*) FROM PRODUCTOS WHERE (Codigo = @codigo OR Nombre = @nombre) AND Id != @idExcluir AND Activo = 1";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@codigo", codigo);
                    comando.Parameters.AddWithValue("@nombre", nombre);
                    comando.Parameters.AddWithValue("@idExcluir", idExcluir);

                    try
                    {
                        conexion.Open();
                        int cantidad = (int)comando.ExecuteScalar();
                        return cantidad > 0;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al verificar duplicados.", ex);
                    }
                }
            }
        }

        public List<Venta> ListarVentas()
        {
            List<Venta> lista = new List<Venta>();
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string consulta = @"
            SELECT V.Id, V.IdUsuario, V.FechaVenta, V.Total, V.Estado, U.Email
            FROM VENTAS V
            INNER JOIN USUARIOS U ON V.IdUsuario = U.Id
            ORDER BY V.FechaVenta DESC"; // Las más recientes primero

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    try
                    {
                        conexion.Open();
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                Venta venta = new Venta();
                                venta.Id = (int)lector["Id"];
                                venta.IdUsuario = (int)lector["IdUsuario"];
                                venta.Fecha = (DateTime)lector["FechaVenta"];
                                venta.Total = (decimal)lector["Total"];
                                venta.Estado = (string)lector["Estado"];

                                venta.EmailUsuario = (string)lector["Email"]; 

                                lista.Add(venta);
                            }
                        }
                    }
                    catch (Exception ex) { throw new Exception("Error al listar ventas.", ex); }
                }
            }
            return lista;
        }

        public Venta TraerVentaPorId(int idVenta)
        {
            Venta venta = null;
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                // 1. Traer la Cabecera
                string consultaCabecera = "SELECT V.Id, V.IdUsuario, V.FechaVenta, V.Total, V.Estado, U.Email FROM VENTAS V INNER JOIN USUARIOS U ON V.IdUsuario = U.Id WHERE V.Id = @Id";
                using (SqlCommand cmd = new SqlCommand(consultaCabecera, conexion))
                {
                    cmd.Parameters.AddWithValue("@Id", idVenta);
                    try
                    {
                        conexion.Open();
                        using (SqlDataReader lector = cmd.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                venta = new Venta();
                                venta.Id = (int)lector["Id"];
                                venta.IdUsuario = (int)lector["IdUsuario"];
                                venta.Fecha = (DateTime)lector["FechaVenta"];
                                venta.Total = (decimal)lector["Total"];
                                venta.Estado = (string)lector["Estado"];
                                venta.EmailUsuario = (string)lector["Email"]; // (Asegúrate de haber agregado esta propiedad a Venta.cs)
                            }
                        }
                    }
                    catch (Exception ex) { throw ex; }
                }

                // 2. Traer los Detalles (si encontramos la venta)
                if (venta != null)
                {
                    string consultaDetalles = @"
                SELECT D.Id, D.IdProducto, D.Cantidad, D.PrecioUnitario, P.Nombre, P.Codigo 
                FROM DETALLE_VENTAS D 
                INNER JOIN PRODUCTOS P ON D.IdProducto = P.Id 
                WHERE D.IdVenta = @IdVenta";

                    using (SqlCommand cmd = new SqlCommand(consultaDetalles, conexion))
                    {
                        cmd.Parameters.AddWithValue("@IdVenta", idVenta);
                        using (SqlDataReader lector = cmd.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                DetalleVenta detalle = new DetalleVenta();
                                detalle.Id = (int)lector["Id"];
                                detalle.IdProducto = (int)lector["IdProducto"];
                                detalle.Cantidad = (int)lector["Cantidad"];
                                detalle.PrecioUnitario = (decimal)lector["PrecioUnitario"];
                                detalle.NombreProducto = (string)lector["Nombre"]; 

                                venta.Items.Add(detalle);
                            }
                        }
                    }
                }
            }
            return venta;
        }

        public bool ExisteUsuario(string email)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string consulta = "SELECT COUNT(*) FROM USUARIOS WHERE Email = @email";
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@email", email);
                    try
                    {
                        conexion.Open();
                        int cantidad = (int)comando.ExecuteScalar();
                        return cantidad > 0;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al verificar usuario.", ex);
                    }
                }
            }
        }

    }
}
