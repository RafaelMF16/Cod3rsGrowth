sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/ListagemJogo"
], (opaTest) => {
	"use strict";

	QUnit.module("Tela de listagem de jogos");

	opaTest("A tabela deve ter paginação", function (Given, When, Then) {
		// Arrangements
		Given.euInicioMinhaApp({
			componentConfig: {
				name: "ui5.codersgrowth"
			}
		});

		//Asserções
		Then
			.paginaJogo
			.aTabelaDeveTerPaginacao()
			.and
			.oTituloDeveMostrarQuantidadeDeItems();
	});

	opaTest("Deve poder carregar mais items", function (Given, When, Then) {
		//Ações
		When
			.paginaJogo
			.aoApertarEmMais();

		//Asserções
		Then
			.paginaJogo
			.aTabelaDeveTerQuantidadeDeItemsCorrespondente(20);
	});

	opaTest("Deve poder filtrar por nome", function (Given, When, Then) {
		//Ações
		When
			.paginaJogo
			.aoColocarTextoNoCampoDePesquisaDeNome("Minecraft");

		//Asserções
		Then
			.paginaJogo
			.aTabelaDeveTerQuantidadeDeItemsCorrespondente(1);
	});

	opaTest("Deve poder filtrar por gênero", function (Given, When, Then) {
		//Ações
		When
			.paginaJogo
			.limparFiltroDePesquisa();

		When
			.paginaJogo
			.aoEscolherGeneroNoSelect("FPS");
		
		//Asserções
		Then
			.paginaJogo
			.aTabelaDeveTerQuantidadeDeItemsCorrespondente(2);
	});

	opaTest("Deve poder filtrar por nome e gênero", function (Given, When, Then) {
		//Ações
		When
			.paginaJogo
			.aoColocarTextoNoCampoDePesquisaDeNome("Counter Strike 2");
		
		//Asserções
		Then
			.paginaJogo
			.aTabelaDeveTerQuantidadeDeItemsCorrespondente(1);
	});

	opaTest("Deve poder filtrar por preço mínimo", function (Given, When, Then) {
		//Ações
		When
			.paginaJogo
			.limparFiltroDePesquisa();

		When
			.paginaJogo
			.limparFiltroGenero();

		When
			.paginaJogo
			.aoColocarValorNoInputPrecoMin("100");

		//Asserções
		Then
			.paginaJogo.aTabelaDeveTerQuantidadeDeItemsCorrespondente(9);
	});

	opaTest("Deve poder filtrar por preço máximo", function (Given, When, Then) {
		//Ações
		When
			.paginaJogo
			.limparFiltroPrecoMin();

		When
			.paginaJogo
			.aoColocarValorNoInputPrecoMax("0");

		//Asserções
		Then
			.paginaJogo
			.aTabelaDeveTerQuantidadeDeItemsCorrespondente(5);
	});

	opaTest("Deve poder filtrar por preço mínimo e máximo", function (Given, When, Then) {
		//Ações
		When
			.paginaJogo
			.aoColocarValorNoInputPrecoMin("150");

		When
			.paginaJogo
			.aoColocarValorNoInputPrecoMax("200");

		//Asserções
		Then
			.paginaJogo
			.aTabelaDeveTerQuantidadeDeItemsCorrespondente(4);
	});

	opaTest("Deve poder filtrar por preço mínimo, preço máximo e gênero", function (Given, When, Then) {
		//Ações
		When
			.paginaJogo
			.aoColocarValorNoInputPrecoMin("90");

		When
			.paginaJogo
			.aoColocarValorNoInputPrecoMax("150");

		When
			.paginaJogo
			.aoEscolherGeneroNoSelect("Sobrevivência");

		//Asserções
		Then
			.paginaJogo
			.aTabelaDeveTerQuantidadeDeItemsCorrespondente(2);
	});

	opaTest("Deve poder filtrar por preço mínimo, preço máximo, gênero e nome", function (Given, When, Then) {
		//Ações
		When
			.paginaJogo
			.aoColocarTextoNoCampoDePesquisaDeNome("Minecraft");

		//Asserções
		Then
			.paginaJogo
			.aTabelaDeveTerQuantidadeDeItemsCorrespondente(1);
	});

	opaTest("Caso item com nome não exista tabela não terá dados", function (Given, When, Then) {
		//Ações
		When
			.paginaJogo
			.limparFiltroDePesquisa();

		When
			.paginaJogo
			.limparFiltroGenero();

		When
			.paginaJogo
			.limparFiltroPrecoMin();

		When
			.paginaJogo
			.limparFiltroPrecoMax();
			
		When
			.paginaJogo
			.aoColocarTextoNoCampoDePesquisaDeNome("Terraria");

		//Asserções
		Then
			.paginaJogo
			.aTabelaDeveTerQuantidadeDeItemsCorrespondente(0);
	});

	opaTest("Deve poder trocar para tema escuro", function (Given, When, Then) {
		//Ações
		When
			.paginaJogo
			.limparFiltroDePesquisa();
			
		When
			.paginaJogo
			.alternarEntreModoClaroEscuro("Escuro");
	});

	opaTest("Deve poder trocar para tema claro", function (Given, When, Then) {
		//Ações
		When
			.paginaJogo
			.alternarEntreModoClaroEscuro("Claro");
	});

	opaTest("Deve poder ir para tela de adição de jogos", function (Given, When, Then) {
		//Ações
		When
			.paginaJogo
			.aoClicarNoBotaoAdicionar();

		//Asserções
		Then
			.paginaJogo
			.aTelaComTituloCorrespondenteFoiCarregadaCorretamente("Adicionar Jogo");
	});

	opaTest("Quando estiver na tela de adição deve poder voltar para tela de listagem", function (Given, When, Then) {
		//Ações
		When
			.paginaJogo
			.aoClicarNoBotaoNavBack();

		//Asserções
		Then
			.paginaJogo
			.aTelaComTituloCorrespondenteFoiCarregadaCorretamente("Jogos (20)");

		//FinalizarJornada
		Then
			.iTeardownMyApp();
	});
});