sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/Jogo"
], (opaTest) => {
	"use strict";

	QUnit.module("Tela Listagem");

	opaTest("Deve ver a tabela com todos os items", (Given, When, Then) => {
		// Arrangements
		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5.codersgrowth"
			}
		});

        Then.jogo.tabelaDeveTerPaginacao().
			and.tituloDeveMostrarQuantidadeDeItems();
	});

	opaTest("Deve poder carregar mais items", function (Given, When, Then) {

		//Actions
		When.jogo.carregarMaisItems();

		//Assert
		Then.jogo.tabelaDeveTerTodosOsItems();

		Then.iTeardownMyApp();
	})
});