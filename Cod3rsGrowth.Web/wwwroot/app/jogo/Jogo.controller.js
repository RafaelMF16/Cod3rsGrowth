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
         
         this._fazerRequisicaoGet(urlObterTodos, nomeListaJogos);

         this._fazerRequisicaoGet(urlObterGeneros, nomeListaGeneros);
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

         let urlObterTodos = `/api/JogoControlador?` + new URLSearchParams(query);

         this._fazerRequisicaoGet(urlObterTodos, nomeListaJogos);
      },

      _mostrarMensagemDeErro: function (erro) {
         const propriedadesI18n = this.getView().getModel("i18n").getResourceBundle();

         MessageBox.error(`${erro.Title}`, {
            title: propriedadesI18n.getText("tituloMessageBox"),
            id: "messageBoxErro",
            details: 
               `<p><strong>${propriedadesI18n.getText("statusMessageBox")}:<strong> ${erro.Status}` +
               `<p><strong>${propriedadesI18n.getText("detalhesMessageBox")}<strong>` +
               `<p>${erro.Detail}`,
            styleClass: "sResponsivePaddingClasses",
            dependentOn: this.getView()
         });
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

      _fazerRequisicaoGet: function (url, nomeLista) {
         const delayDoBusyIndicator = 0;

         this.getView().setBusyIndicatorDelay(delayDoBusyIndicator);
         this.getView().setBusy(true);

         fetch(url)
            .then(respostaApi => {
               if (!respostaApi.ok) {
                  respostaApi.json()
                     .then(respostaApi => {
                        this._mostrarMensagemDeErro(respostaApi)
                     });
               }
               return respostaApi.json();
            })
            .then(respostaApi => {
               const dataModel = new JSONModel();
               dataModel.setData(respostaApi);
                  
               this.getView().setModel(dataModel, nomeLista);

               this.getView().setBusy(false);
            });
      },

      alternarTema: function (oEvent) {
         const temaEscolhido = oEvent.getSource().getText();
         const modoClaro = "Claro";
         const modoEscuro = "Escuro";
         const nomeModoEscuro = "sap_horizon";
         const nomeModoClaro = "sap_horizon_dark";

         if (temaEscolhido === modoClaro)
            sap.ui.getCore().applyTheme(nomeModoEscuro);
         else if (temaEscolhido === modoEscuro) 
            sap.ui.getCore().applyTheme(nomeModoClaro);
      }
   });
});