sap.ui.define([
    'ui5/codersgrowth/app/BaseController',
    '../model/formatter',
    '../servicos/validacao',
    'ui5/codersgrowth/common/ConstantesDaRota',
    'sap/ui/model/json/JSONModel',
    '../repositorio/RepositorioJogo'
], function(
    BaseController, 
    formatter, 
    validacao, 
    ConstantesDaRota, 
    JSONModel,
    Repositorio
) {
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
                await this.carregarGeneros();
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

        _converterGeneroParaInteiro: function (dadosModelo) {
            !!dadosModelo.genero 
                ? dadosModelo.genero = parseInt(dadosModelo.genero)
                : dadosModelo.genero = dadosModelo.genero;
        },

        _fazerValidacao: function (dadosModeloJogo, modeloValueState) {
            this._converterGeneroParaInteiro(dadosModeloJogo);
            
            return this.validacao.validarTela(dadosModeloJogo, modeloValueState.getData());
        },

        _irParaDetalhes: function (idJogo) {
            this.navegarPara(ConstantesDaRota.NOME_DA_ROTA_DE_DETALHE, idJogo);
        },

        _salvarJogo: function () {
            let dadosModeloJogo = this._modeloJogo().getData();
            let modeloValueState = this._modeloValueState();
            let ehValido = this._fazerValidacao(dadosModeloJogo, modeloValueState);

            modeloValueState.refresh();

            if (ehValido){
                Repositorio.criar(dadosModeloJogo, this.getView())
                    .then(id => this._irParaDetalhes(id));
            }
        },

        aoClicarSalvarJogo: function () {
            this.exibirEspera(() => this._salvarJogo());
        },

        aoClicarCancelarAdicaoDoJogo: function () {
            this.exibirEspera(() => this.mostrarMensagemDeAviso(this.getView()));
        },

        aoClicarNavegarParaListagem: function () {
            this.exibirEspera(() => this.navegarPara(ConstantesDaRota.NOME_DA_ROTA_DA_LISTAGEM_DE_JOGOS));
        }
    });
});