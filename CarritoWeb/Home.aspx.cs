using Catalogo.Common;
using Catalogo.Dominio.DTO.Articulo;
using Catalogo.Dominio.Services;
using Infraestructure.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarritoWeb
{
    public partial class _Default : Page
    {
        private ArticuloServices _articuloServices;
        private List<ArticuloDto> _listArticulos;
        protected void Page_Load(object sender, EventArgs e)
        {
            _articuloServices = new ArticuloServices(new UnitOfWork());
            _listArticulos = _articuloServices.GetAll();
            if(!IsPostBack)
            {
                repRepetidor.DataSource = _listArticulos;
                repRepetidor.DataBind();
            }
        }

        protected string GetImageUrl(object dataItem)
        {
            string imageUrl = dataItem?.ToString();


            if (string.IsNullOrEmpty(imageUrl) || !Uri.IsWellFormedUriString(imageUrl, UriKind.RelativeOrAbsolute))
            {
                imageUrl = DefaultImage.ImagePath;
            }

            return imageUrl;
        }

        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string articuloId = btn.CommandArgument;
            int.TryParse(articuloId, out int ID);
            ArticuloDto articulo = _articuloServices.GetById(ID);
            int cantidadArticulos = 0;

            List<ArticuloDto> carrito = Session["Carrito"] as List<ArticuloDto>;

            if(carrito == null)
            {
                carrito = new List<ArticuloDto>();
            }

            ArticuloDto articuloEnCarrito = carrito.FirstOrDefault(x => x.Id == articulo.Id);

            if (articuloEnCarrito != null)
            {
                articuloEnCarrito.Cantidad++;
            }
            else
            {
                articulo.Cantidad = 1;
                carrito.Add(articulo);
            }

            foreach (var item in carrito)
            {
                item.PrecioTotal = item.Precio * Convert.ToDecimal(item.Cantidad);
                cantidadArticulos += item.Cantidad;
            }

            Session["Carrito"] = carrito;


            ((SiteMaster)Master).SetCartItemCount(cantidadArticulos);
        }
    }
}