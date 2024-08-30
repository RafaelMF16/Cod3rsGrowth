sap.ui.define([
    'ui5/codersgrowth/app/BaseController',
    '../model/formatter',
    '../servicos/validacao'
], function(BaseController, formatter, validacao) {
    'use strict';

    const inputNomeId = "idInputNome";
    const inputPrecoId = "idInputPreco";
    const selectGeneroId = "idSelectGenero";
    
    return BaseController.extend("ui5.codersgrowth.app.adicionarJogo.AdicionarJogo",{
        formatter: formatter,
        validacao: validacao,

        onInit: function () {
            this.getRouter().getRoute("appAdicionarJogo").attachMatched(this._aoCoincidirRota, this);
        },

        _aoCoincidirRota: function (oEvent) {
            const urlObterGeneros = "/api/GeneroControlador";
            const nomeListaGeneros = "listaGeneros";
            const valueStatePadrao = "None";
            const idJogo = this._obterIdJogoPelaRota(oEvent);
            const viewAdicionarJogo = this.getView();
            
            if (idJogo){
                const urlObterPorId = `/api/JogoControlador/${idJogo}`;
                this._fazerRequisicaoObterPorId(urlObterPorId, viewAdicionarJogo);
            } else {
                this._limparCampos(inputNomeId, inputPrecoId, selectGeneroId, valueStatePadrao);
            }

            this.fazerRequisicaoGet(urlObterGeneros, nomeListaGeneros, viewAdicionarJogo);
        },

        _obterIdJogoPelaRota(evento) {
            const idJogo = evento.getParameters().arguments.jogoId;

            return idJogo;
        },

        _colocarValorNoInput: function (jogo) {
            this.getView().byId(inputNomeId).setValue(jogo.nome);
            this.getView().byId(inputPrecoId).setValue(jogo.preco);
            this.getView().byId(selectGeneroId).setValue(jogo.genero);
        },

        _limparCampos: function (inputNomeId, inputPrecoId, selectGeneroId, valueState) {
            this.getView().byId(inputNomeId).setValue("");
            this.getView().byId(inputNomeId).setValueState(valueState);

            this.getView().byId(inputPrecoId).setValue();
            this.getView().byId(inputPrecoId).setValueState(valueState);
            
            this.getView().byId(selectGeneroId).setSelectedItemId();
            this.getView().byId(selectGeneroId).setValueState(valueState);
        },

        _fazerRequisicaoObterPorId: function (url, view) {
            fetch(url)
                .then(respostaApi => {
                    if(!respostaApi.ok) {
                        respostaApi.json()
                            .then(respostaApi => {
                                this.validacao.mostrarMensagemDeErro(respostaApi, view);
                            });
                    }
                    return respostaApi.json();
                })
                .then(respostaApi => {
                    let jogo = respostaApi;
                    this._colocarValorNoInput(jogo);
                });
        },

        _pegarValorDosCampos: function () {
            const generoNaoDefinido = "NAODEFINIDO";

            let valorInputNome = this.getView().byId(inputNomeId).getValue();
            let valorInputPreco = this.getView().byId(inputPrecoId).getValue();
            let valorSelectGenero = parseInt(this.getView().byId(selectGeneroId).getSelectedKey());

            let jogo = {};

            if (valorInputNome)
                jogo.nome = valorInputNome;

            if (valorInputPreco)
                jogo.preco = valorInputPreco;

            if (valorSelectGenero != generoNaoDefinido)
                jogo.genero = valorSelectGenero;

            return jogo;
        },

        _voltarParaTelaDeListagem: function () {
            this.getRouter().navTo("appJogo", {}, true);
        },

        salvarJogo: function () {
            const jogo = this._pegarValorDosCampos();
            const urlAdicionarJogo = "/api/JogoControlador";
            const viewAdicionarJogo = this.getView();
            this.validacao.validarTela(jogo, viewAdicionarJogo);
            
            if (jogo.nome && jogo.preco && jogo.genero) {
                const opcoes = {
                    method: 'POST',
                    body: JSON.stringify(jogo),
                    headers: {
                        "Content-type": "application/json; charset=UTF-8"
                    }
                };
                this.fazerRequisicaoPost(urlAdicionarJogo, opcoes, jogo.nome, viewAdicionarJogo);
                
            }
        },

        cancelarAdicaoDeJogo: function () {
            this._voltarParaTelaDeListagem();
        }
    });
});