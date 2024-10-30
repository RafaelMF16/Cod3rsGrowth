sap.ui.define([
   'ui5/codersgrowth/app/BaseController',
   '../model/formatter',
   'ui5/codersgrowth/common/ConstantesDaRota',
   'ui5/codersgrowth/common/ConstantesDoBanco'
], (BaseController, formatter, ConstantesDaRota, ConstantesDoBanco) => {
   "use strict";

   const NAMESPACE_DA_CONTROLLER_LISTAGEM_JOGO = "ui5.codersgrowth.app.listagemJogo.ListagemJogo";
   const VALOR_NULO = null;
   const TEMPO_DE_ESPERA_EM_MS = 400;

   return BaseController.extend(NAMESPACE_DA_CONTROLLER_LISTAGEM_JOGO, {
      formatter: formatter,
      valorFiltroNome: VALOR_NULO,
      valorFiltroPrecoMin: VALOR_NULO,
      valorFiltroPrecoMax: VALOR_NULO,
      valorFiltroGenero: VALOR_NULO,
      tempoDeEspera: TEMPO_DE_ESPERA_EM_MS,

      onInit: function () {
         this.getRouter().getRoute("appListagemJogo").attachMatched(this._aoCoincidirRota, this);

         this.debouncedFiltrarJogos = this.debounce(this._filtrarJogos.bind(this), this.tempoDeEspera);
      },

      _aoCoincidirRota: function () {
         this.fazerRequisicaoGet(ConstantesDoBanco.CAMINHO_PARA_API_JOGO, this.nomeModeloJogos);
         this.fazerRequisicaoGet(ConstantesDoBanco.CAMINHO_PARA_API_GENERO, this.nomeModeloGeneros);
      },

      _modeloFiltroJogo: function (jsonModel) {
         const nomeModeloFiltro = "filtros"
         return this.modelo(nomeModeloFiltro, jsonModel);
      },

      _filtrarJogos: function () {
         const viewJogo = this.getView();
         let query = {};

         if (this.valorFiltroNome)
            query.nome = this.valorFiltroNome;

         if (this.valorFiltroGenero)
            query.genero = this.valorFiltroGenero;

         if (this.valorFiltroPrecoMin)
            query.precoMin = this.valorFiltroPrecoMin;

         if (this.valorFiltroPrecoMax)
            query.precoMax = this.valorFiltroPrecoMax;

         let urlObterTodosComFiltros = `${ConstantesDoBanco.CAMINHO_PARA_API_JOGO}?${new URLSearchParams(query)}`;
         
         this.fazerRequisicaoGet(urlObterTodosComFiltros, this.nomeModeloJogos, viewJogo);
      },

      _obterIdJogo(evento){
         const parametro = "listItem";
         const propriedadeId = "id";
         let jogoId = evento
            .getParameter(parametro)
            .getBindingContext(this.nomeModeloJogos)
            .getProperty(propriedadeId);

         return jogoId;
      },

      aoSelecionarGenero: function (oEvent) {
         this.valorFiltroGenero = oEvent.getSource().getSelectedKey();

         this._filtrarJogos();
      },

      aoPesquisarNome: function (oEvent) {
         this.valorFiltroNome = oEvent.getSource().getValue();
         
         this.debouncedFiltrarJogos();
      },

      aoPesquisarPrecoMin: function (oEvent) {
         this.valorFiltroPrecoMin = oEvent.getSource().getValue();
         
         this.debouncedFiltrarJogos();
      },

      aoPesquisarPrecoMax: function (oEvent) {
         this.valorFiltroPrecoMax = oEvent.getSource().getValue();

         this.debouncedFiltrarJogos();
      },

      atualizarTitulo: function (oEvent) {
         let listaJogoTitulo;
         let listaJogo = oEvent.getSource();
			let itemsDaListaJogo = oEvent.getParameter("total");

         const propriedadesI18n = this.getView().getModel("i18n").getResourceBundle();

			if (itemsDaListaJogo && listaJogo.getBinding("items").isLengthFinal()) {
				listaJogoTitulo = propriedadesI18n.getText("tituloTabelaJogoComContadorDeItens", [itemsDaListaJogo]);
			} else {
				listaJogoTitulo = propriedadesI18n.getText("lista.Jogos.Titulo");
			}
         this.getView().byId("idListaJogoTitulo").setProperty("text", listaJogoTitulo);
      },

      aoClicarIrParaTelaDeAdicionarJogo: function () {
         this.navegarPara(ConstantesDaRota.NOME_DA_ROTA_DE_ADICIONAR_JOGO);
      },

      aoSelecionarJogo(oEvent){
         let jogoId = this._obterIdJogo(oEvent);
         
         this.navegarPara(ConstantesDaRota.NOME_DA_ROTA_DE_DETALHE, jogoId);
      },
   });
});