sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/DetalhesOuRemoverJogo"
], (opaTest) => {
	"use strict";

	QUnit.module("Tela de remoção jogo");

	opaTest("Deve poder ir para tela de detalhes ao clicar em um item da tabela", function (Given, When, Then) {
		// Arrangements
		Given.euInicioMinhaApp({
			componentConfig: {
				name: "ui5.codersgrowth"
			}
		});
        
        //Ações
        When
			.paginaDetalhesOuRemoverJogo
			.aoApertarEmMais();

        When
			.paginaDetalhesOuRemoverJogo
			.aoApertarEmMais();

		When
			.paginaDetalhesOuRemoverJogo
			.aoClicarNoItemDaTabela("FarCry 5");

		//Asserções
		Then
			.paginaDetalhesOuRemoverJogo
			.aTelaComTituloCorrespondenteFoiCarregadaCorretamente("Detalhes:")
	});

    opaTest("Deve poder clicar no botão de remoção", function (Given, When, Then) {
        //Ações
		When
			.paginaDetalhesOuRemoverJogo
			.aoClicarNoBotaoRemover();

		//Asserções
		Then
			.paginaDetalhesOuRemoverJogo
			.aTelaComTituloCorrespondenteFoiCarregadaCorretamente("Aviso")
	});

    opaTest("Deve poder clicar no botão não da caixa de mensagem de aviso", function (Given, When, Then) {
        //Ações
		When
			.paginaDetalhesOuRemoverJogo
			.aoClicarNosBotoesDaCaixaDeMensagem("Não");

		//Asserções
		Then
			.paginaDetalhesOuRemoverJogo
			.aTelaComTituloCorrespondenteFoiCarregadaCorretamente("Detalhes:")
	});

    opaTest("Deve poder clicar no botão ok da caixa de mensagem de aviso", function (Given, When, Then) {
        //Ações
		When
			.paginaDetalhesOuRemoverJogo
			.aoClicarNoBotaoRemover();
			
		When
			.paginaDetalhesOuRemoverJogo
			.aoClicarNosBotoesDaCaixaDeMensagem("Sim");

		//Asserções
		Then
			.paginaDetalhesOuRemoverJogo
			.aTelaComTituloCorrespondenteFoiCarregadaCorretamente("Êxito");
	});

    opaTest("Deve poder clicar no botão ok da caixa de mensagem de sucesso", function (Given, When, Then) {
        //Ações
		When
			.paginaDetalhesOuRemoverJogo
			.aoClicarNoBotaoOk();

		//Asserções
		Then
			.paginaDetalhesOuRemoverJogo
			.aTelaComTituloCorrespondenteFoiCarregadaCorretamente("Jogos (20)");

        //FinalizarJornada
		Then
			.iTeardownMyApp();
	});
});