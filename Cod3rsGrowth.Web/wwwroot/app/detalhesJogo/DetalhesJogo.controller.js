sap.ui.define([
    'ui5/codersgrowth/app/BaseController',
], function (BaseController) {
    'use strict';

    return BaseController.extend("ui5.codersgrowth.app.detalhesJogo.DetalhesJogo", {
        onInit: function() {
            this.getRouter().getRoute("appDetalhesJogo").attachMatched(this._aoCoincidirRota, this);
        },

        _aoCoincidirRota: function() {
            let idJogo = this._obterIdJogoPelaRota();
        },

        _obterIdJogoPelaRota() {
            const posicaoDoIdNaRota = 1;
            const idJogo = this.getOwnerComponent().getRouter().getHashChanger().getHash().split("/")[posicaoDoIdNaRota];

            return idJogo;
        }
    })
})