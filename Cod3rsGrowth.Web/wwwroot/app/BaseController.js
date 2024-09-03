sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
	"sap/ui/core/UIComponent",
	'sap/ui/model/json/JSONModel',
	"sap/m/MessageBox",
	"ui5/codersgrowth/app/servicos/validacao"
], function(Controller, History, UIComponent, JSONModel, MessageBox, validacao) {
	"use strict";
	
	return Controller.extend("ui5.codersgrowth.app.BaseController", {
		validacao: validacao,
		
		getRouter : function () {
			return UIComponent.getRouterFor(this);
		},

		_mostrarMensagemDeSucesso: function (jogoNome) {
            const mensagemDeSucesso = `${jogoNome} foi salvo com sucesso`
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

		fazerRequisicaoGet: function (url, nomeLista, view) {
			fetch(url)
			   .then(respostaApi => {
					if (!respostaApi.ok) {
						respostaApi.json()
							.then(respostaApi => {
						   		this.validacao.mostrarMensagemDeErro(respostaApi, view)
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

		fazerRequisicaoPostOuPatch: function (url, opcoes, jogoNome, view) {
			fetch(url, opcoes)
				.then(respostaApi => { 
					return !respostaApi.ok? respostaApi.json().then(respostaApi => {
						this.validacao.mostrarMensagemDeErro(respostaApi, view)
					}) : this._mostrarMensagemDeSucesso(jogoNome);
				});
		},

		fazerRequisicaoObterPorId: function (url, view) {
            fetch(url)
                .then(respostaApi => {
                    if(!respostaApi.ok) {
                        respostaApi.json()
                            .then(respostaApi => {
                                this.validacao.mostrarMensagemDeErro(respostaApi, view);
                            });
                    }
                    return respostaApi.json();
                })
                .then(respostaApi => {
                    let jogo = respostaApi;
                    this._colocarValorNoInput(jogo);
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
		}
	});
});