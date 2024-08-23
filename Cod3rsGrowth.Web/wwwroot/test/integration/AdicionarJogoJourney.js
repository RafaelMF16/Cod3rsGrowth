sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/AdicionarJogo"
], (opaTest) => {
	"use strict";

	QUnit.module("Tela de adição de jogos");

	opaTest("Deve poder voltar para tela de listagem ao clicar no botão cancelar", function (Given, When, Then) {
		// Arrangements
		Given.EuInicioMinhaApp({
			componentConfig: {
				name: "ui5.codersgrowth"
			}
		});

        //Ações
        

		//Asserções
		
	});
});