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
    public partial class WebForm1 : System.Web.UI.Page
    {
        ArticuloServices _articuloServices;
        protected void Page_Load(object sender, EventArgs e)
        {
            _articuloServices = new ArticuloServices(new UnitOfWork());
            string id = Request.QueryString["Id"];

           
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(id))
                {
                    int.TryParse(id, out int idValidate);
                    var articulo = _articuloServices.GetById(idValidate);

                    if(articulo != null)
                        {
                        repArticulo.DataSource = new List<ArticuloDto> { articulo };
                        repArticulo.DataBind();
                    }
                }
            }

        }
        protected string GetImageUrl(object dataItem)
        {
            string imageUrl = dataItem.ToString();


            if (string.IsNullOrEmpty(imageUrl) || !Uri.IsWellFormedUriString(imageUrl, UriKind.RelativeOrAbsolute))
            {
                imageUrl = DefaultImage.ImagePath;
            }

            return imageUrl;
        }

        protected void btnEditarArticulo_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;

            Response.Redirect("Articulo.aspx?id=" + id);
        }
    }
}