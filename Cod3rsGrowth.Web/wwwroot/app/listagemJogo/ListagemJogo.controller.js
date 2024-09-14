sap.ui.define([
   'ui5/codersgrowth/app/BaseController',
   '../model/formatter',
   'ui5/codersgrowth/common/ConstantesDaRota'
], (BaseController, formatter, ConstantesDaRota) => {
   "use strict";

   var valorFiltroNome = "";
   var valorFiltroPrecoMin = "";
   var valorFiltroPrecoMax = "";
   var valorFiltroGenero = "";

   return BaseController.extend("ui5.codersgrowth.app.listagemJogo.ListagemJogo", {
      formatter: formatter,

      onInit: function () {
         this.getRouter().getRoute("appListagemJogo").attachMatched(this._aoCoincidirRota, this);
      },

      _aoCoincidirRota: function () {
         const urlObterTodos = "/api/JogoControlador";
         const urlObterGeneros = "/api/GeneroControlador";
         const nomeListaJogos = "listaJogos";
         const nomeListaGeneros = "listaGeneros";

         this.fazerRequisicaoGet(urlObterTodos, nomeListaJogos);
         
         this.fazerRequisicaoGet(urlObterGeneros, nomeListaGeneros);
      },

      _filtrarJogos: function () {
         const nomeListaJogos = "listaJogos";
         const viewJogo = this.getView();
         let query = {};

         if (valorFiltroNome)
            query.nome = valorFiltroNome;

         if (valorFiltroGenero)
            query.genero = valorFiltroGenero;

         if (valorFiltroPrecoMin)
            query.precoMin = valorFiltroPrecoMin;

         if (valorFiltroPrecoMax)
            query.precoMax = valorFiltroPrecoMax;

         let urlObterTodosComFiltros = `/api/JogoControlador?${new URLSearchParams(query)}`;
         
         this.fazerRequisicaoGet(urlObterTodosComFiltros, nomeListaJogos, viewJogo);
      },

      _obterIdJogo(evento){
         const contexto = 'listaJogos';
         const propriedadeId = 'id';
         let idJogo = evento.getSource()
            .getBindingContext(contexto)
            .getProperty(propriedadeId);

         return idJogo;
      },

      pegarValorDoSelect: function (oEvent) {
         valorFiltroGenero = oEvent.getSource().getSelectedKey();

         this._filtrarJogos();
      },

      pegarValorDoCampoDePesquisa: function (oEvent) {
         valorFiltroNome = oEvent.getSource().getValue();
         
         this._filtrarJogos();
      },

      pegarValorDoCampoPrecoMin: function (oEvent) {
         valorFiltroPrecoMin = oEvent.getSource().getValue();
         
         this._filtrarJogos();
      },

      pegarValorDoCampoPrecoMax: function (oEvent) {
         valorFiltroPrecoMax = oEvent.getSource().getValue();

         this._filtrarJogos();
      },

      atualizarTitulo: function (oEvent) {
         let tabelaJogoTitulo;
         let tabelaJogo = oEvent.getSource();
			let itemsDaTabelaJogo = oEvent.getParameter("total");

         const propriedadesI18n = this.getView().getModel("i18n").getResourceBundle();

			if (itemsDaTabelaJogo && tabelaJogo.getBinding("items").isLengthFinal()) {
				tabelaJogoTitulo = propriedadesI18n.getText("tituloTabelaJogoComContadorDeItens", [itemsDaTabelaJogo]);
			} else {
				tabelaJogoTitulo = propriedadesI18n.getText("tabelaJogoTitulo");
			}
         this.getView().byId("idTabelaJogoTitulo").setProperty("text", tabelaJogoTitulo);
      },

      aoClicarIrParaTelaDeAdicionarJogo: function () {
         this.navegarPara(ConstantesDaRota.NOME_DA_ROTA_DE_ADICIONAR_JOGO);
      },

      aoClicarNavegarParaDetalhes(oEvent){
         const idJogo = this._obterIdJogo(oEvent);
         
         this.navegarPara(ConstantesDaRota.NOME_DA_ROTA_DE_DETALHE, idJogo);
      },
   });
});