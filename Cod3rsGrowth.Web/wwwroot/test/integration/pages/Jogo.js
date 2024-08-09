sap.ui.define([
	"sap/ui/test/Opa5",
	"sap/ui/test/actions/Press",
	'sap/ui/test/matchers/AggregationLengthEquals',
	'sap/ui/test/actions/EnterText',
	'sap/ui/test/matchers/I18NText'
], (Opa5, Press, AggregationLengthEquals, EnterText, I18NText) => {
	"use strict";

	const sViewName = "ui5.codersgrowth.view.Jogo";
	const sTableId = "tabelaJogo";

	Opa5.createPageObjects({
		paginaJogo: {
			assertions: {
				aTabelaDeveTerPaginacao: function () {
					return this.waitFor({
						id: sTableId,
						viewName: sViewName,
						matchers: new AggregationLengthEquals({
							name: "items",
							length: 10
						}),
						success: function () {
							Opa5.assert.ok(true, "A tabela tem 10 itens na primeira página");
						},
						errorMessage: "A tabela não contém todos os items."
					});
				},
			}
		}
	});
});