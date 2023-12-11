using Catalogo.Common;
using Catalogo.Dominio.DTO.Articulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarritoWeb
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                List<ArticuloDto> artCarrito = Session["Carrito"] as List<ArticuloDto>;

                if(artCarrito != null)
                {
                    repCarrito.DataSource = artCarrito;
                    repCarrito.DataBind();
                    
                    if(artCarrito.Count > 0)
                    {
                        decimal precioTotal = artCarrito.Sum(x => x.Precio);
                        lblPrecioTotal.Text = $"${precioTotal.ToString("0.00")}";
                    }

                }
                else
                {
                    lblPrecioTotal.Text = "$0.00";
                }
            }
        }

        protected string GetFirstImageUrl(object dataItem)
        {
            // Asumiendo que tu objeto de datos tiene una propiedad "ListaImagenes" que es una lista de URL
            var listaImagenes = DataBinder.Eval(dataItem, "Imagen") as List<string>;

            // Asegurarse de que la lista no sea nula y tenga al menos una imagen
            if (listaImagenes != null && listaImagenes.Count > 0)
            {
                // Devolver la URL de la primera imagen
                return listaImagenes[0];
            }

            // Devolver una URL predeterminada o en blanco según tus necesidades
            return DefaultImage.ImagePath;
        }

        protected void btnLimpiarCarrito_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminarArticulo_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string articuloId = btn.CommandArgument;
            int.TryParse(articuloId, out int ID);
           
                var carrito = Session["Carrito"] as List<ArticuloDto>;

                if (carrito != null)
                {
                    ArticuloDto articuloAEliminar = carrito.FirstOrDefault(a => a.Id == ID);

                    if (articuloAEliminar != null)
                    {
                        carrito.Remove(articuloAEliminar);
                    }

                    Session["Carrito"] = carrito;
                    Response.Redirect("Carrito.aspx");
                }

                
            
        }

        protected void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }
    }
}