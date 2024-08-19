sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
	"sap/ui/core/UIComponent",
	'sap/ui/model/json/JSONModel'
], function(Controller, History, UIComponent, JSONModel) {
	"use strict";

	return Controller.extend("ui5.codersgrowth.app.BaseController", {

		getRouter : function () {
			return UIComponent.getRouterFor(this);
		},

		onNavBack: function () {
			var oHistory, sPreviousHash;

			oHistory = History.getInstance();
			sPreviousHash = oHistory.getPreviousHash();

			if (sPreviousHash !== undefined) {
				window.history.go(-1);
			} else {
				this.getRouter().navTo("appJogo", {}, true);
			}
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

		 fazerRequisicaoGet: function (url, nomeLista) {
			fetch(url)
			   .then(respostaApi => {
				  if (!respostaApi.ok) {
					debugger;
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
			   });
		 }
	});
});