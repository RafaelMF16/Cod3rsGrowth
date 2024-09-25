sap.ui.define([
    'ui5/codersgrowth/app/BaseController',
    '../model/formatter',
    'ui5/codersgrowth/app/servicos/validacao',
    'sap/ui/model/json/JSONModel',
    'ui5/codersgrowth/common/ConstantesDoBanco',
    'ui5/codersgrowth/common/ConstantesDaRota'
], function (BaseController, formatter, validacao, JSONModel, ConstantesDoBanco, ConstantesDaRota) {
    'use strict';

    var idJogo = "";

    return BaseController.extend("ui5.codersgrowth.app.detalhesJogo.DetalhesJogo", {
        formatter: formatter,
        validacao: validacao,
        constantesDoBanco: ConstantesDoBanco,

        onInit: function() {
            this.getRouter().getRoute("appDetalhesJogo").attachMatched(this._aoCoincidirRota, this);
        },

        _aoCoincidirRota: function(evento) {
            idJogo = this._obterIdJogoPelaRota(evento);

            const viewDetalhesJogo = this.getView();
            const jogo = "jogo";
            const urlObterPorId = ConstantesDoBanco.CAMINHO_PARA_API_JOGO + `/${idJogo}`;

            this.fazerRequisicaoGet(urlObterPorId, jogo, viewDetalhesJogo);
        },

        _obterIdJogoPelaRota(evento) {
            const idJogo = evento.getParameters().arguments.jogoId;

            return idJogo;
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
            this.navegarPara(ConstantesDaRota.NOME_DA_ROTA_DE_ADICIONAR_JOGO, idJogo);
        },

        aoClicarRemoverJogo: function () {
            this._prepararMensagemDeAtencao();
        },

        aoClicarVoltarParaTelaDeListagem: function () {
            this.navegarPara(ConstantesDaRota.NOME_DA_ROTA_DA_LISTAGEM_DE_JOGOS);
        }
    });
});