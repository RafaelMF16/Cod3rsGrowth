sap.ui.define([
    'ui5/codersgrowth/app/BaseController',
    '../model/formatter',
    '../servicos/validacao'
], function(BaseController, formatter, validacao) {
    'use strict';

    const inputNomeId = "idInputNome";
    const inputPrecoId = "idInputPreco";
    const selectGeneroId = "idSelectGenero";
    const tituloPaginaAdicionarOuEditar = "idTituloPaginaAdicionar";
    var idJogo = "";
    
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
            const viewAdicionarJogo = this.getView();
            const tituloPaginaEditar = "Editar Jogo";
            const titutloPaginaAdicionar = "Adicionar Jogo";

            this._obterIdJogoPelaRota(oEvent);

            this.fazerRequisicaoGet(urlObterGeneros, nomeListaGeneros, viewAdicionarJogo);
            
            if (idJogo){
                const urlObterPorId = `/api/JogoControlador/${idJogo}`;

                this._mudarTituloDaPagina(tituloPaginaEditar);
                this._limparValueState(valueStatePadrao);
                this.fazerRequisicaoObterPorId(urlObterPorId, viewAdicionarJogo);
            } else {
                this._mudarTituloDaPagina(titutloPaginaAdicionar);
                this._limparCampos(inputNomeId, inputPrecoId, selectGeneroId);
                this._limparValueState(valueStatePadrao);
            }
        },

        _obterIdJogoPelaRota(evento) {
            idJogo = evento.getParameters().arguments.jogoId;
        },

        _colocarValorNoInput: function (jogo) {
            const generos = this.getView().byId(selectGeneroId).getItems();
            const generoQueVaiSerSelecionadoNoSelect = generos.find(genero => genero.mProperties.text === jogo.genero);
            
            this.getView().byId(inputNomeId).setValue(jogo.nome);
            this.getView().byId(inputPrecoId).setValue(jogo.preco);
            this.getView().byId(selectGeneroId).setSelectedItem(generoQueVaiSerSelecionadoNoSelect);
        },

        _limparCampos: function (inputNomeId, inputPrecoId, selectGeneroId) {
            this.getView().byId(inputNomeId).setValue("");
            this.getView().byId(inputPrecoId).setValue();
            this.getView().byId(selectGeneroId).setSelectedKey();
        },

        _limparValueState: function (valueState) {
            this.getView().byId(inputNomeId).setValueState(valueState);
            this.getView().byId(inputPrecoId).setValueState(valueState);
            this.getView().byId(selectGeneroId).setValueState(valueState);
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

            if (idJogo)
                jogo.id = idJogo;

            return jogo;
        },

        _voltarParaTelaDeListagem: function () {
            this.getRouter().navTo("appJogo", {}, true);
        },

        _mudarTituloDaPagina: function (titulo) {
            
            this.getView().byId(tituloPaginaAdicionarOuEditar).setText(titulo)
        },

        salvarJogo: function () {
            const jogo = this._pegarValorDosCampos();
            const urlAdicionarOuAtualizarJogo = "/api/JogoControlador";
            const viewAdicionarJogo = this.getView();
            const opcoes = {
                method: 'POST',
                body: JSON.stringify(jogo),
                headers: {
                    "Content-type": "application/json; charset=UTF-8"
                }
            };
            
            if (idJogo) {
                opcoes.method = 'PATCH'
            }

            if (this.validacao.validarTela(jogo, viewAdicionarJogo))
                this.fazerRequisicaoPostOuPatch(urlAdicionarOuAtualizarJogo, opcoes, jogo.nome, viewAdicionarJogo);
        },

        cancelarAdicaoDeJogo: function () {
            this._voltarParaTelaDeListagem();
        }
    });
});