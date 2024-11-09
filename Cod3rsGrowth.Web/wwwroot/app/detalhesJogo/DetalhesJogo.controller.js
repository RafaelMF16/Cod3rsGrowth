sap.ui.define([
    'ui5/codersgrowth/app/BaseController',
    '../model/formatter',
    'ui5/codersgrowth/app/servicos/validacao',
    'sap/ui/model/json/JSONModel',
    'ui5/codersgrowth/common/ConstantesDaRota',
    '../repositorio/RepositorioJogo',
    'sap/m/MessageBox'
], function (BaseController, formatter, validacao, JSONModel, ConstantesDaRota, Repositorio, MessageBox) {
    'use strict';

<<<<<<< HEAD
    var idJogo = "";
    var valorFiltroNomeResponsavel = "";
    var valorFiltroStatusAprovado = "";
    var valorFiltroStatusReprovado = "";
    var valorFiltroDataMin = "";
    var valorFiltroDataMax = "";
=======
    const NAMESPACE_DA_CONTROLLER_DETALHES_JOGO = "ui5.codersgrowth.app.detalhesJogo.DetalhesJogo";
>>>>>>> 294a8d99ed42d22342a448c109fdf8ca161a9a16

    return BaseController.extend(NAMESPACE_DA_CONTROLLER_DETALHES_JOGO, {
        formatter: formatter,
        validacao: validacao,
        idJogo: null,

        onInit: function() {
            this.getRouter().getRoute("appDetalhesJogo").attachMatched(this._aoCoincidirRota, this);
        },

        _aoCoincidirRota: function(evento) {
            this.exibirEspera(() => {
                this.idJogo = this._obterIdJogoPelaRota(evento);
                return this._carregarJogo();
            });
        },

<<<<<<< HEAD
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
=======
        _carregarJogo: function () {
            return Repositorio.obterPorId(this.idJogo, this.getView())
                .then(dados => this.modeloJogo(new JSONModel(dados)));
>>>>>>> 294a8d99ed42d22342a448c109fdf8ca161a9a16
        },

        _obterIdJogoPelaRota(evento) {
            const idJogo = evento.getParameters().arguments.idJogo;

            return idJogo;
        },

        _exibirMensagemDeConfirmacao: async function () {
            let jogo = await Repositorio.obterPorId(this.idJogo, this.getView());
            const nomeModeloI18n = "i18n";
            const propriedadesI18n = this.getView().getModel(nomeModeloI18n).getResourceBundle();
            const chaveI18nMensagemDeAviso = "MessageBox.Aviso.TemCertezaQueQuerRemover";
            const chaveI18nMessageBoxAvisoTitulo = "MessageBox.Aviso.Titulo";

            MessageBox.warning(propriedadesI18n.getText(chaveI18nMensagemDeAviso) + ` ${jogo.nome}?`, {
                title: propriedadesI18n.getText(chaveI18nMessageBoxAvisoTitulo),
                actions: [sap.m.MessageBox.Action.YES, sap.m.MessageBox.Action.CANCEL],
				emphasizedAction: MessageBox.Action.YES,
                onClose: (sAction) => {
                    this.exibirEspera(() => {
                        if (sAction === sap.m.MessageBox.Action.YES){
                            this._removerJogo();
                            this.navegarPara(ConstantesDaRota.NOME_DA_ROTA_DA_LISTAGEM_DE_JOGOS);
                        }
                    });
				},
            });
        },

        _removerJogo: async function () {
            return Repositorio.remover(this.idJogo, this.getView());
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
            this.navegarPara(ConstantesDaRota.NOME_DA_ROTA_DE_ADICIONAR_JOGO, this.idJogo);
        },

        aoClicarRemoverJogo: function () {
            this.exibirEspera(() => this._exibirMensagemDeConfirmacao());
        },

<<<<<<< HEAD
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
=======
        aoClicarVoltarParaListagem: function () {
            this.exibirEspera(() => this.navegarPara(ConstantesDaRota.NOME_DA_ROTA_DA_LISTAGEM_DE_JOGOS));
>>>>>>> 294a8d99ed42d22342a448c109fdf8ca161a9a16
        }
    });
});