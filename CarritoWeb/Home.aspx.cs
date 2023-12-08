﻿using Catalogo.Common;
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
            string imageUrl = dataItem.ToString();


            if (string.IsNullOrEmpty(imageUrl) || !Uri.IsWellFormedUriString(imageUrl, UriKind.RelativeOrAbsolute))
            {
                imageUrl = DefaultImage.ImagePath;
            }

            return imageUrl;
        }
    }
}