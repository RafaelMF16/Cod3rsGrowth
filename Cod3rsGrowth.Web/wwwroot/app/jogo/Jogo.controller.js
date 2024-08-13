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
         const urlObterGenero = "/api/GeneroControlador";
         const statusOk = 200;

         fetch(urlObterTodos)
            .then(respostaApi => {
               if (!respostaApi.ok){
                  this.mostrarMensagemDeErro(respostaApi.json());
               }
               return respostaApi.json();
            })
            .then(respostaApi => {
               const dataModel = new JSONModel();
               dataModel.setData(respostaApi);
                  
               this.getView().setModel(dataModel, "listaJogos")
            })
         
         // fetch(urlObterTodos)
         //    .then(function (respostaApi) {
         //       if (!respostaApi.ok) {
         //          this.mostrarMensagemDeErro(respostaApi);
         //       }
         //       return respostaApi.json();
         //    })
         //    .then(function (jogos) {
         //       debugger;
         //       const dataModel = new JSONModel();
         //       dataModel.setData(jogos);
                  
         //       setModel(dataModel, "listaJogos")
         //    })
         
         fetch(urlObterGenero)
            .then(respostaApi => respostaApi.json())
            .then(respostaApi => {
               if (respostaApi.Status && respostaApi.Status !== statusOk) {
                  this.mostrarMensagemDeErro(respostaApi);
               }
               else {
                  const dataModel = new JSONModel();
                  dataModel.setData(respostaApi);
                  
                  this.getView().setModel(dataModel, "listaGenero")
               }
            })
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
         var urlObterTodos = `/api/JogoControlador?Nome=${valorFiltroNome}&PrecoMin=${valorFiltroPrecoMin}&PrecoMax=${valorFiltroPrecoMax}&Genero=${valorFiltroGenero}`;

         fetch(urlObterTodos).then(jogos => jogos.json()).then(jogos => {
            const dataModel = new JSONModel();

            dataModel.setData(jogos);

            this.getView().setModel(dataModel, "listaJogos");
         });
      },

      mostrarMensagemDeErro: function (erro) {
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
      }
   });
});