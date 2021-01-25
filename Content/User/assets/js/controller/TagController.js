var tag = {
    init: function () {
        tag.registerEvents();
    },
    registerEvents: function () {
        $('#bit').off('click').on('click', function () {

            var email = $('#email').val();


            $.ajax({
                url: '/defalts/Send',
                type: 'POST',
                dataType: 'json',
                data: {
                    email: email
                },
                success: function (res) {
                    if (res.status == true) {
                        window.alert('Thank You For Your Follow Up Mail On Our Pages !!!');
                        tag.resetForm();
                    }
                }
            });

        });
    },
    resetForm: function () {
        $('#email').val('');
    }
}
tag.init();