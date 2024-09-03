sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/DetalhesJogo"
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
		When.detalhesJogo.aoClicarNoItemDaTabela("Counter-Strike: Global Offensive");

		//Asserções
		Then.detalhesJogo.aTelaComTituloCorrespondenteFoiCarregadaCorretamente("Detalhes: Counter-Strike: Global Offensive")
	});

    opaTest("Deve aparecer o preço correto do jogo", function (Given, When, Then) {
		//Asserções
		Then.detalhesJogo.oPrecoDoJogoDeveEstarCorreto("Grátis");
	});

	opaTest("Deve aparecer o gênero correto do jogo", function (Given, When, Then) {
		//Asserções
		Then.detalhesJogo.oGeneroDoJogoDeveEstarCorreto("FPS");
	});

    opaTest("Deve poder voltar para tela de listagem", function (Given, When, Then) {
        //Ações
		When.detalhesJogo.aoClicarNoBotaoNavBack();

		//Asserções
		Then.detalhesJogo.aTelaComTituloCorrespondenteFoiCarregadaCorretamente("Jogos (21)");
	});

	opaTest("Deve poder ir para tela de edição", function (Given, When, Then) {
        //Ações
		When.detalhesJogo.aoClicarNoItemDaTabela("Rust");
		When.detalhesJogo.aoClicarNoBotaoEditar();

		//Asserções
		Then.detalhesJogo.aTelaComTituloCorrespondenteFoiCarregadaCorretamente("Editar Jogo");

		//FinalizarJornada
		Then.iTeardownMyApp();
	});
})