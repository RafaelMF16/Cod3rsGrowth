sap.ui.define([
	"sap/ui/test/Opa5",
	"sap/ui/test/actions/Press",
	'sap/ui/test/matchers/AggregationLengthEquals',
	'sap/ui/test/actions/EnterText',
	'sap/ui/test/matchers/I18NText',
	'sap/ui/test/matchers/Properties'
], (Opa5, Press, AggregationLengthEquals, EnterText, I18NText, Properties) => {
	"use strict";

	const nomeDaView = "ui5.codersgrowth.app.jogo.Jogo";
	const tabeloJogoId = "idTabelaJogo";
	const tabelaJogoTituloId = "idTabelaJogoTitulo";
	const campoDePesquisaPorNomeId = "idCampoDePesquisaNome";
	const campoDeSelecaoGeneroId = "idCampoDeSelecaoGenero";
	const inputPrecoMinId = "idInputPrecoMin";
	const inputPrecoMaxId = "idInputPrecoMax"
	const menuBotaoHeaderId = "idMenuBotaoHeader";

	Opa5.createPageObjects({
		paginaJogo: {
			actions: {
				aoApertarEmMais: function () {
					return this.waitFor({
						id: tabeloJogoId,
						viewName: nomeDaView,
						actions: new Press(),
						errorMessage: "A tabela não tem botão para carregar mais items"
					});
				},

				aoColocarTextoNoCampoDePesquisaDeNome: function (jogoNome) {
					return this.waitFor({
						id: campoDePesquisaPorNomeId,
						viewName: nomeDaView,
						actions: new EnterText({
							text: jogoNome
						}),
						errorMessage: "O campo de pesquisa não foi encontrado"
					});
				},

				limparFiltroDePesquisa: function () {
					return this.waitFor({
						id: campoDePesquisaPorNomeId,
						viewName: nomeDaView,
						actions: new EnterText({
							text: " "
						}),
						errorMessage: "O campo de pesquisa não foi encontrado",
					})
				},

				aoEscolherGeneroNoSelect: function (generoSelecionado) {
					return this.waitFor({
						id: campoDeSelecaoGeneroId,
						viewName: nomeDaView,
						actions: new Press(),
						success: function() {
							this.waitFor({
								controlType: "sap.ui.core.Item",
								matchers: [
									new Properties({ key: generoSelecionado})
								],
								actions: new Press(),
								errorMessage: "FPS não foi selecionado no select"
							});
						},
					})
				},

				limparFiltroGenero: function () {
					return this.waitFor({
						id: campoDeSelecaoGeneroId,
						viewName: nomeDaView,
						actions: new Press(),
						success: function() {
							this.waitFor({
								controlType: "sap.ui.core.Item",
								matchers: [
									new Properties({ key: "NAODEFINIDO"})
								],
								actions: new Press(),
								errorMessage: "NAODEFINIDO não foi selecionado no select"
							});
						},
					})
				},

				aoColocarValorNoInputPrecoMin: function (precoMin) {
					return this.waitFor({
						id: inputPrecoMinId,
						viewName: nomeDaView,
						actions: new EnterText({
							text: precoMin
						}),
						errorMessage: "O input de preço mínimo não foi encontrado"
					})
				},

				limparFiltroPrecoMin: function() {
					return this.waitFor({
						id: inputPrecoMinId,
						viewName: nomeDaView,
						actions: new EnterText({
							text: " "
						}),
						errorMessage: "O input de preço mínimo não foi encontrado"
					})
				},

				aoColocarValorNoInputPrecoMax: function (precoMax) {
					return this.waitFor({
						id: inputPrecoMaxId,
						viewName: nomeDaView,
						actions: new EnterText({
							text: precoMax
						}),
						errorMessage: "O input de preço máximo não foi encontrado"
					})
				},

				limparFiltroPrecoMax: function () {
					return this.waitFor({
						id: inputPrecoMaxId,
						viewName: nomeDaView,
						actions: new EnterText({
							text: " "
						}),
						errorMessage: "O input de preço máximo não foi encontrado"
					})
				},

				alternarEntreModoClaroEscuro: function (modo) {
					return this.waitFor({
						id: menuBotaoHeaderId,
						viewName: nomeDaView,
						actions: new Press(),
						success: function () {
							this.waitFor({
								controlType: "sap.ui.unified.MenuItem",
								actions: new Press(),
								success: function () {
									this.waitFor({
										controlType: "sap.ui.unified.MenuItem",
										matchers: [
											new Properties({ text: modo}),
										],
										actions: new Press(),
										errorMessage: "Não foi possível alternar entre os temas"
									})
									Opa5.assert.ok(true, "Foi possível alternar entre os temas")
								}
							});
						},
					})
				},
			},
			assertions: {
				aTabelaDeveTerPaginacao: function () {
					return this.waitFor({
						id: tabeloJogoId,
						viewName: nomeDaView,
						matchers: new AggregationLengthEquals({
							name: "items",
							length: 10
						}),
						success: function () {
							Opa5.assert.ok(true, "A tabela tem 10 itens na primeira página.");
						},
						errorMessage: "A tabela não contém todos os items."
					});
				},

				aTabelaDeveTerTodosOsItems: function () {
					return this.waitFor({
						id: tabeloJogoId,
						viewName: nomeDaView,
						matchers: new AggregationLengthEquals({
							name: "items",
							length: 20
						}),
						success: function () {
							Opa5.assert.ok(true, "A tabela tem 20 items");
						},
						errorMessage: "A tabela não contém todos os items"
					});
				},

				oTituloDeveMostrarQuantidadeDeItems: function () {
					return this.waitFor({
						id: tabelaJogoTituloId,
						viewName: nomeDaView,
						matchers: new I18NText({
							key: "contadorDeItemsTitulo",
							propertyName: "text",
							parameters: [20]
						}),
						success: function () {
							Opa5.assert.ok(true, "O título da tabela mostra os 20 items");
						},
						errorMessage: "O título da tabela não mostra a quantidade de items"
					});
				},

				aTabelaDeveTerApenasItemPesquisado: function () {
					return this.waitFor({
						id: tabeloJogoId,
						viewName: nomeDaView,
						matchers: new AggregationLengthEquals({
							name: "items",
							length: 1
						}),
						success: function () {
							Opa5.assert.ok(true, "A tabela contém um item");
						},
						errorMessage: "Não foi possível fazer a pesquisa"
					});
				},

				aTabelaDeveMostrarApenasOsItemsComGeneroSelecionado: function () {
					return this.waitFor({
						id: tabeloJogoId,
						viewName: nomeDaView,
						matchers: new AggregationLengthEquals({
							name: "items",
							length: 2
						}),
						success: function () {
							Opa5.assert.ok(true, "Foi mostrado apenas os items com gênero FPS");
						},
						errorMessage: "Não foi possível filtrar pelo gênero FPS"
					});
				},

				aTabelaDeveMostrarApenasItemComNomePesquisadoGeneroSelecionado: function () {
					return this.waitFor({
						id: tabeloJogoId,
						viewName: nomeDaView,
						matchers: new AggregationLengthEquals({
							name: "items",
							length: 1
						}),
						success: function () {
							Opa5.assert.ok(true, "Foi mostrado apenas o item pesquisado por nome e gênero");
						},
						errorMessage: "Não foi possível filtrar por nome e gênero"
					});
				},

				aTabelaDeveMostrarApenasOsItemsComPrecoMinIgualCem: function () {
					return this.waitFor({
						id: tabeloJogoId,
						viewName: nomeDaView,
						matchers: new AggregationLengthEquals({
							name: "items",
							length: 9
						}),
						success: function () {
							Opa5.assert.ok(true, "Foi mostrado apenas os items com preço mínimo igual 100");
						},
						errorMessage: "Não foi possível filtrar pelo preço mínimo"
					});
				},

				aTabelaDeveMostrarApenasOsItemsComPrecoMaxIgualZero: function () {
					return this.waitFor({
						id: tabeloJogoId,
						viewName: nomeDaView,
						matchers: new AggregationLengthEquals({
							name: "items",
							length: 5
						}),
						success : function () {
							Opa5.assert.ok(true, "Foi mostrado apenas os items com preço máximo igual 0");
						},
						errorMessage: "Não foi possível filtrar pelo preço máximo"
					});
				},

				aTabelaDeveMostrarApenasOsItemsComPrecoEntrePrecoMinPrecoMax: function () {
					return this.waitFor({
						id: tabeloJogoId,
						viewName: nomeDaView,
						matchers: new AggregationLengthEquals({
							name: "items",
							length: 4
						}),
						success : function () {
							Opa5.assert.ok(true, "Foi mostrado apenas os items com preço entre preço mínimo e preço máximo");
						},
						errorMessage: "Não foi possível filtrar pelo preço mínimo e preço máximo"
					});
				},

				aTabelaDeveMostrarApenasOsItemsComPrecoEntrePrecoMinPrecoMaxGeneroSelecionado: function () {
					return this.waitFor({
						id: tabeloJogoId,
						viewName: nomeDaView,
						matchers: new AggregationLengthEquals({
							name: "items",
							length: 2
						}),
						success : function () {
							Opa5.assert.ok(true, "Foi mostrado apenas os items com gênero selecionado e preço entre preço mínimo e preço máximo");
						},
						errorMessage: "Não foi possível filtrar pelo preço mínimo, preço máximo e gênero"
					});
				},

				aTabelaDeveMostrarApenasItemComNomePesquisadoPrecoEntrePrecoMinPrecoMaxGeneroSelecionado: function () {
					return this.waitFor({
						id: tabeloJogoId,
						viewName: nomeDaView,
						matchers: new AggregationLengthEquals({
							name: "items",
							length: 1
						}),
						success : function () {
							Opa5.assert.ok(true, "Foi mostrado apenas o item com nome pesquisado, gênero selecionado e preço entre preço mínimo e preço máximo");
						},
						errorMessage: "Não foi possível filtrar por nome, preço mínimo, preço máximo e gênero"
					});
				},

				aTabelaNaoDeveMostrarItem: function () {
					return this.waitFor({
						id: tabeloJogoId,
						viewName: nomeDaView,
						matchers: new AggregationLengthEquals({
							name: "items",
							length: 0
						}),
						success : function () {
							Opa5.assert.ok(true, "A tabela está sem dados");
						},
						errorMessage: "A tabela deveria estar sem dados"
					});
				}
			}
		}
	});
});