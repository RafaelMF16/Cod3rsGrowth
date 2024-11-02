sap.ui.define([
    'ui5/codersgrowth/app/BaseController',
    '../model/formatter',
    '../servicos/validacao',
    'ui5/codersgrowth/common/ConstantesDaRota',
    'ui5/codersgrowth/common/ConstantesDoBanco',
    'sap/ui/model/json/JSONModel'
], function(BaseController, formatter, validacao, ConstantesDaRota, ConstantesDoBanco, JSONModel) {
    'use strict';

    const NAMESPACE_CONTROLLER_ADICIONAR = "ui5.codersgrowth.app.adicionarJogo.AdicionarJogo";
    
    return BaseController.extend(NAMESPACE_CONTROLLER_ADICIONAR,{
        formatter: formatter,
        validacao: validacao,

        onInit: function () {
            this.getRouter().getRoute("appAdicionarJogo").attachMatched(this._aoCoincidirRota, this);
        },

        _aoCoincidirRota: function () {
            this.exibirEspera(async () => {
                await this.fazerRequisicaoGet(ConstantesDoBanco.CAMINHO_PARA_API_GENERO, this.nomeModeloGeneros, this.getView());
                this._inicializarModelos();
            });
        },

        _inicializarModelos: function () {
            this._modeloJogo(new JSONModel());
            this._modeloValueState(new JSONModel({
                valueStateNome: "None",
                valueStatePreco: "None",
                valueStateGenero: "None"
            }));
        },

        _modeloJogo: function (jsonModel) {
            const nomeModeloJogo = "jogo";

            return this.modelo(nomeModeloJogo, jsonModel);
        },

        _modeloValueState: function (jsonModel) {
            const nomeModeloValueState = "camposValueState";

            return this.modelo(nomeModeloValueState, jsonModel);
        },

        _prepararMensagemDeAtencao: function () {
            const propriedadesI18n = this.getView().getModel("i18n").getResourceBundle();
            const mensagem = "Tem certeza que deseja cancelar?"

            this.mostrarMensagemDeAviso(this.getView(), propriedadesI18n, mensagem, this.idJogo);
        },

        _converterGeneroParaInteiro: function (dadosModelo) {
            !!dadosModelo.genero 
                ? dadosModelo.genero = parseInt(dadosModelo.genero)
                : dadosModelo.genero = dadosModelo.genero;
        },

        _fazerValidacao: function (modeloValueState) {
            let dadosModeloJogo = this._modeloJogo().getData();
            
            this._converterGeneroParaInteiro(dadosModeloJogo);
            
            return this.validacao.validarTela(dadosModeloJogo, modeloValueState.getData());
        },

        _salvarJogo: function () {
            let modeloValueState = this._modeloValueState();
            let ehValido = this._fazerValidacao(modeloValueState);

            modeloValueState.refresh();

            if (ehValido)
                this.fazerRequisicaoPostOuPatch(ConstantesDoBanco.CAMINHO_PARA_API_JOGO, opcoes, jogo, this.getView());
        },

        aoClicarSalvarJogo: function () {
            this.exibirEspera(() => this._salvarJogo());
        },

        aoClicarCancelarAdicaoDoJogo: function () {
            this.exibirEspera(() => this._prepararMensagemDeAtencao());
        },

        aoClicarNavegarParaListagem: function () {
            this.exibirEspera(() => this.navegarPara(ConstantesDaRota.NOME_DA_ROTA_DA_LISTAGEM_DE_JOGOS));
        }
    });
});