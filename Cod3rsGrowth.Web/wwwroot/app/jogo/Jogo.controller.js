sap.ui.define([
   "ui5/codersgrowth/app/BaseController",
   "sap/ui/model/json/JSONModel",
   "../model/formatter",
   "sap/m/MessageBox"
], (BaseController, JSONModel, formatter, MessageBox) => {
   "use strict";

   var valorFiltroNome = "";
   var valorFiltroPrecoMin = "";
   var valorFiltroPrecoMax = "";
   var valorFiltroGenero = "";

   return BaseController.extend("ui5.codersgrowth.app.jogo.Jogo", {
      formatter: formatter,

      onInit: function () {
         const urlObterTodos = "/api/JogoControlador";
         const urlObterGeneros = "/api/GeneroControlador";
         const nomeListaJogos = "listaJogos";
         const nomeListaGeneros = "listaGeneros";
         
         this.fazerRequisicaoGet(urlObterTodos, nomeListaJogos);

         this.fazerRequisicaoGet(urlObterGeneros, nomeListaGeneros);
      },

      pegarValorDoSelect: function (oEvent) {
         valorFiltroGenero = oEvent.getSource().getSelectedKey();

         this._filtrarJogos();
      },

      pegarValorDoCampoDePesquisa: function (oEvent) {
         valorFiltroNome = oEvent.getSource().getValue();
         
         this._filtrarJogos();
      },

      pegarValorDoCampoPrecoMin: function (oEvent) {
         valorFiltroPrecoMin = oEvent.getSource().getValue();
         
         this._filtrarJogos();
      },

      pegarValorDoCampoPrecoMax: function (oEvent) {
         valorFiltroPrecoMax = oEvent.getSource().getValue();

         this._filtrarJogos();
      },

      _filtrarJogos: function () {
         const nomeListaJogos = "listaJogos";
         let query = {};

         if (valorFiltroNome)
            query.nome = valorFiltroNome;

         if (valorFiltroGenero)
            query.genero = valorFiltroGenero;

         if (valorFiltroPrecoMin)
            query.precoMin = valorFiltroPrecoMin;

         if (valorFiltroPrecoMax)
            query.precoMax = valorFiltroPrecoMax;

         let urlObterTodosComFiltros = `/api/JogoControlador?` + new URLSearchParams(query);

         this.fazerRequisicaoGet(urlObterTodosComFiltros, nomeListaJogos);
      },

      atualizarTitulo: function (oEvent) {
         let tabelaJogoTitulo,
				tabelaJogo = oEvent.getSource(),
				itemsDaTabelaJogo = oEvent.getParameter("total");
            const propriedadesI18n = this.getView().getModel("i18n").getResourceBundle();
			if (itemsDaTabelaJogo && tabelaJogo.getBinding("items").isLengthFinal()) {
				tabelaJogoTitulo = propriedadesI18n.getText("contadorDeItemsTitulo", [itemsDaTabelaJogo]);
			} else {
				tabelaJogoTitulo = propriedadesI18n.getText("tabelaJogoTitulo");
			}
         this.getView().byId("idTabelaJogoTitulo").setProperty("text", tabelaJogoTitulo);
      },

      aoClicarIrParaTelaDeAdicionarJogo: function () {
         this.getRouter().navTo("appAdicionarJogo", {}, true);
      }
   });
});