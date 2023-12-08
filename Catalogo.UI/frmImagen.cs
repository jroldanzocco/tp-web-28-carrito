﻿using Catalogo.Dominio;
using Catalogo.Dominio.DTO.Articulo;
using Catalogo.Dominio.Services;
using Catalogo.Negocio;
using Infraestructure.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Catalogo.UI
{
    public partial class frmImagen : Form
    {
        private ArticuloDto articulo = null;
        private ArticuloServices _artService;
        public frmImagen()
        {
            _artService = new ArticuloServices(new UnitOfWork());
            InitializeComponent();
        }

        private void frmImagen_Load(object sender, EventArgs e)
        {
        }
        public frmImagen(ArticuloDto articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Administrar imagen";

            ImagenNegocio imagenes = new ImagenNegocio();
            try
            {
                //cbxImagen.DataSource = _artService.get(articulo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void cbxImagen_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cbxImagen.SelectedItem.ToString();

            CargarImagen(opcion);
            
        }
        private void CargarImagen(string Imagen)
        {
            try
            {
                pbxImagen.Load(Imagen);
            }
            catch (Exception)
            {
                pbxImagen.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcROGVlwDhbC-6RixbdgEwDrABJ6BD3hhM2eJA&usqp=CAU");
            }
        }
    }
}
