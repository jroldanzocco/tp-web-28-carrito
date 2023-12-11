function prevSlide() {
    $('#myCarousel').carousel('prev');
}

function nextSlide() {
    $('#myCarousel').carousel('next');
}

var delalertok = false
function deleteArticuloAlert(btn) {
    if (delalertok) {
        delalertok = false;
        return true;
    }

    Swal.fire({
        title: "Estas seguro?",
        text: "¿Deseas eliminar el articulo?",
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