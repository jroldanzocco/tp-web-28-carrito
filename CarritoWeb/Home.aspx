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
                                    <div id="carouselExample<%# Container.ItemIndex %>" class="carousel slide" data-ride="carousel">
                                        <div class="carousel-inner">
                                            <asp:Repeater ID="repImagenes" runat="server" DataSource='<%# Eval("Imagen") %>'>
                                                <ItemTemplate>
                                                    <div class='<%# Container.ItemIndex == 0 ? "carousel-item active" : "carousel-item" %>'>
                                                        <asp:Image ID="imgImagen" runat="server" CssClass="d-block w-100" Width="96" Height="350" ImageUrl='<%# GetImageUrl(Container.DataItem) %>' AlternateText="ERROR AL CARGAR IMAGEN" />
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                </div>

                                <div class="card-body bg-light text-center">
                                    <div class="mb-2">
                                        <h6 class="font-weight-semibold mb-2">
                                            <a href="#" class="text-default mb-2" data-abc="true"><%# Eval("Descripcion") %></a>
                                        </h6>

                                        <a href="#" class="text-muted" data-abc="true"><%# Eval("Categoria") %></a>
                                    </div>

                                    <h3 class="mb-0 font-weight-semibold">$<%# Eval("Precio")%></h3>

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

</asp:Content>
