<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Articulo.aspx.cs" Inherits="CarritoWeb.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6 bg-light p-4 rounded">
                <h2 class="text-center mb-4 font-weight-bold">
                    <asp:Label runat="server" ID="lblTitulo"></asp:Label></h2>

                <div class="mb-3">
                    <label for="txtCodigo" class="form-label">Código</label>
                    <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" MaxLength="50" />
                    <asp:RequiredFieldValidator ID="rfvCodigo" runat="server" ControlToValidate="txtCodigo"
                        ErrorMessage="El codigo es obligatorio" ForeColor="Red" ValidationGroup="agregar" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revCodigo" runat="server" ControlToValidate="txtCodigo"
                    ValidationExpression="^[a-zA-Z0-9]+$" ErrorMessage="Solo se permiten letras y números."
                    ForeColor="Red" Display="Dynamic" ValidationGroup="agregar"/>
                    <asp:Label runat="server" ID="lblCodigo" ForeColor="Red"></asp:Label>
                </div>
                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" MaxLength="50" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre"
                        ErrorMessage="El nombre es obligatorio" ForeColor="Red" ValidationGroup="agregar" Display="Dynamic"></asp:RequiredFieldValidator>
                    <label runat="server" id="lblNombre" style="color: red;"></label>
                </div>
                <div class="mb-3">
                    <label for="txtDescripcion" class="form-label" maxlength="150">Descripción</label>
                    <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtMarca" class="form-label">Marca</label>
                    <a href="#" onclick="mostrarModal('marca'); return false;" style="text-decoration: none; color: green">Agregar Marca</a>
                    <asp:DropDownList runat="server" ID="ddlMarcas" CssClass="form-select"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label for="txtCategoria" class="form-label">Categoría</label>
                    <a href="#" onclick="mostrarModal('categoria'); return false;" style="text-decoration: none; color: green">Agregar Categoria</a>
                    <asp:DropDownList runat="server" ID="ddlCategorias" CssClass="form-select"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label for="txtPrecio" class="form-label">Precio</label>
                    <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" MaxLength="7" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPrecio"
                        ErrorMessage="El precio es obligatorio" ForeColor="Red" ValidationGroup="agregar" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revNumeros" runat="server" ControlToValidate="txtPrecio"
                        ErrorMessage="El numero es invalido" ValidationExpression="^[0-9]+(\,[0-9]{1,2})?$" ForeColor="Red" ValidationGroup="agregar" Display="Dynamic"></asp:RegularExpressionValidator>
                    <label runat="server" id="lblPrecio" style="color: red;"></label>
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
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalTitulo"></h5>

                </div>
                <div class="modal-body">

                    <!-- Marca -->
                    <div id="marcaFields" style="display: none;">
                        <label for="txtMarca" class="form-label">Campo Marca Específico</label>
                        <asp:TextBox ID="txtMarca" runat="server" CssClass="form-control" MaxLength="50" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMarca"
                            ErrorMessage="El nombre de marca es requerido" ForeColor="Red" ValidationGroup="agregarMarca" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:Label runat="server" ID="lblMarcaExistente" ForeColor="Red"></asp:Label>
                    </div>

                    <!-- Categoria -->
                    <div id="categoriaFields" style="display: none;">
                        <label for="txtCategoria" class="form-label">Campo Categoría Específico</label>
                        <asp:TextBox ID="txtCategoria" runat="server" CssClass="form-control" MaxLength="50" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCategoria"
                            ErrorMessage="El nombre de categoria es requerido" ForeColor="Red" ValidationGroup="agregarCategoria" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:Label runat="server" ID="lblCategoriaExistente" ForeColor="Red"></asp:Label>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button runat="server" ID="btnCancelarModal" Text="Cancelar" OnClientClick="cerrarModal(); return false;" CssClass="btn btn-secondary" />
                    <asp:Button runat="server" ID="btnGuardarModal" Text="Guardar" OnClientClick="return guardarModal();" UseSubmitBehavior="false" OnClick="btnGuardarModal_Click" CssClass="btn btn-primary" ValidationGroup="agregarMarca agregarCategoria" />
                </div>
            </div>
        </div>
    </div>

    <script>
        $(document).ready(function () {
            $('#miModal').modal({
                backdrop: 'static',
                keyboard: false
            });
        });
        function mostrarModal(tipoElemento) {
            if (tipoElemento === 'marca') {
                $('#modalTitulo').text('Agregar Marca');
                $('#lblElemento').text('Marca');
                $('#marcaFields').show();
                $('#categoriaFields').hide();
                seccionMarcaActiva = true;
                seccionCategoriaActiva = false;
            } else if (tipoElemento === 'categoria') {
                $('#modalTitulo').text('Agregar Categoría');
                $('#lblElemento').text('Categoría');
                $('#marcaFields').hide();
                $('#categoriaFields').show();
                seccionMarcaActiva = false;
                seccionCategoriaActiva = true;
            }

            $('#miModal').modal('show');
        }

        function guardarModal() {
            var currentValidationGroup = obtenerGrupoValidacionActual();

            if (Page_ClientValidate(currentValidationGroup)) {
                validarCategoriaExistente();
                validarMarcaExistente();

                if ($('#<%=lblMarcaExistente.ClientID%>').text() === "" && $('#<%=lblCategoriaExistente.ClientID%>').text() === "") {
                    __doPostBack('<%= btnGuardarModal.UniqueID %>', '');
                    $('#miModal').modal('hide');
                }
            }
            return false;
        }

        function cerrarModal() {
            $('#miModal').modal('hide');
            limpiarCampos();
        }

        function obtenerGrupoValidacionActual() {

            if (seccionMarcaActiva) {
                return 'agregarMarca';
            } else if (seccionCategoriaActiva) {
                return 'agregarCategoria';
            } else {
                return '';
            }
        }

        function limpiarCampos() {
            $('#<%=txtCategoria.ClientID%>').val('');
            $('#<%=txtMarca.ClientID%>').val('');
        }
        function validarMarcaExistente() {
            var marcaIngresada = $('#<%=txtMarca.ClientID%>').val().trim().toLowerCase();
            var ddlMarcas = $('#<%=ddlMarcas.ClientID%>'); 
            var lblMarcaExistente = $('#<%=lblMarcaExistente.ClientID%>'); 

            lblMarcaExistente.text('');

           
            for (var i = 0; i < ddlMarcas[0].options.length; i++) {
                var marcaExistente = ddlMarcas[0].options[i].text.trim().toLowerCase();

               
                if (marcaExistente === marcaIngresada) {
                    lblMarcaExistente.text('La marca ya existe');
                    return;
                }
            }
        }

        function validarCategoriaExistente() {
            var categoriaIngresada = $('#<%=txtCategoria.ClientID%>').val().trim().toLowerCase();
            var ddlCategorias = $('#<%=ddlCategorias.ClientID%>');
            var lblCategoriaExistente = $('#<%=lblCategoriaExistente.ClientID%>');

            lblCategoriaExistente.text('');

            for (var i = 0; i < ddlCategorias[0].options.length; i++) {
                var categoriaExistente = ddlCategorias[0].options[i].text.trim().toLowerCase();

                if (categoriaExistente === categoriaIngresada) {
                    lblCategoriaExistente.text('La categoría ya existe');
                    return;
                }
            }
        }
        
    </script>
</asp:Content>
