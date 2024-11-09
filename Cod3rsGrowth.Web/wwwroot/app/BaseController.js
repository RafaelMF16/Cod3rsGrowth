sap.ui.define([
	'sap/ui/core/mvc/Controller',
	'sap/ui/core/UIComponent',
	'sap/ui/model/json/JSONModel',
	'sap/m/MessageBox',
	'ui5/codersgrowth/app/servicos/validacao',
	'ui5/codersgrowth/common/ConstantesDaRota',
	'sap/ui/core/BusyIndicator',
	'./repositorio/RepositorioJogo'
], function(
	Controller, 
	UIComponent, 
	JSONModel, 
	MessageBox, 
	validacao,  
	ConstantesDaRota, 
	BusyIndicator,
	Repositorio
) {
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

		modeloGeneros: function (jsonModel) {
			const nomeModeloGeneros = "generos";

			return this.modelo(nomeModeloGeneros, jsonModel);
		},

		carregarGeneros: async function () {
			const view = this.getView();
			let dados = await Repositorio.obterTodosGeneros(view);

			this.modeloGeneros(new JSONModel(dados));
		},

		navegarPara:function (rota, idJogo) {
			!!idJogo
				? this.getRouter().navTo(rota, {
					idJogo: idJogo
				}, true)
				: this.getRouter().navTo(rota, {}, true);
		},
		
		modeloJogo: function (jsonModel) {
            const nomeModeloJogo = "jogo";

            return this.modelo(nomeModeloJogo, jsonModel);
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

		mostrarMensagemDeAviso: function(view, idJogo){
			const propriedadesI18n = view.getModel("i18n").getResourceBundle();
			const mensagemDeAviso = propriedadesI18n.getText("MessageBox.Aviso.TemCertezaQueDesejaCancelar");

			MessageBox.warning(mensagemDeAviso, {
				icon: MessageBox.Icon.WARNING,
                title: propriedadesI18n.getText("MessageBox.Aviso.Titulo"),
                id: "messageBoxAviso",
				actions: [sap.m.MessageBox.Action.YES, sap.m.MessageBox.Action.NO],
				emphasizedAction: MessageBox.Action.YES,
                styleClass: "sResponsivePaddingClasses",
				onClose: (sAction) => {
					if (sAction === sap.m.MessageBox.Action.YES) {
						!!idJogo
							? this.navegarPara(ConstantesDaRota.NOME_DA_ROTA_DE_DETALHE, idJogo)
							: this.navegarPara(ConstantesDaRota.NOME_DA_ROTA_DA_LISTAGEM_DE_JOGOS);
					}
				},
                dependentOn: view
            });
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