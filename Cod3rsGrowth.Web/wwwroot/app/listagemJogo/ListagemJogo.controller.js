sap.ui.define([
   'ui5/codersgrowth/app/BaseController',
   '../model/formatter',
   'ui5/codersgrowth/common/ConstantesDaRota',
   'ui5/codersgrowth/common/ConstantesDoBanco',
], (BaseController, formatter, ConstantesDaRota, ConstantesDoBanco) => {
   "use strict";

   const NAMESPACE_DA_CONTROLLER_LISTAGEM_JOGO = "ui5.codersgrowth.app.listagemJogo.ListagemJogo";
   

   return BaseController.extend(NAMESPACE_DA_CONTROLLER_LISTAGEM_JOGO, {
      formatter: formatter,
      valorFiltroNome: this.valorNulo,
      valorFiltroPrecoMin: this.valorNulo,
      valorFiltroPrecoMax: this.valorNulo,
      valorFiltroGenero: this.valorNulo,

      onInit: function () {
         const tempoDeEspera = 400;

         this.getRouter().getRoute("appListagemJogo").attachMatched(this._aoCoincidirRota, this);

         this.debouncedFiltrarJogos = this.debounce(this._filtrarJogos.bind(this), tempoDeEspera);
      },

      _aoCoincidirRota: function () {
         this.exibirEspera(async () => {
            await Promise.all([
               this.fazerRequisicaoGet(ConstantesDoBanco.CAMINHO_PARA_API_JOGO, this.nomeModeloJogos),
               this.fazerRequisicaoGet(ConstantesDoBanco.CAMINHO_PARA_API_GENERO, this.nomeModeloGeneros)
            ]);
         });
      },

      _filtrarJogos: async function () {
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
         
         await this.fazerRequisicaoGet(urlObterTodosComFiltros, this.nomeModeloJogos, viewJogo);
      },

      _obterIdJogo(evento){
         const parametro = "listItem";
         const propriedadeId = "id";
         let idJogo = evento
            .getParameter(parametro)
            .getBindingContext(this.nomeModeloJogos)
            .getProperty(propriedadeId);

         return idJogo;
      },

      aoSelecionarGenero: function (evento) {
         this.valorFiltroGenero = evento.getSource().getSelectedKey();

         return this._filtrarJogos();
      },

      aoPesquisarNome: function (evento) {
         this.valorFiltroNome = evento.getSource().getValue();
            
         this.debouncedFiltrarJogos();
      },

      aoPesquisarPrecoMin: function (evento) {
         this.valorFiltroPrecoMin = evento.getSource().getValue();
         
         this.debouncedFiltrarJogos();
      },

      aoPesquisarPrecoMax: function (evento) {
         this.valorFiltroPrecoMax = evento.getSource().getValue();

         this.debouncedFiltrarJogos();
      },

      atualizarTitulo: function (evento) {
         let listaJogoTitulo;
         let listaJogo = evento.getSource();
			let itemsDaListaJogo = evento.getParameter("total");

         const propriedadesI18n = this.getView().getModel("i18n").getResourceBundle();

			if (itemsDaListaJogo && listaJogo.getBinding("items").isLengthFinal()) {
				listaJogoTitulo = propriedadesI18n.getText("tituloTabelaJogoComContadorDeItens", [itemsDaListaJogo]);
			} else {
				listaJogoTitulo = propriedadesI18n.getText("lista.Jogos.Titulo");
			}
         this.getView().byId("idListaJogoTitulo").setProperty("text", listaJogoTitulo);
      },

      aoClicarIrParaTelaDeAdicionarJogo: function () {
         this.exibirEspera(() => this.navegarPara(ConstantesDaRota.NOME_DA_ROTA_DE_ADICIONAR_JOGO));
      },

      aoSelecionarJogo(evento){
         this.exibirEspera(() => {
            let idJogo = this._obterIdJogo(evento);
            
            this.navegarPara(ConstantesDaRota.NOME_DA_ROTA_DE_DETALHE, idJogo);
         });
      },
   });
});