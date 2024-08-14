sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/Jogo"
], (opaTest) => {
	"use strict";

	QUnit.module("Lista Jogo");

	opaTest("A tabela deve ter paginação", function (Given, When, Then) {
		// Arrangements
		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5.codersgrowth"
			}
		});

		When.paginaJogo.aoClicarNoBotaoDeConfiguracoes();

		//Asserções
		Then.paginaJogo.aTabelaDeveTerPaginacao().
			and.oTituloDeveMostrarQuantidadeDeItems();
	});

	opaTest("Deve poder carregar mais items", function (Given, When, Then) {
		//Ações
		When.paginaJogo.aoApertarEmMais();

		//Asserções
		Then.paginaJogo.aTabelaDeveTerTodosOsItems();
	});

	opaTest("Deve poder filtrar por nome", function (Given, When, Then) {
		//Ações
		When.paginaJogo.aoColocarTextoNoCampoDePesquisaDeNome("Minecraft");

		//Asserções
		Then.paginaJogo.aTabelaDeveTerApenasItemPesquisado();
	});

	opaTest("Deve poder filtrar por gênero", function (Given, When, Then) {
		//Ações
		When.paginaJogo.limparFiltroDePesquisa();
		When.paginaJogo.aoEscolherGeneroNoSelect("FPS");
		
		//Asserções
		Then.paginaJogo.aTabelaDeveMostrarApenasOsItemsComGeneroSelecionado();
	});

	opaTest("Deve poder filtrar por nome e gênero", function (Given, When, Then) {
		//Ações
		When.paginaJogo.aoColocarTextoNoCampoDePesquisaDeNome("Counter Strike 2");
		
		//Asserções
		Then.paginaJogo.aTabelaDeveMostrarApenasItemComNomePesquisadoGeneroSelecionado();
	});

	opaTest("Deve poder filtrar por preço mínimo", function (Given, When, Then) {
		//Ações
		When.paginaJogo.limparFiltroDePesquisa();
		When.paginaJogo.limparFiltroGenero();
		When.paginaJogo.aoColocarValorNoInputPrecoMin("100");

		//Asserções
		Then.paginaJogo.aTabelaDeveMostrarApenasOsItemsComPrecoMinIgualCem();
	});

	opaTest("Deve poder filtrar por preço máximo", function (Given, When, Then) {
		//Ações
		When.paginaJogo.limparFiltroPrecoMin();
		When.paginaJogo.aoColocarValorNoInputPrecoMax("0");

		//Asserções
		Then.paginaJogo.aTabelaDeveMostrarApenasOsItemsComPrecoMaxIgualZero();

		
	});

	opaTest("Deve poder filtrar por preço mínimo e máximo", function (Given, When, Then) {
		//Ações
		When.paginaJogo.aoColocarValorNoInputPrecoMin("150");
		When.paginaJogo.aoColocarValorNoInputPrecoMax("200");

		//Asserções
		Then.paginaJogo.aTabelaDeveMostrarApenasOsItemsComPrecoEntrePrecoMinPrecoMax();
	});

	opaTest("Deve poder filtrar por preço mínimo, preço máximo e gênero", function (Given, When, Then) {
		//Ações
		When.paginaJogo.aoColocarValorNoInputPrecoMin("90");
		When.paginaJogo.aoColocarValorNoInputPrecoMax("150");
		When.paginaJogo.aoEscolherGeneroNoSelect("SOBREVIVENCIA");

		//Asserções
		Then.paginaJogo.aTabelaDeveMostrarApenasOsItemsComPrecoEntrePrecoMinPrecoMaxGeneroSelecionado();
	});

	opaTest("Deve poder filtrar por preço mínimo, preço máximo, gênero e nome", function (Given, When, Then) {
		//Ações
		When.paginaJogo.aoColocarTextoNoCampoDePesquisaDeNome("Minecraft");

		//Asserções
		Then.paginaJogo.aTabelaDeveMostrarApenasItemComNomePesquisadoPrecoEntrePrecoMinPrecoMaxGeneroSelecionado();
	});

	opaTest("Caso item com nome não exista tabela não terá dados", function (Given, When, Then) {
		//Ações
		When.paginaJogo.limparFiltroDePesquisa();
		When.paginaJogo.limparFiltroGenero();
		When.paginaJogo.limparFiltroPrecoMin();
		When.paginaJogo.limparFiltroPrecoMax();
		When.paginaJogo.aoColocarTextoNoCampoDePesquisaDeNome("Terraria");

		//Asserções
		Then.paginaJogo.aTabelaNaoDeveMostrarItem();
	});

	opaTest("Caso item com nome não exista tabela não terá dados", function (Given, When, Then) {
		//Ações
		When.paginaJogo.aoClicarNoBotaoDeConfiguracoes();
		

		//Asserções
		Then.paginaJogo.aTabelaNaoDeveMostrarItem();
		//FinalizarJornada
		Then.iTeardownMyApp();
	});
});