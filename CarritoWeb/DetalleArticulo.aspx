<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="CarritoWeb.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <!-- Product section-->
    <asp:Repeater ID="repArticulo" runat="server">
        <ItemTemplate>
            <section class="py-5">
                <div class="container px-4 px-lg-5 my-5">
                    <button class="btn btn-danger float-end m-2">Eliminar</button>
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
                                <input class="form-control text-center me-3" id="inputQuantity" type="num" value="1" style="max-width: 3rem" />
                                <asp:Button ID="btnAgregarCarrito" OnClick="btnAgregarCarrito_Click"  CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-outline-dark flex-shrink-0" runat="server" />
                                    <i class="bi-cart-fill me-1"></i>
                                    Agregar al carrito
                                </button>
                            </div>
                        </div>
                    </div>
                        </div>
                </div>
            </section>
        </ItemTemplate>
    </asp:Repeater>
        
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js" integrity="sha384-pzjw8v+czu0U+0a9L/l8YBjz5CsMlq8iNf5eL7oFq1jTjI92NniRS5GfOe9Bbi" crossorigin="anonymous"></script>
    <script>
        function prevSlide() {
            $('#myCarousel').carousel('prev');
        }

        function nextSlide() {
            $('#myCarousel').carousel('next');
        }
    </script>
</asp:Content>
