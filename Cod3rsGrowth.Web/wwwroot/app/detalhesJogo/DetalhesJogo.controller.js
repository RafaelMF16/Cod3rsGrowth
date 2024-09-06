sap.ui.define([
    'ui5/codersgrowth/app/BaseController',
    '../model/formatter'
], function (BaseController, formatter) {
    'use strict';

    var idJogo = "";

    return BaseController.extend("ui5.codersgrowth.app.detalhesJogo.DetalhesJogo", {
        formatter: formatter,

        onInit: function() {
            this.getRouter().getRoute("appDetalhesJogo").attachMatched(this._aoCoincidirRota, this);
        },

        _aoCoincidirRota: function(evento) {
            idJogo = this._obterIdJogoPelaRota(evento);

            const viewDetalhesJogo = this.getView();
            const jogo = "jogo";
            const urlObterPorId = `/api/JogoControlador/${idJogo}`

            this.fazerRequisicaoGet(urlObterPorId, jogo, viewDetalhesJogo);
        },

        _obterIdJogoPelaRota(evento) {
            const idJogo = evento.getParameters().arguments.jogoId;

            return idJogo;
        },

        _navegarPara(nomeRota){
            this.getRouter()
                .navTo(nomeRota, {
                    jogoId: idJogo
                }, true);
        },

        _pegarNomeDoJogo: function () {
            const idJogoNomeTitulo = "idJogoNomeTitulo";
            const jogoNome = this.getView().byId(idJogoNomeTitulo).getText();
            
            return jogoNome;
        },

        _prepararMensagemDeAtencao: function () {
            const viewDetalhesJogo = this.getView();
            const propriedadesI18n = this.getView().getModel("i18n").getResourceBundle();
            const jogoNome = this._pegarNomeDoJogo();
            const mensagem = `Tem certeza que deseja remover o ${jogoNome}`

            this.mostrarMensagemDeAviso(viewDetalhesJogo, propriedadesI18n, mensagem, idJogo, jogoNome);
        },

        aoClicarIrParaEdicao: function () {
            const rotaAdicionarJogo = "appAdicionarJogo";
            this._navegarPara(rotaAdicionarJogo);
        },

        aoClicarRemoverJogo: function () {
            this._prepararMensagemDeAtencao();
        },

        navegarParaListagem: function () {
            const rotaListagem = "appListagemJogo"
            this.getRouter()
                .navTo(rotaListagem, {}, true);
        }
    });
});