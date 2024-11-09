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
    const TITULO_ADICIONAR_OU_EDITAR_ID = "idAdicionarOuEditarTitulo";
    
    return BaseController.extend(NAMESPACE_CONTROLLER_ADICIONAR,{
        formatter: formatter,
        validacao: validacao,
        idJogo: null,

        onInit: function () {
            this.getRouter().getRoute("appAdicionarJogo").attachMatched(this._aoCoincidirRota, this);
        },

        _aoCoincidirRota: function (evento) {
            this.exibirEspera(() => {
                let ehEdicao = this._verificarSeEhEdicao(evento);

                ehEdicao 
                    ? this._prepararEdicao()
                    : this._prepararAdicao();
            });
        },

        _verificarSeEhEdicao: function (evento) {
            if (!!evento.getParameters().arguments.idJogo){
                this.idJogo = evento.getParameters().arguments.idJogo;
                return true;
            } else {
                return false;
            }
        },

        _prepararEdicao: async function () {
            const editarTitulo = "Editar Jogo";
            this._mudarTitulo(editarTitulo);
            await this.carregarGeneros();
            let jogo = await Repositorio.obterPorId(this.idJogo, this.getView());
            let key = this._pegarKeyDoGenero(jogo.genero);
            jogo.genero = key;
            await this._inicializarModelos(jogo);
        },

        _prepararAdicao: function () {
            const adicionarTitulo = "Adicionar Jogo";
            this._mudarTitulo(adicionarTitulo);
            this.idJogo = null;
            this.carregarGeneros();
            this._inicializarModelos();
        },

        _pegarKeyDoGenero: function (jogoGenero) {
            let dadosModeloGeneros = this.modeloGeneros().getData();
            let genero = dadosModeloGeneros.find(genero => genero.descricao === jogoGenero);  
            return genero.key;
        },

        _mudarTitulo: function (titulo) {
            this.byId(TITULO_ADICIONAR_OU_EDITAR_ID).setText(titulo)
        },

        _inicializarModelos: function (dados) {
            !!dados
                ? this.modeloJogo(new JSONModel(dados))
                : this.modeloJogo(new JSONModel());

            this._modeloValueState(new JSONModel({
                valueStateNome: "None",
                valueStatePreco: "None",
                valueStateGenero: "None"
            }));
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

        _salvarJogo: async function () {
            let dadosModeloJogo = this.modeloJogo().getData();
            let modeloValueState = this._modeloValueState();
            let ehValido = this._fazerValidacao(dadosModeloJogo, modeloValueState);

            modeloValueState.refresh();

            if (ehValido){
                if (!!this.idJogo){
                    await Repositorio.atualizar(dadosModeloJogo, this.getView());
                    this._irParaDetalhes(this.idJogo);
                } else {
                    await Repositorio.criar(dadosModeloJogo, this.getView())
                        .then(id => this._irParaDetalhes(id));
                }
            }
        },

        aoClicarSalvarJogo: function () {
            this.exibirEspera(() => this._salvarJogo());
        },

        aoClicarCancelarAdicaoDoJogo: function () {
            this.exibirEspera(() => {
                this.mostrarMensagemDeAviso(this.getView(), this.idJogo)
            });
        },

        aoClicarNavegarParaListagem: function () {
            this.exibirEspera(() => this.navegarPara(ConstantesDaRota.NOME_DA_ROTA_DA_LISTAGEM_DE_JOGOS));
        }
    });
});