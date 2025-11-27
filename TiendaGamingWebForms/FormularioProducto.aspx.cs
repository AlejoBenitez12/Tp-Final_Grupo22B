using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaGamingWebForms
{
    public partial class FormularioProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDesplegables();

                string id = Request.QueryString["id"];

                if (!string.IsNullOrEmpty(id))
                {
                    lblTitulo.Text = "Modificar Producto";
                    btnAceptar.Text = "Modificar";

                    CargarDatosProducto(int.Parse(id));
                }
            }
        }

        private void CargarDesplegables()
        {
            try
            {
                // 1. Cargar Marcas
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                List<Marca> listaMarcas = marcaNegocio.Listar();

                ddlMarca.DataSource = listaMarcas;
                ddlMarca.DataTextField = "Descripcion"; // Lo que se ve
                ddlMarca.DataValueField = "Id";         // El valor oculto (ID)
                ddlMarca.DataBind();

                // 2. Cargar Categorías
                CategorioaNegocio categoriaNegocio = new CategorioaNegocio();
                List<Categoria> listaCategorias = categoriaNegocio.Listar();

                ddlCategoria.DataSource = listaCategorias;
                ddlCategoria.DataTextField = "Descripcion";
                ddlCategoria.DataValueField = "Id";
                ddlCategoria.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", "Error al cargar desplegables.");
                Response.Redirect("GestionProductos.aspx");
            }
        }

        private void CargarDatosProducto(int id)
        {
            try
            {
                ProductoNegocio negocio = new ProductoNegocio();
                Producto producto = negocio.BuscarPorId(id);

                if (producto != null)
                {
                    txtCodigo.Text = producto.Codigo;
                    txtNombre.Text = producto.Nombre;
                    txtDescripcion.Text = producto.Descripcion;

                    txtPrecio.Text = producto.Precio.ToString("0.00").Replace(",", ".");
                    txtStock.Text = producto.Stock.ToString();

                    ddlMarca.SelectedValue = producto.Marca.Id.ToString();
                    ddlCategoria.SelectedValue = producto.Categoria.Id.ToString();

                    if (producto.Imagenes.Count > 0)
                    {
                        txtImagenUrl.Text = producto.Imagenes[0];
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("GestionProductos.aspx");
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCodigo.Text) || string.IsNullOrEmpty(txtNombre.Text))
                {
                    lblError.Text = "El Código y el Nombre son obligatorios.";
                    lblError.Visible = true;
                    return; 
                }

                decimal precio;
                if (!decimal.TryParse(txtPrecio.Text.Replace(".", ","), out precio) || precio <= 0)
                {
                    lblError.Text = "El precio debe ser un número válido mayor a 0.";
                    lblError.Visible = true;
                    return;
                }

                int stock;
                if (!int.TryParse(txtStock.Text, out stock) || stock < 0)
                {
                    lblError.Text = "El stock debe ser un número entero no negativo.";
                    lblError.Visible = true;
                    return;
                }

                if (string.IsNullOrEmpty(txtImagenUrl.Text))
                {
                    lblError.Text = "La URL de la imagen es obligatoria.";
                    lblError.Visible = true;
                    return;
                }

                Producto producto = new Producto();
                producto.Codigo = txtCodigo.Text;
                producto.Nombre = txtNombre.Text;
                producto.Descripcion = txtDescripcion.Text;

                producto.Precio = precio;
                producto.Stock = stock;

                producto.Marca = new Marca();
                producto.Marca.Id = int.Parse(ddlMarca.SelectedValue);

                producto.Categoria = new Categoria();
                producto.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                if (!string.IsNullOrEmpty(txtImagenUrl.Text))
                    producto.Imagenes.Add(txtImagenUrl.Text);

                ProductoNegocio negocio = new ProductoNegocio();

                if (Request.QueryString["id"] != null)
                {
                    producto.Id = int.Parse(Request.QueryString["id"]);
                    negocio.Modificar(producto);
                    Session["Mensaje"] = "Producto modificado exitosamente.";
                }
                else
                {
                    negocio.Agregar(producto);
                    Session["Mensaje"] = "Producto agregado exitosamente.";
                }
                Response.Redirect("GestionProducto.aspx", false);
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al guardar: " + ex.Message;
                lblError.Visible = true;
            }
        }
    }
}

      
 