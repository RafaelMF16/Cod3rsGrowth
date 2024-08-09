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

		//Actions
		Then.paginaJogo.aTabelaDeveTerPaginacao();
	});
});