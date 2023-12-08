<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Articulo.aspx.cs" Inherits="CarritoWeb.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container mt-5">
    <div class="row justify-content-center">
        <div class="col-md-6 bg-light p-4 rounded">
            <h2 class="text-center mb-4 font-weight-bold"><asp:Label runat="server" ID="lblTitulo"></asp:Label></h2>

            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Código</label>
                <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" MaxLength="50"/>
                <asp:RequiredFieldValidator ID="rfvCodigo" runat="server" ControlToValidate="txtCodigo"
                ErrorMessage="El codigo es obligatorio" ForeColor="Red" ValidationGroup="agregar" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:Label runat="server" ID="lblCod" ForeColor="Red" ></asp:Label>
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" MaxLength="50"/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre"
                ErrorMessage="El nombre es obligatorio" ForeColor="Red" ValidationGroup="agregar" Display="Dynamic"></asp:RequiredFieldValidator>
                <label runat="server" id="lblNombre" style="color:red;"></label>
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label" MaxLength="150">Descripción</label>
                <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtMarca" class="form-label">Marca</label>
                <asp:DropDownList runat="server" ID="ddlMarcas" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txtCategoria" class="form-label">Categoría</label>
                <asp:DropDownList runat="server" ID="ddlCategorias" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio</label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" MaxLength="10" />                
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPrecio"
                ErrorMessage="El precio es obligatorio" ForeColor="Red" ValidationGroup="agregar" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revNumeros" runat="server" ControlToValidate="txtPrecio"
                ErrorMessage="El numero es invalido" ValidationExpression="^[0-9]+(\,[0-9]{1,2})?$" ForeColor="Red" ValidationGroup="agregar" Display="Dynamic"></asp:RegularExpressionValidator>
                <label runat="server" id="lblPrecio" style="color:red;"></label>
            </div>
            <div class="mb-3 text-center">
                <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary me-2" OnClick="btnAceptar_Click" runat="server" ValidationGroup="agregar"/>
                <a class="btn btn-secondary" href='javascript:history.go(-1)'>Cancelar</a>
            </div>
        </div>
    </div>
</div>

</asp:Content>
