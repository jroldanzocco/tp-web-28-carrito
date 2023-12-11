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

                    foreach(var articulo in artCarrito)
                    {
                       
                    }
                    
                    if(artCarrito.Count > 0)
                    {
                        decimal precioTotal = artCarrito.Sum(x => x.PrecioTotal);
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
            var listaImagenes = DataBinder.Eval(dataItem, "Imagen") as List<string>;

            if (listaImagenes != null && listaImagenes.Count > 0)
            {
                return listaImagenes[0];
            }

            return DefaultImage.ImagePath;
        }

        protected void btnLimpiarCarrito_Click(object sender, EventArgs e)
        {
            Session.Remove("Carrito");
            Response.Redirect("Carrito.aspx");
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

        protected void repCarrito_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {

                TextBox txtCantidadArticulos = e.Item.FindControl("txtCantidadArticulos") as TextBox;
                Label labelParcial = e.Item.FindControl("lblParcial") as Label;
                ArticuloDto articulo = e.Item.DataItem as ArticuloDto;

                if (txtCantidadArticulos != null && articulo != null)
                {
                    txtCantidadArticulos.Text = articulo.Cantidad.ToString();

                    int.TryParse(txtCantidadArticulos.Text, out int cantidad);
                    decimal suma = 0;
                    if(cantidad > 0)
                    {
                        suma = Convert.ToDecimal(cantidad) * articulo.Precio;
                    }
                    labelParcial.Text = suma.ToString("0.00");
                }
                
            }
        }
    }
}