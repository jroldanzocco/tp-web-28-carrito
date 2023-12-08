<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="CarritoWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container d-flex justify-content-center mt-50 mb-50">

        <div class="row">
            <asp:Repeater ID="repRepetidor" runat="server">
                <ItemTemplate>

                    <div class="col-md-4 mt-2">
                        <div class="card">
                            <div class="card-body">
                                <div class="card-img-actions">
                                    <div id="carouselExample<%# Container.ItemIndex %>" class="carousel slide" data-ride="carousel" data-interval="false">
                                        <div class="carousel-inner">
                                            <asp:Repeater ID="repImagenes" runat="server" DataSource='<%# Eval("Imagen") %>'>
                                                <ItemTemplate>
                                                    <div class='<%# Container.ItemIndex == 0 ? "carousel-item active" : "carousel-item" %>'>
                                                        <asp:Image ID="imgImagen" runat="server" CssClass="d-block w-100" Width="96" Height="350" ImageUrl='<%# GetImageUrl(Container.DataItem) %>' AlternateText="ERROR AL CARGAR IMAGEN" />
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

                                <div class="card-body bg-light text-center">
                                    <div class="mb-2">
                                        <h6 class="font-weight-semibold mb-2">
                                            <a href="<%# "DetalleArticulo.aspx?id=" + Eval("Id") %>" class="text-default mb-2" data-abc="true"><%# Eval("Nombre") %></a>
                                        </h6>

                                        <a href="#" class="text-muted" data-abc="true"><%# Eval("Categoria") %></a>
                                    </div>

                                    <h3 class="mb-0 font-weight-semibold">$<%# (Convert.ToDecimal(Eval("Precio"))).ToString("0.00")%></h3>

                                    <div>
                                        <i class="fa fa-star star"></i>
                                        <i class="fa fa-star star"></i>
                                        <i class="fa fa-star star"></i>
                                        <i class="fa fa-star star"></i>
                                    </div>

                                    <button type="button" class="btn bg-cart mt-3 mb-3"><i class="fa fa-cart-plus mr-2"></i>Add to cart</button>
                                    <div>
                                        <p class=" text-muted fw-bold"><%# Eval("Marca") %></p>
                                    </div>

                                </div>
                            </div>



                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>






        </div>
    </div>
    <script>
        function prevSlide(index) {
            $('#carouselExample' + index).carousel('prev');
        }

        function nextSlide(index) {
            $('#carouselExample' + index).carousel('next');
        }
    </script>
</asp:Content>
