sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/DetalhesOuRemoverJogo"
], (opaTest) => {
	"use strict";

	QUnit.module("Tela de Detalhes de jogos");

	opaTest("Deve poder ir para tela de detalhes ao clicar em um item da tabela", function (Given, When, Then) {
		// Arrangements
		Given.euInicioMinhaApp({
			componentConfig: {
				name: "ui5.codersgrowth"
			}
		});
        
        //Ações
		When.paginaDetalhesOuRemoverJogo.aoClicarNoItemDaTabela("Counter-Strike: Global Offensive");

		//Asserções
		Then.paginaDetalhesOuRemoverJogo.aTelaComTituloCorrespondenteFoiCarregadaCorretamente("Detalhes: Counter-Strike: Global Offensive")
	});

    opaTest("Deve aparecer o preço correto do jogo", function (Given, When, Then) {
		//Asserções
		Then.paginaDetalhesOuRemoverJogo.oPrecoDoJogoDeveEstarCorreto("Grátis");
	});

	opaTest("Deve aparecer o gênero correto do jogo", function (Given, When, Then) {
		//Asserções
		Then.paginaDetalhesOuRemoverJogo.oGeneroDoJogoDeveEstarCorreto("FPS");
	});

    opaTest("Deve poder voltar para tela de listagem", function (Given, When, Then) {
        //Ações
		When.paginaDetalhesOuRemoverJogo.aoClicarNoBotaoNavBack();

		//Asserções
		Then.paginaDetalhesOuRemoverJogo.aTelaComTituloCorrespondenteFoiCarregadaCorretamente("Jogos (21)");
	});

	opaTest("Deve poder ir para tela de edição", function (Given, When, Then) {
        //Ações
		When.paginaDetalhesOuRemoverJogo.aoClicarNoItemDaTabela("Rust");
		When.paginaDetalhesOuRemoverJogo.aoClicarNoBotaoEditar();

		//Asserções
		Then.paginaDetalhesOuRemoverJogo.aTelaComTituloCorrespondenteFoiCarregadaCorretamente("Editar Jogo");

		//FinalizarJornada
		Then.iTeardownMyApp();
	});
})