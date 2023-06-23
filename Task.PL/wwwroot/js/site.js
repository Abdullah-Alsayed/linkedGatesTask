function CategoryChange() {
    $(`.prop`).addClass(`d-none`);
    $(`.propValues`).val('');
    let CategoryID = $(`#CategoryID`).val();
    let Query = `[data-id='Prop_${CategoryID}']`;
    $(Query).removeClass('d-none');
}
function DevicesForm(CustomerName, ActionName,FormID) {
    if ($(`#${FormID}`).valid()) {
        $("#BtnSend").prop('disabled', true);
        $(".Spinner").removeClass("d-none");
        let form = $(`#${FormID}`).serialize();

        let PropertyID = $(`.propId`).map(function () {
            return $(this).val();
        }).get();

        let Value = $(`.propValues`).map(function () {
            return $(this).val();
        }).get();

        form += "&PropertyID=" + PropertyID.toString();
        form += "&Value=" + Value.toString();

        $.ajax({
            url: `/${CustomerName}/${ActionName}`,
            type: 'POST',
            data: form,
            success: function (result) {
                $("#BtnSend").prop('disabled', false);
                $(".Spinner").addClass("d-none");
                if (result.success == false) {
                    Swal.fire({
                        position: 'error',
                        icon: 'error',
                        title: result.message,
                        showConfirmButton: false,
                        timer: 5000
                    });
                }
                else {
                    Swal.fire({
                        position: 'center',
                        icon: 'success',
                        title: result.message,
                        showConfirmButton: false,
                        timer: 5000
                    });
                    if (ActionName ==="Create") {
                        $(`#${FormID}`).trigger("reset");
                    }
                }
            },
            error: function (error) {
                $("#BtnSend").prop('disabled', false);
                $(".Spinner").addClass("d-none");
                Swal.fire({
                    position: 'error',
                    icon: 'error',
                    title: 'error',
                    showConfirmButton: false,
                    timer: 6000
                });
            }
        })
    } else {
        $(`#${FormID}`).submit();
    }
}
