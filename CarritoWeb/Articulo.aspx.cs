using CarritoWeb.Popup;
using Catalogo.Common;
using Catalogo.Dominio.DTO.Articulo;
using Catalogo.Dominio.DTO.Categoria;
using Catalogo.Dominio.DTO.Imagen;
using Catalogo.Dominio.DTO.Marca;
using Catalogo.Dominio.Services;
using Infraestructure.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

namespace CarritoWeb
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private MarcaServices _marcaServices;
        private CategoriaServices _categoriaServices;
        private ImagenServices _imagenServices;
        private ArticuloServices _articuloServices;
        protected void Page_Load(object sender, EventArgs e)
        {
            _marcaServices = new MarcaServices(new UnitOfWork());
            _categoriaServices = new CategoriaServices(new UnitOfWork());
            _imagenServices = new ImagenServices(new UnitOfWork());
            _articuloServices = new ArticuloServices(new UnitOfWork());
            if (!IsPostBack)
            {
                var marcas = _marcaServices.GetAll();
                var categorias = _categoriaServices.GetAll();

                ddlMarcas.Items.Insert(0, new ListItem("--Selecciona una marca--"));
                ddlCategorias.Items.Insert(0, new ListItem("--Selecciona una categoria--"));

                foreach (var marca in marcas)
                {
                    ddlMarcas.Items.Add(marca.Descripcion);
                }
                foreach(var categoria in categorias)
                {
                    ddlCategorias.Items.Add(categoria.Descripcion);
                }
                imagePreview.ImageUrl = "";

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"] : "";

                if (id != "")
                {
                    int.TryParse(id, out int idVal);
                    ArticuloDto aux = _articuloServices.GetById(idVal);

                    txtCodigo.Text = aux.Codigo;
                    txtNombre.Text = aux.Nombre;
                    txtDescripcion.Text = aux.Descripcion;
                    txtPrecio.Text = aux.Precio.ToString("0.00");
                    ddlMarcas.SelectedValue = aux.Marca;
                    ddlCategorias.SelectedValue = aux.Categoria;
                    lblTitulo.Text = "Editar Articulo";
                    foreach(var imagen in aux.Imagen)
                    {
                        ddlImagen.Items.Add(imagen);
                    }
                    if(ddlImagen.Items.Count > 0)
                    {
                        imagePreview.ImageUrl = aux.Imagen[0];
                    }
                }
                else
                {
                    lblTitulo.Text = "Agregar Articulo";
                }


            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            var userCode = txtCodigo.Text.ToLower();
            var checkExistingCode = _articuloServices.GetAll().FirstOrDefault(x => x.Codigo.ToLower() == userCode);

            lblCodigo.Text = "";
            var selectedMarca = ddlMarcas.SelectedValue.ToString().ToLower();
            var selectedCategoria = ddlCategorias.SelectedValue.ToString().ToLower();
            decimal.TryParse(txtPrecio.Text, out decimal precio);

            List<string> imagenes = new List<string>();
            foreach(ListItem item in ddlImagen.Items)
            {
                if(item.Text != "")
                    imagenes.Add(item.Text);
            }
            
            var auxArt = new ArticuloDto
            {
                Nombre = txtNombre.Text.ToString(),
                Codigo = txtCodigo.Text.ToString(),
                Descripcion = txtDescripcion.Text.ToString(),
                Precio = precio,
                
                Imagen = imagenes,
        };

            var addImagen = new AddImagenDto
            {
                ImagenUrl = imagenes
            };

            var validarMarca = ddlMarcas.SelectedIndex == 0;
            var validarCategoria = ddlCategorias.SelectedIndex == 0;

            lblMarca.Text = validarMarca ? "Debe elegir una marca" : "";
            lblCategoria.Text = validarCategoria ? "Debe elegir una categoria" : "";

            if (Validations.DataAnnotations(auxArt) && !validarMarca && !validarCategoria)
            {
                auxArt.idMarca = _marcaServices.GetAll().FirstOrDefault(x => x.Descripcion.ToLower() == selectedMarca).Id;
                auxArt.idCategoria = _categoriaServices.GetAll().FirstOrDefault(x => x.Descripcion.ToLower() == selectedCategoria).Id;

                string id = Request.QueryString["id"];
                int.TryParse(id, out int idVal);
                if (id == null)
                {
                    if (checkExistingCode != null)
                    {
                        lblCodigo.Text = "El codigo ingresado ya existe, prueba otro";
                        return;
                    }
                    _articuloServices.Insert(auxArt);
                    addImagen.IdArticulo = _articuloServices.GetIdByCodigo(auxArt.Codigo);
                    _imagenServices.Insert(addImagen);
                }
                else
                {
                    
                    auxArt.Id = idVal;
                    _articuloServices.Update(auxArt);
                    addImagen.IdArticulo = auxArt.Id;
                    _imagenServices.Insert(addImagen);

                    editarCarrito(auxArt);
                }
                Response.Redirect($"DetalleArticulo?id={idVal}");
            }
        }

        private void editarCarrito(ArticuloDto artEditado)
        {

            List<ArticuloDto> carrito = Session["Carrito"] as List<ArticuloDto>;

            if (carrito == null)
            {
                carrito = new List<ArticuloDto>();
            }

            ArticuloDto articuloAEditar = carrito.FirstOrDefault(x => x.Id == artEditado.Id);

            if (articuloAEditar != null)
            {
                artEditado.Cantidad = articuloAEditar.Cantidad;
                carrito.Remove(articuloAEditar);
                carrito.Add(artEditado);
                foreach (var item in carrito)
                {
                    item.PrecioTotal = item.Precio * Convert.ToDecimal(item.Cantidad);
                }

            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
        protected void btnGuardarModal_Click(object sender, EventArgs e)
        {
            

            if(txtMarca.Text != "")
            {
                var auxMarca = new MarcaDto
                {
                    Descripcion = txtMarca.Text
                };
                if (Validations.DataAnnotations(auxMarca))
                {
                    var marcas = _marcaServices.GetAll();

                    var checkMarcaExists = marcas.FirstOrDefault(x => x.Descripcion.ToLower().Trim() == txtMarca.Text.ToLower().Trim());

                    if(checkMarcaExists == null)
                    {
                        _marcaServices.Insert(auxMarca);
                        ddlMarcas.Items.Add(auxMarca.Descripcion);
                        ddlMarcas.DataBind();
                    }
                }
            }

            if (txtCategoria.Text != "")
            {
                var auxCategoria = new CategoriaDto
                {
                    Descripcion = txtCategoria.Text
                };
                if (Validations.DataAnnotations(auxCategoria))
                {
                    var marcas = _marcaServices.GetAll();

                    var checkMarcaExists = marcas.FirstOrDefault(x => x.Descripcion.ToLower().Trim() == txtCategoria.Text.ToLower().Trim());

                    if (checkMarcaExists == null)
                    {
                        _categoriaServices.Insert(auxCategoria);
                        ddlCategorias.Items.Add(auxCategoria.Descripcion);
                        ddlCategorias.DataBind();
                    }
                }

            }

            if(txtUrlImagen.Text != "")
            {
                ddlImagen.Items.Add(txtUrlImagen.Text);
                ddlImagen.SelectedIndex = ddlImagen.Items.Count - 1;
                imagePreview.ImageUrl = ddlImagen.Items[ddlImagen.Items.Count - 1].Text;
            }

            lblMarcaExistente.Text = "";
            lblCategoriaExistente.Text = "";

            txtCategoria.Text = "";
            txtMarca.Text = "";
            txtUrlImagen.Text = "";

        }

        protected void ddlImagen_SelectedIndexChanged(object sender, EventArgs e)
        {
            imagePreview.ImageUrl = ddlImagen.SelectedValue;
        }

        protected void btnEliminarImagen_Click(object sender, EventArgs e)
        {
            if(ddlImagen.SelectedValue != "")
                ddlImagen.Items.Remove(ddlImagen.SelectedValue);

            if (ddlImagen.Items.Count == 0)
                imagePreview.ImageUrl = "";
        }
    }
}