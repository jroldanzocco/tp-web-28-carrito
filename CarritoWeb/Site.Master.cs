using Catalogo.Dominio.DTO.Articulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace CarritoWeb
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetCartItemCount(GetItemCountSession());

            }
        }

        public void SetCartItemCount(int count)
        {
            lblUnidadesCarrito.Text = count.ToString();

            UpdatePanel1.Update();
        }

        private int GetItemCountSession()
        {
            List<ArticuloDto> artCarrito = Session["Carrito"] as List<ArticuloDto>;
            
            if (artCarrito != null)
            {
                var cantidad = 0;
                foreach(var  articulo in artCarrito)
                {
                    cantidad += articulo.Cantidad;
                }
                return cantidad;
            }

            return 0;
        }

    }
}