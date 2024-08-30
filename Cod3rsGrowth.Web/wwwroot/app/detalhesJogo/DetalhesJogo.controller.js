sap.ui.define([
    'ui5/codersgrowth/app/BaseController',
    '../model/formatter'
], function (BaseController, formatter) {
    'use strict';

    return BaseController.extend("ui5.codersgrowth.app.detalhesJogo.DetalhesJogo", {
        formatter: formatter,
        onInit: function() {
            this.getRouter().getRoute("appDetalhesJogo").attachMatched(this._aoCoincidirRota, this);
        },

        _aoCoincidirRota: function(evento) {
            const idJogo = this._obterIdJogoPelaRota(evento);
            const viewDetalhesJogo = this.getView();
            const jogo = "jogo";
            const urlObterPorId = `/api/JogoControlador/${idJogo}`
            this.fazerRequisicaoGet(urlObterPorId, jogo, viewDetalhesJogo);

        },

        _obterIdJogoPelaRota(evento) {
            const idJogo = evento.getParameters().arguments.jogoId;

            return idJogo;
        }
    })
})