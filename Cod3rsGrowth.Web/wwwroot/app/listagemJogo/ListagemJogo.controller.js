sap.ui.define([
   'ui5/codersgrowth/app/BaseController',
   '../model/formatter',
   'ui5/codersgrowth/common/ConstantesDaRota',
   'sap/ui/model/json/JSONModel',
   '../repositorio/RepositorioJogo'
], (
   BaseController, 
   formatter, 
   ConstantesDaRota, 
   JSONModel,
   Repositorio
) => {
   "use strict";

   const NAMESPACE_DA_CONTROLLER_LISTAGEM_JOGO = "ui5.codersgrowth.app.listagemJogo.ListagemJogo";
   const VALOR_NULO = null;

   return BaseController.extend(NAMESPACE_DA_CONTROLLER_LISTAGEM_JOGO, {
      formatter: formatter,
      valorFiltroNome: VALOR_NULO,
      valorFiltroPrecoMin: VALOR_NULO,
      valorFiltroPrecoMax: VALOR_NULO,
      valorFiltroGenero: VALOR_NULO,

      onInit: function () {
         const tempoDeEspera = 400;

         this.getRouter().getRoute("appListagemJogo").attachMatched(this._aoCoincidirRota, this);

         this.debouncedFiltrarJogos = this.debounce(this._filtrarJogos.bind(this), tempoDeEspera);
      },

      _aoCoincidirRota: function () {
         this.exibirEspera(async () => {
            await Promise.all([
               this._carregarJogos(),
               this.carregarGeneros()
            ]);
         });
      },

      _modeloJogos: function (jsonModel) {
         const nomeModeloJogos = "jogos";
         return this.modelo(nomeModeloJogos, jsonModel);
      },

      _carregarJogos: async function (filtros) {
         const viewListagem = this.getView();
         let dados = await Repositorio.obterTodosJogos(filtros, viewListagem);
         this._modeloJogos(new JSONModel(dados));
      },

      _filtrarJogos: async function () {
         const viewListagem = this.getView();
         
         let filtro = {};

         if (this.valorFiltroNome)
            filtro.nome = this.valorFiltroNome;

         if (this.valorFiltroGenero)
            filtro.genero = this.valorFiltroGenero;

         if (this.valorFiltroPrecoMin)
            filtro.precoMin = this.valorFiltroPrecoMin;

         if (this.valorFiltroPrecoMax)
            filtro.precoMax = this.valorFiltroPrecoMax;
         
         let dados = await Repositorio.obterTodosJogos(filtro, viewListagem);
         this._modeloJogos(new JSONModel(dados));
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