sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
	"sap/ui/core/UIComponent",
	"sap/ui/model/json/JSONModel",
	"sap/m/MessageBox",
	"ui5/codersgrowth/app/servicos/validacao",
	'sap/m/Dialog',
    'sap/m/Button',
    'sap/m/library',
    'sap/m/Text',
    'sap/ui/core/library'
], function(Controller, History, UIComponent, JSONModel, MessageBox, validacao, Dialog, Button, mobileLibrary, Text, coreLibrary) {
	"use strict";
	
	return Controller.extend("ui5.codersgrowth.app.BaseController", {
		validacao: validacao,
		
		getRouter : function () {
			return UIComponent.getRouterFor(this);
		},

		_mostrarMensagemDeSucesso: function (mensagemDeSucesso, idJogo) {
            MessageBox.success(mensagemDeSucesso, {
                id: "messageBoxSucesso",
                styleClass: "sResponsivePaddingClasses",
                dependentOn: this.getView(),
                actions: [MessageBox.Action.OK],
                onClose: (sAction) => {
                    if (sAction === MessageBox.Action.OK) {
						!!idJogo 
							? this.navegarPara(idJogo)
							: this.navegarPara()
                    }
                }
             });
        },

		navegarPara: function (idJogo) {
			const rotaDetalhes = "appDetalhesJogo";
			const rotaListagem = "appListagemJogo";

			!!idJogo
				? this.getRouter().navTo(rotaDetalhes, {jogoId: idJogo}, true)
				: this.getRouter().navTo(rotaListagem, {}, true)
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

		fazerRequisicaoPostOuPatch: function (url, opcoes, jogo, view) {
			const mensagemDeSucessoRequisicaoPostOuPatch = `${jogo.nome} foi salvo com sucesso`;
			
			fetch(url, opcoes)
			   .then(respostaApi => {
					if (!respostaApi.ok) {
						respostaApi.json()
							.then(respostaApi => {
						   		this.validacao.mostrarMensagemDeErro(respostaApi, view)
							});
					}
					else {
						!!jogo.id
							? this._mostrarMensagemDeSucesso(mensagemDeSucessoRequisicaoPostOuPatch, jogo.id)
							: respostaApi.json().then(respostaApi => 
								this._mostrarMensagemDeSucesso(mensagemDeSucessoRequisicaoPostOuPatch, respostaApi.id))
					}
				})
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
					const jogo = respostaApi;
					this.colocarValorNoInput(jogo);
                });
        },

		fazerRequisicaoDelete: function (url, jogoNome, view) {
			const mensagemDeSucessoRequisicaoDelete = `${jogoNome} foi deletado com sucesso`
			const opcoes = {
                method: 'DELETE',
                headers: {
                    "Content-type": "application/json; charset=UTF-8"
                }
            };

			fetch(url, opcoes)
				.then(respostaApi => { 
					return !respostaApi.ok
						? respostaApi.json().then(respostaApi => this.validacao.mostrarMensagemDeErro(respostaApi, view))
						: this._mostrarMensagemDeSucesso(mensagemDeSucessoRequisicaoDelete);
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
				this.getRouter().navTo("appListagemJogo", {}, true);
			}
		},

		mostrarMensagemDeAviso: function(view, propriedadesI18n, mensagemDeAviso, idJogo, nomeJogo){
            const url = `/api/JogoControlador/${idJogo}`;
                this.mensagemDeCancelarEmpresa = new Dialog({
                    type: mobileLibrary.DialogType.Message,
                    title: propriedadesI18n.getText("tituloMessageBoxAtencao"),
                    state: coreLibrary.ValueState.Warning,
                    content: new Text({ text: mensagemDeAviso }),
                    beginButton: new Button({
                        type: mobileLibrary.ButtonType.Negative,
                        text: propriedadesI18n.getText("textoBotaoSimMessageBoxAtencao"),
                        press: function () {
                        	this.mensagemDeCancelarEmpresa.close();
                        	!!nomeJogo
								? this.fazerRequisicaoDelete(url, nomeJogo, view)
								: this.navegarPara(idJogo);
                        }.bind(this)
                    }),
                    endButton: new Button({
                        type: mobileLibrary.ButtonType.Success,
                        text: propriedadesI18n.getText("textoBotaoNaoMessageBoxAtencao"),
                        press: function () {
                            this.mensagemDeCancelarEmpresa.close();
                        }.bind(this)
                    })
                });
            this.mensagemDeCancelarEmpresa.open();
         }
	});
});