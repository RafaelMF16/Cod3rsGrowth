sap.ui.define([
	'sap/ui/core/mvc/Controller',
	'sap/ui/core/UIComponent',
	'sap/ui/model/json/JSONModel',
	'sap/m/MessageBox',
	'ui5/codersgrowth/app/servicos/validacao',
	'sap/m/Dialog',
    'sap/m/Button',
    'sap/m/library',
    'sap/m/Text',
    'sap/ui/core/library',
	'ui5/codersgrowth/common/ConstantesDaRota',
	'sap/ui/core/BusyIndicator'
], function(Controller, UIComponent, JSONModel, MessageBox, validacao, Dialog, Button, mobileLibrary, Text, coreLibrary, ConstantesDaRota, BusyIndicator) {
	"use strict";

	const NOME_MODELO_JOGOS = "jogos";
	const NOME_MODELO_GENEROS = "generos";
	
	return Controller.extend("ui5.codersgrowth.app.BaseController", {
		validacao: validacao,
		nomeModeloJogos: NOME_MODELO_JOGOS,
		nomeModeloGeneros: NOME_MODELO_GENEROS,
		
		getRouter : function () {
			return UIComponent.getRouterFor(this);
		},

		_mostrarMensagemDeSucesso: function (mensagemDeSucesso, idJogo) {
			const rotaListagemJogo = "appListagemJogo";

            MessageBox.success(mensagemDeSucesso, {
                id: "messageBoxSucesso",
                styleClass: "sResponsivePaddingClasses",
                dependentOn: this.getView(),
                actions: [MessageBox.Action.OK],
                onClose: (sAction) => {
                    if (sAction === MessageBox.Action.OK) {
						!!idJogo 
							? this.navegarPara(ConstantesDaRota.NOME_DA_ROTA_DE_DETALHE, idJogo)
							: this.navegarPara(ConstantesDaRota.NOME_DA_ROTA_DA_LISTAGEM_DE_JOGOS)
                    }
                }
             });
        },

		navegarPara:function (rota, idJogo) {
			!!idJogo
				? this.getRouter().navTo(rota, {
					idJogo: idJogo
				}, true)
				: this.getRouter().navTo(rota, {}, true);
		},

		debounce: function (funcao, tempoDeEspera){
			let timeout;

			return function(...args){
				const contexto = this;
				clearTimeout(timeout);

				timeout = setTimeout(() => funcao.apply(contexto, args), tempoDeEspera);
			}
		},

		modelo: function (nome, modelo) {
			let view = this.getView();
			if (modelo) view.setModel(modelo, nome);
			return view.getModel(nome);
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

		mostrarMensagemDeAviso: function(view, propriedadesI18n, mensagemDeAviso, idJogo, nomeJogo){
            const url = `/api/JogoControlador/${idJogo}`;
                this.mensagemDeAviso = new Dialog({
                    type: mobileLibrary.DialogType.Message,
                    title: propriedadesI18n.getText("tituloMessageBoxAtencao"),
                    state: coreLibrary.ValueState.Warning,
                    content: new Text({ text: mensagemDeAviso }),
                    beginButton: new Button({
                        type: mobileLibrary.ButtonType.Negative,
                        text: propriedadesI18n.getText("textoBotaoSimMessageBoxAtencao"),
                        press: function () {
                        	this.mensagemDeAviso.close();

							if (!!nomeJogo){
								this.fazerRequisicaoDelete(url, nomeJogo, view);
							}
							else if (!!idJogo){
								this.navegarPara(ConstantesDaRota.NOME_DA_ROTA_DE_DETALHE, idJogo);
							}
                        	else {
								this.navegarPara(ConstantesDaRota.NOME_DA_ROTA_DA_LISTAGEM_DE_JOGOS)
							}
                        }.bind(this)
                    }),
                    endButton: new Button({
                        type: mobileLibrary.ButtonType.Success,
                        text: propriedadesI18n.getText("textoBotaoNaoMessageBoxAtencao"),
                        press: function () {
                            this.mensagemDeAviso.close();
                        }.bind(this)
                    })
                });
            this.mensagemDeAviso.open();
         },

		 exibirEspera: function (action) {
			const delay = 0;
			const timeout = 500;
			
			BusyIndicator.show(delay);
		
			return Promise.all([
				Promise.resolve(action()),                
				new Promise(resolve => setTimeout(resolve, timeout)) 
			])
			.then(([result]) => {
				BusyIndicator.hide(); 
				return result; 
			})
			.catch((error) => {
				BusyIndicator.hide(); 
				throw error; 
			});
		}
	});
});