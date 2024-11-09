sap.ui.define([
    'ui5/codersgrowth/app/BaseController',
    '../model/formatter',
    'ui5/codersgrowth/app/servicos/validacao',
    'sap/ui/model/json/JSONModel',
    'ui5/codersgrowth/common/ConstantesDaRota',
    '../repositorio/RepositorioJogo',
    'sap/m/MessageBox'
], function (BaseController, formatter, validacao, JSONModel, ConstantesDaRota, Repositorio, MessageBox) {
    'use strict';

    const NAMESPACE_DA_CONTROLLER_DETALHES_JOGO = "ui5.codersgrowth.app.detalhesJogo.DetalhesJogo";

    return BaseController.extend(NAMESPACE_DA_CONTROLLER_DETALHES_JOGO, {
        formatter: formatter,
        validacao: validacao,
        idJogo: null,

        onInit: function() {
            this.getRouter().getRoute("appDetalhesJogo").attachMatched(this._aoCoincidirRota, this);
        },

        _aoCoincidirRota: function(evento) {
            this.exibirEspera(() => {
                this.idJogo = this._obterIdJogoPelaRota(evento);
                return this._carregarJogo();
            });
        },

        _carregarJogo: function () {
            return Repositorio.obterPorId(this.idJogo, this.getView())
                .then(dados => this.modeloJogo(new JSONModel(dados)));
        },

        _obterIdJogoPelaRota(evento) {
            const idJogo = evento.getParameters().arguments.idJogo;

            return idJogo;
        },

        _exibirMensagemDeConfirmacao: async function () {
            let jogo = await Repositorio.obterPorId(this.idJogo, this.getView());
            const nomeModeloI18n = "i18n";
            const propriedadesI18n = this.getView().getModel(nomeModeloI18n).getResourceBundle();
            const chaveI18nMensagemDeAviso = "MessageBox.Aviso.TemCertezaQueQuerRemover";
            const chaveI18nMessageBoxAvisoTitulo = "MessageBox.Aviso.Titulo";

            MessageBox.warning(propriedadesI18n.getText(chaveI18nMensagemDeAviso) + ` ${jogo.nome}?`, {
                title: propriedadesI18n.getText(chaveI18nMessageBoxAvisoTitulo),
                actions: [sap.m.MessageBox.Action.YES, sap.m.MessageBox.Action.CANCEL],
				emphasizedAction: MessageBox.Action.YES,
                onClose: (sAction) => {
                    this.exibirEspera(() => {
                        if (sAction === sap.m.MessageBox.Action.YES){
                            this._removerJogo();
                            this.navegarPara(ConstantesDaRota.NOME_DA_ROTA_DA_LISTAGEM_DE_JOGOS);
                        }
                    });
				},
            });
        },

        _removerJogo: async function () {
            return Repositorio.remover(this.idJogo, this.getView());
        },

        aoClicarIrParaEdicao: function () {
            this.navegarPara(ConstantesDaRota.NOME_DA_ROTA_DE_ADICIONAR_JOGO, this.idJogo);
        },

        aoClicarRemoverJogo: function () {
            this.exibirEspera(() => this._exibirMensagemDeConfirmacao());
        },

        aoClicarVoltarParaListagem: function () {
            this.exibirEspera(() => this.navegarPara(ConstantesDaRota.NOME_DA_ROTA_DA_LISTAGEM_DE_JOGOS));
        }
    });
});