sap.ui.define([
    'ui5/codersgrowth/app/BaseController',
    'sap/ui/model/json/JSONModel'
], function(BaseController, JSONModel) {
    'use strict';
    
    return BaseController.extend("ui5.codersgrowth.app.adicionarJogo.AdicionarJogo",{

        onInit: function () {
            this.getRouter().getRoute("appAdicionarJogo").attachMatched(this._aoCoincidirRota, this);
        },

        _aoCoincidirRota: function () {
            const urlObterGeneros = "/api/GeneroControlador";
            const nomeListaGeneros = "listaGeneros";

            this.fazerRequisicaoGet(urlObterGeneros, nomeListaGeneros);
        },

        pegarValorDosCampos: function () {
            const inputNomeId = "idInputNome";
            const inputPrecoId = "idInputPreco";
            const selectGeneroId = "idSelectGenero";

            let valorInputNome = this.getView().byId(inputNomeId).getValue();
            let valorInputPreco = this.getView().byId(inputPrecoId).getValue();
            let valorSelectGenero = this.getView().byId(selectGeneroId).getSelectedKey();

            let valorDosCampos = [valorInputNome, valorInputPreco, valorSelectGenero];
        },

        salvar: function () {
            this.pegarValorDosCampos();
        }
    });
});