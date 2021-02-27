var contact = {
    init: function () {
        contact.registerEvents();
    },
    registerEvents: function () {
        $('#btnSend').off('click').on('click', function () {
            var name = $('#txtName').val();
            var phone = $('#txtPhone').val();
            var address = $('#txtAddress').val();
            var email = $('#txtEmail').val();
            var yeucau = $('#txtYeucau').val();

            $.ajax({
                url: '/Contact/Send',
                type: 'POST',
                dataType:'json',
                data: {
                    name: name,
                    phone: phone,
                    address: address,
                    email: email,
                    yeucau: yeucau
                },
                success: function (res) {
                    if (res.status == true) {
                        window.alert('Submitted successfully !!!');
                        contact.resetForm();
                    }
                }
            });

        });
    },
    resetForm: function () {
        $('#txtName').val('');
        $('#txtPhone').val('');
        $('#txtAddress').val('');
        $('#txtEmail').val('');
        $('#txtYeucau').val('');
    }
}
contact.init();