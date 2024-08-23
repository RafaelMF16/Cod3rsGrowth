sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
	"sap/ui/core/UIComponent",
	'sap/ui/model/json/JSONModel',
	"sap/m/MessageBox"
], function(Controller, History, UIComponent, JSONModel, MessageBox) {
	"use strict";

	return Controller.extend("ui5.codersgrowth.app.BaseController", {
		getRouter : function () {
			return UIComponent.getRouterFor(this);
		},

		_mostrarMensagemDeSucesso: function (jogoNome) {
            const mensagemDeSucesso = `${jogoNome} foi adicionado com sucesso`
            MessageBox.success(mensagemDeSucesso, {
                id: "messageBoxSucesso",
                styleClass: "sResponsivePaddingClasses",
                dependentOn: this.getView(),
                actions: [MessageBox.Action.OK],
                onClose: (sAction) => {
                    if (sAction === MessageBox.Action.OK) {
                        this._voltarParaTelaDeListagem();
                    }
                }
             });
        },

		_mostrarMensagemDeErro: function (erro) {
			const propriedadesI18n = this.getView().getModel("i18n").getResourceBundle();
			const erroDeValidacao = "Erro de validação"

			if (erro.Title === erroDeValidacao){
				const mensagensDeErro = Object.values(erro.Extensions.ErroDeValidacao).join("\r \n");

				MessageBox.error(`${erro.Title} \n \n ${mensagensDeErro}`, {
					title: propriedadesI18n.getText("tituloMessageBoxErro"),
					id: "messageBoxErroDeValidacao",
					details: 
						  `<p><strong>${propriedadesI18n.getText("statusMessageBoxErro")}:<strong> ${erro.Status}` +
						   `<p><strong>${propriedadesI18n.getText("detalhesMessageBoxErro")}<strong>` +
						   `<p>${erro.Detail}`,
					styleClass: "sResponsivePaddingClasses",
					dependentOn: this.getView()
				 });
			}
			else {
				MessageBox.error(`${erro.Title}`, {
					title: propriedadesI18n.getText("tituloMessageBoxErro"),
					id: "messageBoxErroInesperado",
					details: 
						  `<p><strong>${propriedadesI18n.getText("statusMessageBoxErro")}:<strong> ${erro.Status}` +
						   `<p><strong>${propriedadesI18n.getText("detalhesMessageBoxErro")}<strong>` +
						   `<p>${erro.Detail}`,
					styleClass: "sResponsivePaddingClasses",
					dependentOn: this.getView()
				 });
			}
		},

		fazerRequisicaoGet: function (url, nomeLista) {
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
				});
		},

		fazerRequisicaoPost: function (url, opcoes, jogoNome) {
			fetch(url, opcoes)
				.then(respostaApi => { 
					return !respostaApi.ok? respostaApi.json().then(respostaApi => {
						this._mostrarMensagemDeErro(respostaApi)
					}) : this._mostrarMensagemDeSucesso(jogoNome);
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
	});
});