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

        _aoCoincidirRota: function () {
            const urlObterGeneros = "/api/GeneroControlador";
            const nomeListaGeneros = "listaGeneros";
            const valueStatePadrao = "None";

            this.fazerRequisicaoGet(urlObterGeneros, nomeListaGeneros);

            this.getView().byId(inputNomeId).setValue("");
            this.getView().byId(inputNomeId).setValueState(valueStatePadrao);

            this.getView().byId(inputPrecoId).setValue();
            this.getView().byId(inputPrecoId).setValueState(valueStatePadrao);

            this.getView().byId(selectGeneroId).setSelectedKey();
            this.getView().byId(selectGeneroId).setValueState(valueStatePadrao);
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