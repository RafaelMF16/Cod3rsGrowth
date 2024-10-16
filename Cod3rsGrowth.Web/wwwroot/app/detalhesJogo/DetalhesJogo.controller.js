sap.ui.define([
    'ui5/codersgrowth/app/BaseController',
    '../model/formatter',
    'ui5/codersgrowth/app/servicos/validacao',
    'sap/ui/model/json/JSONModel',
    'ui5/codersgrowth/common/ConstantesDoBanco',
    'ui5/codersgrowth/common/ConstantesDaRota'
], function (BaseController, formatter, validacao, JSONModel, ConstantesDoBanco, ConstantesDaRota) {
    'use strict';

    var idJogo = "";
    var valorFiltroNomeResponsavel = "";
    var valorFiltroStatusAprovado = "";
    var valorFiltroStatusReprovado = "";
    var valorFiltroDataMin = "";
    var valorFiltroDataMax = "";

    return BaseController.extend("ui5.codersgrowth.app.detalhesJogo.DetalhesJogo", {
        formatter: formatter,
        validacao: validacao,
        constantesDoBanco: ConstantesDoBanco,

        onInit: function() {
            this.getRouter().getRoute("appDetalhesJogo").attachMatched(this._aoCoincidirRota, this);
        },

        _aoCoincidirRota: function(evento) {
            idJogo = this._obterIdJogoPelaRota(evento);

            const viewDetalhesJogo = this.getView();
            const modelojogo = "jogo";
            const urlObterPorId = ConstantesDoBanco.CAMINHO_PARA_API_JOGO + `/${idJogo}`;
            const nomeModeloListaAvaliacoes = "listaDeAvaliacoes";
            
            this.fazerRequisicaoGet(urlObterPorId, modelojogo, viewDetalhesJogo);
            this._mostrarAvaliacoesDoJogo(ConstantesDoBanco.CAMINHO_PARA_API_AVALIACAO, nomeModeloListaAvaliacoes);
        },

        _mostrarAvaliacoesDoJogo: function(url, nomeModelo) {
            fetch(url)
			    .then(respostaApi => {
					if (!respostaApi.ok) {
						respostaApi.json()
							.then(respostaApi => {
						   		this.validacao.mostrarMensagemDeErro(respostaApi, this.getView())
							});
					}
				  	return respostaApi.json();
				})
			    .then(respostaApi => {
					const dataModel = new JSONModel();
                    
                    respostaApi = respostaApi.filter((avaliacao) => avaliacao.idJogo == idJogo);

				  	dataModel.setData(respostaApi);

				  	this.getView().setModel(dataModel, nomeModelo);
			    });
        },

        _obterIdJogoPelaRota(evento) {
            const idJogo = evento.getParameters().arguments.jogoId;

            return idJogo;
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

        _filtrarJogos: function () {
            const nomeModelo = "listaDeAvaliacoes";
            
            let query = {};
   
            if (valorFiltroNomeResponsavel)
               query.nomeResponsavelTeste = valorFiltroNomeResponsavel;
   
            if (valorFiltroStatusAprovado)
               query.aprovado = valorFiltroStatusAprovado;

            if (valorFiltroStatusReprovado)
                query.reprovado = valorFiltroStatusReprovado;
   
            if (valorFiltroDataMin)
               query.dataMinRealizacaoTeste = valorFiltroDataMin;
   
            if (valorFiltroDataMax)
               query.dataMaxRealizacaoTeste = valorFiltroDataMax;
   
            let urlObterTodosComFiltros = ConstantesDoBanco.CAMINHO_PARA_API_AVALIACAO + `?${new URLSearchParams(query)}`;

            this._mostrarAvaliacoesDoJogo(urlObterTodosComFiltros, nomeModelo);
        },

        aoClicarIrParaEdicao: function () {
            this.navegarPara(ConstantesDaRota.NOME_DA_ROTA_DE_ADICIONAR_JOGO, idJogo);
        },

        aoClicarRemoverJogo: function () {
            this._prepararMensagemDeAtencao();
        },

        aoClicarVoltarParaTelaDeListagem: function () {
            this.navegarPara(ConstantesDaRota.NOME_DA_ROTA_DA_LISTAGEM_DE_JOGOS);
        },

        pegarValorDoCampoDePesquisa: function (oEvent) {
            valorFiltroNomeResponsavel = oEvent.getSource().getValue();
            
            this._filtrarJogos();
         },

        pegarValorDoSelectStatus: function (oEvent) {
            const statusAprovado = "Aprovado";
            const statusReprovado = "Reprovado";
            const statusTodos = "";
            const valorDoStatus = oEvent.getSource().getSelectedItem().mProperties.text;

            if (valorDoStatus === statusAprovado)
                valorFiltroStatusAprovado = true;
            else if (valorDoStatus === statusReprovado)
                valorFiltroStatusReprovado = true         
        }
    });
});