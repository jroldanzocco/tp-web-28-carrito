<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="CarritoWeb.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container px-3 my-5 clearfix">
    <!-- Shopping cart table -->
    <div class="card">
        <div class="card-header">
            <h2>Carrito de compra</h2>
        </div>
        <div class="card-body">
            <div class="table-responsive">
              <table class="table table-bordered m-0">
                <thead>
                  <tr>
                    <!-- Set columns width -->
                    <th class="text-center py-3 px-4" style="min-width: 400px;">Nombre del producto y detalles</th>
                    <th class="text-right py-3 px-4" style="width: 100px;">Precio</th>
                    <th class="text-center py-3 px-4" style="width: 120px;">Cantidad</th>
                    <th class="text-right py-3 px-4" style="width: 100px;">Total</th>
                      <th class="text-center align-middle py-3 px-0" style="width: 40px;"><asp:Button ID="btnLimpiarCarrito" Text="x" ToolTip="Vaciar carrito" OnClick="btnLimpiarCarrito_Click" CssClass="shop-tooltip float-none text-light" runat="server" /></th>
              
                  </tr>
                </thead>
                <tbody>
        <asp:Repeater runat="server" ID="repCarrito" OnItemDataBound="repCarrito_ItemDataBound">
            <ItemTemplate>
                  <tr>
                    <td class="p-4">
                      <div class="media align-items-center">
                          <asp:Image ID="imgImagen" runat="server" CssClass="d-block ui-w-40 ui-bordered mr-4" Width="200px" Height="250px" ImageUrl='<%# GetFirstImageUrl(Container.DataItem) %>' AlternateText="ERROR AL CARGAR IMAGEN" />
                        <div class="media-body">
                          <a class="d-block text-dark"><%# Eval("Nombre") %></a>
                          <small>
                            <span class="text-muted">Marca: </span> <%# Eval("Marca") %>
                            <span class="text-muted">Envio desde: </span> Argentina
                          </small>
                        </div>
                      </div>
                    </td>
                    <td class="text-right font-weight-semibold align-middle p-4">$<%# Eval("Precio") %></td>
                    <td class="align-middle p-4"><asp:TextBox runat="server" ReadOnly="true" ID="txtCantidadArticulos" CssClass="form-control text-center" /></td>
                    <td class="text-right font-weight-semibold align-middle p-4"><asp:Label ID="lblParcial" runat="server"></asp:Label></td>
                    <td class="text-center align-middle px-0"><asp:Button ID="btnEliminarArticulo" BorderColor="Transparent" ToolTip="Quitar del carrito" BorderStyle="None" Text="x" OnClick="btnEliminarArticulo_Click" CommandArgument='<%# Eval("Id") %>' CssClass="shop-tooltip close float-none text-danger" runat="server" /></td>
                  </tr>
               </ItemTemplate>
                    </asp:Repeater>
                  
        
                </tbody>
              </table>
            </div>
            <!-- / Shopping cart table -->
        
            <div class="d-flex flex-wrap justify-content-end align-items-center pb-4">
              
              <div class="d-flex">
                <div class="text-right mt-4 mr-5">
                </div>
                <div class="text-right mt-4 m-md-5">
                  <label class="text-muted font-weight-semibold m-0 fs-5">Total:</label>
                    <asp:Label runat="server" CssClass="text-large fw-bold" ID="lblPrecioTotal"></asp:Label>
                </div>
              </div>
            </div>
        
            <div class="float-right">
                <a href="Home.aspx" class="btn btn-lg btn-info md-btn-flat mt-2 mr-3">Seguir comprando</a>
              <button type="button" class="btn btn-lg btn-primary mt-2">Comprar</button>
            </div>
        
          </div>
      </div>
  </div>
</asp:Content>
