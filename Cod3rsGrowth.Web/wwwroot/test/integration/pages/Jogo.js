sap.ui.define([
	"sap/ui/test/Opa5",
	"sap/ui/test/actions/Press",
	'sap/ui/test/matchers/AggregationLengthEquals',
	'sap/ui/test/matchers/I18NText'
], (Opa5, Press, AggregationLengthEquals, I18NText) => {
	"use strict";

	var viewNome = "ui5.codersgrowth.view.Jogo";
	var tabelaId = "tabelaJogo"
	var tabelaHeaderId = "tabelaHeader";

	Opa5.createPageObjects({
		jogo: {
			actions: {
				carregarMaisItems: function () {
					return this.waitFor({
						id: tabelaId,
						viewName: viewNome,
						actions: new Press(),
						errorMessage: "A tabela não tem botão mais"
					});
				}
			},
			assertions: {
				tabelaDeveTerPaginacao: function () {
					return this.waitFor({
						id: tabelaId,
						viewName: viewNome,
						matchers: new AggregationLengthEquals({
							name: "items",
							length: 10
						}),

						success: function () {
							Opa5.assert.ok(true, "A tabela tem 10 items na primeira página")
						},

						errorMessage: "A tabela não contém todos os itens"
					});
				},

				tabelaDeveTerTodosOsItems: function () {
					return this.waitFor({
						id: tabelaId,
						viewName: viewNome,
						matchers: new AggregationLengthEquals({
							name: "items",
							length: 14
						}),

						success: function () {
							Opa5.assert.ok(true, "A tabela tem 14 items");
						},

						errorMessage: "A tabela não contém todos os items"
					});
				},

				tituloDeveMostrarQuantidadeDeItems: function () {
					return this.waitFor({
						id: tabelaHeaderId,
						viewName: viewNome,
						matchers: new I18NText({
							key: "jogoTabelaTituloContador",
							propertyName: "text",
							parameters: [14]
						}),

						success: function () {
							Opa5.assert.ok(true, "O contador do titulo tem 14 items")
						},

						errorMessage: "O contador do titulo não tem o número de items"
					});
				}
			}
		}
	});
});