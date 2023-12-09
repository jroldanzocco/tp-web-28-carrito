using Catalogo.Dominio.DTO.Articulo;
using Catalogo.Dominio.Services;
using Infraestructure.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
                foreach(var marca in marcas)
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
            var auxArt = new ArticuloDto();

            auxArt.Nombre = txtNombre.Text.ToString();
            auxArt.Codigo = txtCodigo.Text.ToString();
            auxArt.Descripcion = txtDescripcion.Text.ToString();
            decimal.TryParse(txtPrecio.Text, out decimal precio);
            auxArt.Precio = precio;

            var context = new ValidationContext(auxArt, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(auxArt, context, results, true);

            if(!isValid)
            {
                foreach(var resultvalidation in results)
                {
                    Response.Write(resultvalidation.ErrorMessage.ToString());
                }
                return;
            }
            else
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
            


            txtCategoria.Text = "";
            txtMarca.Text = "";
        }
    }
}