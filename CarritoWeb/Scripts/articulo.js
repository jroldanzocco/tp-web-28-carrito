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
        $('#categoriaFields').hide();
        $('#imagenFields').hide();
        $('#marcaFields').show();
        seccionImagenActiva = false;
        seccionCategoriaActiva = false;
        seccionMarcaActiva = true;
    } else if (tipoElemento === 'categoria') {
        $('#modalTitulo').text('Agregar Categoría');
        $('#lblElemento').text('Categoría');
        $('#marcaFields').hide();
        $('#imagenFields').hide();
        $('#categoriaFields').show();
        seccionMarcaActiva = false;
        seccionImagenActiva = false;
        seccionCategoriaActiva = true;
    }
    else if (tipoElemento === 'imagen') {
        $('#modalTitulo').text('Agregar Imagen');
        $('#lblElemento').text('Imagen');
        $('#marcaFields').hide();
        $('#categoriaFields').hide();
        $('#imagenFields').show();
        seccionMarcaActiva = false;
        seccionCategoriaActiva = false;
        seccionImagenActiva = true;
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
    } else if (seccionImagenActiva) {
        return 'agregarImagen';
    } else {
        return '';
    }
}

function limpiarCampos() {
    $('#<%=txtCategoria.ClientID%>').val('');
    $('#<%=txtMarca.ClientID%>').val('');
    $('#<%=txtUrlImagen.ClientID%>').val('');
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

var delalertok = false
function deleteImageAlert(btn) {
    if (delalertok) {
        delalertok = false;
        return true;
    }

    Swal.fire({
        title: "Estas seguro?",
        text: "¿Deseas eliminar la imagen?",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#d33",
        cancelButtonColor: "#3085d6",
        confirmButtonText: "Si, borrar!",
    })
        .then(willDelete => {
            if (willDelete.isConfirmed) {
                delalertok = true;
                btn.click();
            }
        });

    return false;
}

