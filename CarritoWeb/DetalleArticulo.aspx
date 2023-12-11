<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="CarritoWeb.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .custom-button {
        background-color: white;
        color: black;
        border: 1px solid black;
    }

    .custom-button:hover {
        background-color: darkorange;
        color: white;
    }
    </style>
    <!-- Product section-->
    <asp:Repeater ID="repArticulo" runat="server">
        <ItemTemplate>
            <section class="py-5">
                <div class="container px-4 px-lg-5 my-5">
                    <asp:Button runat="server" CssClass="btn btn-danger float-end m-2" Text="Eliminar" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" ID="btnEliminarArticulo" OnClientClick="return deleteArticuloAlert(this)" OnClick="btnEliminarArticulo_Click"/>
                    <asp:Button runat="server" CssClass="btn btn-secondary float-end mt-2" Text="Editar" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" ID="btnEditarArticulo" OnClick="btnEditarArticulo_Click"/>
                    <div class="container px-4 px-lg-5 my-5 bg-white p-4 rounded shadow-sm">
                    <div class="row gx-4 gx-lg-5 align-items-center">
                        <div class="col-md-6">
                            <div id="myCarousel" class="carousel slide" data-bs-ride="carousel">
                                <div class="carousel-inner">
                                    <asp:Repeater ID="repImagenes" runat="server" DataSource='<%# Eval("Imagen") %>'>
                                        <ItemTemplate>
                                            <div class='<%# Container.ItemIndex == 0 ? "carousel-item active" : "carousel-item" %>'>
                                                <asp:Image ID="imgImagen" runat="server" CssClass="d-block w-100" Height="450" ImageUrl='<%# GetImageUrl(Container.DataItem) %>' AlternateText="ERROR AL CARGAR IMAGEN" />
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                 <!-- Controles carrusel -->
 <button class="carousel-control-prev" type="button" onclick="prevSlide(<%# Container.ItemIndex %>)">
     <img src="Assets/flecha.png" alt="Anterior" class="carousel-control-next-icon rotate-180" />
 </button>
 <button class="carousel-control-next" type="button" onclick="nextSlide(<%# Container.ItemIndex %>)">
     <img src="Assets/flecha.png" alt="Siguiente" class="carousel-control-next-icon" />
 </button>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="small mb-1"><%# Eval("Marca") %> - <a href="#" style="text-decoration:none; color:black"><%# Eval("Categoria") %></a></div>
                            <h1 class="display-5 fw-bolder"><%# Eval("Nombre") %></h1>
                            <div class="fs-5 mb-5">
                                <span class="text-decoration-line-through">$<%# (Convert.ToDecimal(Eval("Precio")) * 2).ToString("0.00") %></span>
                                <span>$<%# (Convert.ToDecimal(Eval("Precio"))).ToString("0.00") %></span>
                            </div>
                            <p class="lead"><%# Eval("Descripcion") %></p>
                            <div class="d-flex">
                            
                           <i class="bi-cart-fill me-1"> <asp:Button runat="server" ID="btnAgregarCarrito" CommandArgument='<%# Eval("Id") %>' CommandName="ArticuloId" OnClick="btnAgregarCarrito_Click1" CssClass="custom-button btn btn-outline-dark flex-shrink-0 w-100" Text="Agregar al carrito" /></i>
                                
                        </div>
                    </div>
                        </div>
                </div>
            </section>
        </ItemTemplate>
    </asp:Repeater>
        
    <script src="Scripts/detalleArticulo.js"></script>
</asp:Content>
