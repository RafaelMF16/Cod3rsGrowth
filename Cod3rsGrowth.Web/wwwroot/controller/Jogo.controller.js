sap.ui.define([
   "ui5/codersgrowth/controller/BaseController",
   "sap/ui/model/json/JSONModel",
   "../model/formatter"
], (BaseController, JSONModel, formatter) => {
   "use strict";

   var valorFiltroNome = "";
   var valorFiltroPrecoMin = "";
   var valorFiltroPrecoMax = "";
   var valorFiltroGenero = "";

   return BaseController.extend("ui5.codersgrowth.controller.Jogo", {
      formatter: formatter,

      onInit: function () {
         const urlObterTodos = "api/JogoControlador";
         const urlObterGenero = "api/GeneroControlador";

         fetch(urlObterTodos).then(jogos => jogos.json()).then(jogos => {
            const dataModel = new JSONModel();
            dataModel.setData(jogos);
            
            this.getView().setModel(dataModel, "listaJogos")
         });

         fetch(urlObterGenero).then(generos => generos.json()).then(generos => {
            const dataModel = new JSONModel();
            dataModel.setData(generos);
            
            this.getView().setModel(dataModel, "listaGenero")
         });
      },

      pegarValorComboBox: function (oEvent) {
         valorFiltroGenero = oEvent.getSource().getSelectedKey();

         this.filtrarJogos();
      },

      pegarValorDoCampoDePesquisa: function (oEvent) {
         valorFiltroNome = oEvent.getSource().getValue();
         
         this.filtrarJogos();
      },

      pegarValorDoCampoPrecoMin: function (oEvent) {
         valorFiltroPrecoMin = oEvent.getSource().getValue();
         
         this.filtrarJogos();
      },

      pegarValorDoCampoPrecoMax: function (oEvent) {
         valorFiltroPrecoMax = oEvent.getSource().getValue();

         this.filtrarJogos();
      },

      filtrarJogos: function () {
         var urlObterTodos = `api/JogoControlador?Nome=${valorFiltroNome}&PrecoMin=${valorFiltroPrecoMin}&PrecoMax=${valorFiltroPrecoMax}&Genero=${valorFiltroGenero}`;

         fetch(urlObterTodos).then(jogos => jogos.json()).then(jogos => {
            const dataModel = new JSONModel();

            dataModel.setData(jogos);

            this.getView().setModel(dataModel, "listaJogos");
         });
      }
   });
});