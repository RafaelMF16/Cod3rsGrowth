sap.ui.define([
   "ui5/codersgrowth/controller/BaseController",
   "sap/ui/model/json/JSONModel",
], (BaseController, JSONModel) => {
   "use strict";

   return BaseController.extend("ui5.codersgrowth.controller.Jogo", {
      onInit: function () {
         const urlObterTodos = "api/JogoControlador";

         fetch(urlObterTodos).then(jogos => jogos.json()).then(jogos => {
            const dataModel = new JSONModel();
            dataModel.setData(jogos);
            
            this.getView().setModel(dataModel, "listaJogos")
         });
      },

      onFiltrarJogos: function (oEvent) {
         let urlObterTodosComFiltroNome = "api/JogoControlador?Nome=";
         const sQuery = oEvent.getSource().getValue();

         urlObterTodosComFiltroNome = urlObterTodosComFiltroNome + sQuery;

         if (sQuery) {
            fetch(urlObterTodosComFiltroNome).then(jogos => jogos.json()).then(jogos => {
               const dataModel = new JSONModel();

               dataModel.setData(jogos);

               this.getView().setModel(dataModel, "listaJogos");
            });
         } 
         else {
            const urlObterTodos = "api/JogoControlador";

            fetch(urlObterTodos).then(jogos => jogos.json()).then(jogos => {
               const dataModel = new JSONModel();
               dataModel.setData(jogos);
               
               this.getView().setModel(dataModel, "listaJogos")
            });
         }
      },

      async onAbrirDialogo() {
         this.oDialog ??= await this.loadFragment({
            name: "ui5.codersgrowth.view.Jogo"
        });

        this.oDialog.open();
      }
   });
});