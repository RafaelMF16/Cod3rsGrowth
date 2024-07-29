sap.ui.define([
    "ui5/codersgrowth/controller/BaseController"
], function (BaseController) {
    "use strict";
    return BaseController.extend("ui5.codersgrowth.controller.PaginaNaoEncontrada", {
        onInit: function () {
        },

        voltarParaPaginaInicial: function () {
            this.getRouter().navTo("appJogo", {}, true);
        }
    });
});