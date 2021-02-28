var faq = {
    init: function () {
        faq.registerEvents();
    },
    registerEvents: function () {
        $('#btnSend').off('click').on('click', function () {
            var name = $('#name').val();
            var email = $('#email').val();
            var phone_number = $('#phone_number').val();
            var msg_subject = $('#msg_subject').val();
            var message = $('#message').val();

            $.ajax({
                url: '/FAQ/Send',
                type: 'POST',
                dataType: 'json',
                data: {
                    name: name,
                    email: email,
                    phone_number: phone_number,
                    msg_subject: msg_subject,
                    message: message
                },
                success: function (res) {
                    if (res.status == true) {
                        window.alert('Submitted successfully !!!');
                        faq.resetForm();
                    }
                }
            });

        });
    },
    resetForm: function () {
        $('#name').val('');
        $('#email').val('');
        $('#phone_number').val('');
        $('#msg_subject').val('');
        $('#message').val('');
    }
}
faq.init();