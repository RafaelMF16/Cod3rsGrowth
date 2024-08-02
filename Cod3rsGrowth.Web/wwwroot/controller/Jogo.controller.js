sap.ui.define([
   "ui5/codersgrowth/controller/BaseController",
   "sap/ui/model/json/JSONModel",
   "../model/formatter"
], (BaseController, JSONModel, formatter) => {
   "use strict";

   let valorFiltroNome = "";
   let valorFiltroPrecoMin = "";
   let valorFiltroPrecoMax = "";
   let valorFiltroGenero = "";

   return BaseController.extend("ui5.codersgrowth.controller.Jogo", {
      formatter: formatter,

      onInit: function () {
         const urlObterTodos = "api/JogoControlador";

         fetch(urlObterTodos).then(jogos => jogos.json()).then(jogos => {
            const dataModel = new JSONModel();
            dataModel.setData(jogos);
            
            this.getView().setModel(dataModel, "listaJogos")
         });
      },

      pegarValorDoCampoDePesquisa: function (oEvent) {
         valorFiltroNome = oEvent.getSource().getValue();
         
         this.filtrarJogos();
      },

      pegarValorDoCampoPrecoMin: function (oEvent) {
         valorFiltroPrecoMin = oEvent.getSource().getValue();
      },

      pegarValorDoCampoPrecoMax: function (oEvent) {
         valorFiltroPrecoMax = oEvent.getSource().getValue();
      },

      filtrarJogos: function () {
         let urlObterTodos = `api/JogoControlador?Nome=${valorFiltroNome}&PrecoMin=${valorFiltroPrecoMin}&PrecoMax=${valorFiltroPrecoMax}&Genero=${valorFiltroGenero}`;

         fetch(urlObterTodos).then(jogos => jogos.json()).then(jogos => {
            const dataModel = new JSONModel();

            dataModel.setData(jogos);

            this.getView().setModel(dataModel, "listaJogos");
         });
      },

      async abrirFiltroDialog() {
         this.oDialog ??= await this.loadFragment({
            name: "ui5.codersgrowth.view.FiltroDialog"
        });

        this.oDialog.open();
      },

      apertarFiltrarFiltroDialog: function () {
         this.filtrarJogos();

         this.oDialog.close();
      },

      apertarFecharFiltroDialog: function () {
         this.oDialog.close();
      },
   });
});