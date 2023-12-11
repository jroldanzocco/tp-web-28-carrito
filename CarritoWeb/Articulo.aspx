<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Articulo.aspx.cs" Inherits="CarritoWeb.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6 bg-light p-4 rounded">
                <h2 class="text-center mb-4 font-weight-bold">
                    <asp:Label runat="server" ID="lblTitulo"></asp:Label></h2>
                <div id="flex-container" class="d-flex">
                <div id="txtBoxContainer" class="col-md-6">
                <div class="mb-3">
                    <label for="txtCodigo" class="form-label">Código</label>
                    <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" MaxLength="50" />
                    <asp:RequiredFieldValidator ID="rfvCodigo" runat="server" ControlToValidate="txtCodigo"
                        ErrorMessage="El codigo es obligatorio" ForeColor="Red" ValidationGroup="agregar" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revCodigo" runat="server" ControlToValidate="txtCodigo"
                        ValidationExpression="^[a-zA-Z0-9]+$" ErrorMessage="Solo se permiten letras y números."
                        ForeColor="Red" ValidationGroup="agregar" />
                    <asp:Label runat="server" ID="lblCodigo" ForeColor="Red"></asp:Label>
                </div>
                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" MaxLength="50" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre"
                        ErrorMessage="El nombre es obligatorio" ForeColor="Red" ValidationGroup="agregar"></asp:RequiredFieldValidator>
                </div>
                <div class="mb-3">
                    <label for="txtDescripcion" class="form-label">Descripción</label>
                    <asp:TextBox runat="server" ID="txtDescripcion" MaxLength="150" CssClass="form-control" />
                   
                </div>
                <div class="mb-3">
                    <label for="txtUrlImagen" class="form-label">Imagen</label>
                    <a href="#" onclick="mostrarModal('imagen'); return false;" style="text-decoration: none; color: green">Agregar Imagen</a>
                    
                    <asp:Button runat="server" ID="btnEliminarImagen" OnClientClick="return deleteImageAlert(this);" OnClick="btnEliminarImagen_Click" Text="Eliminar imagen" ForeColor="Red" />
                    <asp:DropDownList runat="server" ID="ddlImagen" AutoPostBack="true" CssClass="form-select" OnSelectedIndexChanged="ddlImagen_SelectedIndexChanged"></asp:DropDownList>
                    
                    
                </div>
                <div class="mb-3">
                    <label for="txtMarca" class="form-label">Marca</label>
                    <a href="#" onclick="mostrarModal('marca'); return false;" style="text-decoration: none; color: green">Agregar Marca</a>
                    <asp:DropDownList runat="server" ID="ddlMarcas" CssClass="form-select"></asp:DropDownList>
                    <asp:Label ID="lblMarca" ForeColor="red" runat="server"></asp:Label>
                </div>
                <div class="mb-3">
                    <label for="txtCategoria" class="form-label">Categoría</label>
                    <a href="#" onclick="mostrarModal('categoria'); return false;" style="text-decoration: none; color: green">Agregar Categoria</a>
                    <asp:DropDownList runat="server" ID="ddlCategorias" CssClass="form-select"></asp:DropDownList>
                    <asp:Label ID="lblCategoria" ForeColor="red" runat="server"></asp:Label>
                </div>
                <div class="mb-3">
                    <label for="txtPrecio" class="form-label">Precio</label>
                    <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" MaxLength="7" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPrecio"
                        ErrorMessage="El precio es obligatorio" ForeColor="Red" ValidationGroup="agregar" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revNumeros" runat="server" ControlToValidate="txtPrecio"
                        ErrorMessage="El numero es invalido" ValidationExpression="^[0-9]+(\,[0-9]{1,2})?$" ForeColor="Red" ValidationGroup="agregar"></asp:RegularExpressionValidator>
                </div>
                    </div>
                <div id="imagePreviewContainer" class="col-md-6 d-flex justify-content-center align-items-center">
                    <asp:Image runat="server" ID="imagePreview" ImageUrl="https://upload.wikimedia.org/wikipedia/commons/thumb/d/d1/Image_not_available.png/640px-Image_not_available.png" CssClass="img-fluid mt-2 h-auto" Width="250px"/>
                </div>
                    </div>
                <div class="mb-3 text-center">
                    <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary me-2" OnClick="btnAceptar_Click" runat="server" ValidationGroup="agregar" />
                    <asp:Button Text="Cancelar" ID="btnCancelar" CssClass="btn btn-secondary me-2" runat="server" OnClick="btnCancelar_Click" />
                </div>
            </div>
        </div>
    </div>
    <!-- Modal -->
    <div class="modal" tabindex="-1" role="dialog" id="miModal">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalTitulo"></h5>
                </div>
                <div class="modal-body">

                    <!-- Marca -->
                    <div id="marcaFields" style="display: none;">
                        <label for="txtMarca" class="form-label">Marca</label>
                        <asp:TextBox ID="txtMarca" runat="server" CssClass="form-control" MaxLength="50" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMarca"
                            ErrorMessage="El nombre de marca es requerido" ForeColor="Red" ValidationGroup="agregarMarca" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:Label runat="server" ID="lblMarcaExistente" ForeColor="Red"></asp:Label>
                    </div>

                    <!-- Categoria -->
                    <div id="categoriaFields" style="display: none;">
                        <label for="txtCategoria" class="form-label">Categoría</label>
                        <asp:TextBox ID="txtCategoria" runat="server" CssClass="form-control" MaxLength="50" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCategoria"
                            ErrorMessage="El nombre de categoria es requerido" ForeColor="Red" ValidationGroup="agregarCategoria" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:Label runat="server" ID="lblCategoriaExistente" ForeColor="Red"></asp:Label>
                    </div>
                    <!-- Imagen -->
                    <div id="imagenFields" style="display: none;">
                        <label for="txtUrlImagen" class="form-label">UrlImagen</label>
                        <asp:TextBox ID="txtUrlImagen" runat="server" CssClass="form-control" MaxLength="1000" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtUrlImagen"
                            ErrorMessage="El url de la imagen es requerido" ForeColor="Red" ValidationGroup="agregarImagen"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button runat="server" ID="btnCancelarModal" Text="Cancelar" OnClientClick="cerrarModal(); return false;" CssClass="btn btn-secondary" />
                    <asp:Button runat="server" ID="btnGuardarModal" Text="Guardar" OnClientClick="return guardarModal();" UseSubmitBehavior="false" OnClick="btnGuardarModal_Click" CssClass="btn btn-primary" ValidationGroup="agregarImagen agregarMarca agregarCategoria" />
                </div>
            </div>
        </div>
    </div>

    <script src="Scripts/articulo.js"></script>
</asp:Content>
