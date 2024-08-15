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
         var urlObterTodos = `/api/JogoControlador?Nome=${valorFiltroNome}&PrecoMin=${valorFiltroPrecoMin}&PrecoMax=${valorFiltroPrecoMax}&Genero=${valorFiltroGenero}`;

         fetch(urlObterTodos).then(jogos => jogos.json()).then(jogos => {
            const dataModel = new JSONModel();

            dataModel.setData(jogos);

            this.getView().setModel(dataModel, "listaJogos");
         });
      },

      _mostrarMensagemDeErro: function (erro) {
         const tituloMessageBox = "Erro";
         const detalhesMessageBox = "Detalhes";
         const statusMessageBox = "Status"

         MessageBox.error(`${erro.Title}`, {
            title: tituloMessageBox,
            id: "messageBoxErro",
            details: 
               `<p><strong>${statusMessageBox}:<strong> ${erro.Status}` +
               `<p><strong>${detalhesMessageBox}<strong>` +
               `<p>${erro.Detail}`,
            styleClass: "sResponsivePaddingClasses",
            dependentOn: this.getView()
         });
      },

      atualizarTitulo: function (oEvent) {
         var tabelaJogoTitulo,
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