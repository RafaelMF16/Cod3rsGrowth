sap.ui.define([
    'ui5/codersgrowth/app/BaseController',
    '../model/formatter',
    'ui5/codersgrowth/app/servicos/validacao',
    'sap/ui/model/json/JSONModel'
], function (BaseController, formatter, validacao, JSONModel) {
    'use strict';

    var idJogo = "";

    return BaseController.extend("ui5.codersgrowth.app.detalhesJogo.DetalhesJogo", {
        formatter: formatter,
        validacao: validacao,

        onInit: function() {
            this.getRouter().getRoute("appDetalhesJogo").attachMatched(this._aoCoincidirRota, this);
        },

        _aoCoincidirRota: function(evento) {
            idJogo = this._obterIdJogoPelaRota(evento);

            const viewDetalhesJogo = this.getView();
            const jogo = "jogo";
            const urlObterPorId = `/api/JogoControlador/${idJogo}`;
            const urlObterTodosTestes = "/api/TesteDeJogoControlador";
            const listaDeTestes = "listaDeTestes"

            this.fazerRequisicaoGet(urlObterPorId, jogo, viewDetalhesJogo);
            
            this._pegarFilhosDoJogo(urlObterTodosTestes, listaDeTestes, viewDetalhesJogo);
        },

        _pegarFilhosDoJogo: function(url, nomeLista, view){
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
                    respostaApi = respostaApi.filter((avaliacao) => avaliacao.idJogo == idJogo);

					const dataModel = new JSONModel();
				  	dataModel.setData(respostaApi);
					 
				  	this.getView().setModel(dataModel, nomeLista);
				});
        },

        _obterIdJogoPelaRota(evento) {
            const idJogo = evento.getParameters().arguments.jogoId;

            return idJogo;
        },

        _navegarPara(nomeRota){
            this.getRouter()
                .navTo(nomeRota, {
                    jogoId: idJogo
                }, true);
        },

        _pegarNomeDoJogo: function () {
            const idJogoNomeTitulo = "idJogoNomeTitulo";
            const jogoNome = this.getView().byId(idJogoNomeTitulo).getText();
            
            return jogoNome;
        },

        _prepararMensagemDeAtencao: function () {
            const viewDetalhesJogo = this.getView();
            const propriedadesI18n = this.getView().getModel("i18n").getResourceBundle();
            const jogoNome = this._pegarNomeDoJogo();
            const mensagem = `Tem certeza que deseja remover o ${jogoNome}`

            this.mostrarMensagemDeAviso(viewDetalhesJogo, propriedadesI18n, mensagem, idJogo, jogoNome);
        },

        aoClicarIrParaEdicao: function () {
            const rotaAdicionarJogo = "appAdicionarJogo";
            this._navegarPara(rotaAdicionarJogo);
        },

        aoClicarRemoverJogo: function () {
            this._prepararMensagemDeAtencao();
        },

        navegarParaListagem: function () {
            const rotaListagem = "appListagemJogo"
            this.getRouter()
                .navTo(rotaListagem, {}, true);
        }
    });
});