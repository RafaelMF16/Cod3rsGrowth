sap.ui.define([
   'ui5/codersgrowth/app/BaseController',
   '../model/formatter',
   'ui5/codersgrowth/common/ConstantesDaRota',
   'ui5/codersgrowth/common/ConstantesDoBanco'
], (BaseController, formatter, ConstantesDaRota, ConstantesDoBanco) => {
   "use strict";

   const VALOR_NULO = null;
   
   return BaseController.extend("ui5.codersgrowth.app.listagemJogo.ListagemJogo", {
      formatter: formatter,
      valorFiltroNome: VALOR_NULO,
      valorFiltroGenero: VALOR_NULO,
      valorFiltroPrecoMin: VALOR_NULO,
      valorFiltroPrecoMax: VALOR_NULO,
      idJogo: VALOR_NULO,
      

      onInit: function () {
         this.getRouter().getRoute("appListagemJogo").attachMatched(this._aoCoincidirRota, this);

         this.debouncedFiltrarJogos = this.debounce(this._filtrarJogos.bind(this), 300);
      },

      _aoCoincidirRota: function () {
         this.fazerRequisicaoGet(ConstantesDoBanco.CAMINHO_PARA_API_JOGO, this.nomeModeloJogos);
         
         this.fazerRequisicaoGet(ConstantesDoBanco.CAMINHO_PARA_API_GENERO, this.nomeModeloGeneros);
      },

      _filtrarJogos: function () {
         const nomeListaJogos = "listaJogos";
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
         
         this.fazerRequisicaoGet(urlObterTodosComFiltros, nomeListaJogos, viewJogo);
      },

      _alteraValorDoLayoutDaPagina: function (layout) {
         this.getView().byId("idLayout").setLayout(layout);
      },

      _carregarJogo: function (idJogo) {
         const urlObterPorId = `${ConstantesDoBanco.CAMINHO_PARA_API_JOGO}/${idJogo}`;
         const viewDetalhesJogo = this.getView();

         this.fazerRequisicaoGet(urlObterPorId, this.nomeModeloJogo, viewDetalhesJogo);
      },

      pegarValorDoSelect: function (oEvent) {
         this.valorFiltroGenero = oEvent.getSource().getSelectedKey();

         this._filtrarJogos(); 
      },

      pegarValorDoCampoDePesquisa: function (oEvent) {
         this.valorFiltroNome = oEvent.getSource().getValue();

         this.debouncedFiltrarJogos(); 
      },

      pegarValorDoCampoPrecoMin: function (oEvent) {
         this.valorFiltroPrecoMin = oEvent.getSource().getValue();
         
         this.debouncedFiltrarJogos(); 
      },

      pegarValorDoCampoPrecoMax: function (oEvent) {
         this.valorFiltroPrecoMax = oEvent.getSource().getValue();

         this.debouncedFiltrarJogos(); 
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

      aoClicarFecharDetalhesJogo: function () {
         this._alteraValorDoLayoutDaPagina(this.LayoutUmaColuna);
      },

      aoSelecionarJogo: function (evento) {
         let parametro = "listItem";
         let propriedade = "id";
         this.idJogo = evento
            .getParameter(parametro)
            .getBindingContext("listaJogos")
            .getProperty(propriedade);

         this._carregarJogo(this.idJogo);

         this.navegarPara(ConstantesDaRota.NOME_DA_ROTA_DE_DETALHE, this.idJogo);

         this._alteraValorDoLayoutDaPagina("TwoColumnsMidExpanded");
      }
   });
});