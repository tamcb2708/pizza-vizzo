var cart = {
    init: function () {
        cart.regEnvents();
    },
    regEnvents: function () {
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = "/";
        });
    }
}
cart.init();