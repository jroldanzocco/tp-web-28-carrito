using Catalogo.Common;
using Catalogo.Dominio.DTO.Articulo;
using Catalogo.Dominio.DTO.Categoria;
using Catalogo.Dominio.DTO.Marca;
using Catalogo.Dominio.Services;
using Infraestructure.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarritoWeb
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private MarcaServices _marcaServices;
        private CategoriaServices _categoriaServices;
        private ArticuloServices _articuloServices;
        protected void Page_Load(object sender, EventArgs e)
        {
            _marcaServices = new MarcaServices(new UnitOfWork());
            _categoriaServices = new CategoriaServices(new UnitOfWork());
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

            if(checkExistingCode != null)
            {
                lblCodigo.Text = "El codigo ingresado ya existe, prueba otro";
                return;
            }
            lblCodigo.Text = "";
            var selectedMarca = ddlMarcas.SelectedValue.ToString().ToLower();
            var selectedCategoria = ddlCategorias.SelectedValue.ToString().ToLower();
            decimal.TryParse(txtPrecio.Text, out decimal precio);
            var auxArt = new ArticuloDto
            {
                Nombre = txtNombre.Text.ToString(),
                Codigo = txtCodigo.Text.ToString(),
                Descripcion = txtDescripcion.Text.ToString(),
                Precio = precio,
                idMarca = _marcaServices.GetAll().FirstOrDefault(x => x.Descripcion.ToLower() == selectedMarca).Id,
                idCategoria = _categoriaServices.GetAll().FirstOrDefault(x => x.Descripcion.ToLower() == selectedCategoria).Id,
        };
            
           



           if(Validations.DataAnnotations(auxArt))
            {
                string id = Request.QueryString["id"];
                if (id == null)
                {
                    _articuloServices.Insert(auxArt);
                }
                else
                {
                    int.TryParse(id, out int idVal);
                    auxArt.Id = idVal;
                    _articuloServices.Update(auxArt);
                }


                Response.Redirect("Home.aspx");
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

            lblMarcaExistente.Text = "";
            lblCategoriaExistente.Text = "";

            txtCategoria.Text = "";
            txtMarca.Text = "";
        }
    }
}