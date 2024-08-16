sap.ui.define([
    "ui5/codersgrowth/app/BaseController"
], function (BaseController) {
    "use strict";
    return BaseController.extend("ui5.codersgrowth.app.paginaNaoEncontrada.PaginaNaoEncontrada", {
        onInit: function () {
        },

        voltarParaPaginaInicial: function () {
            this.getRouter().navTo("appJogo", {}, true);
        }
    });
});