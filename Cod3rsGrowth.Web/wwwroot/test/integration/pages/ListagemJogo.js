sap.ui.define([
	"sap/ui/test/Opa5",
	"sap/ui/test/actions/Press",
	'sap/ui/test/matchers/AggregationLengthEquals',
	'sap/ui/test/actions/EnterText',
	'sap/ui/test/matchers/I18NText',
	'sap/ui/test/matchers/Properties',
	'sap/ui/test/matchers/PropertyStrictEquals'
], (Opa5, Press, AggregationLengthEquals, EnterText, I18NText, Properties, PropertyStrictEquals) => {
	"use strict";

	const nomeDaViewJogo = "listagemJogo.ListagemJogo";
	const nomeDaViewAdicionarJogo = "adicionarJogo.AdicionarJogo";
	const tabelaJogoId = "idTabelaJogo";
	const tabelaJogoTituloId = "idTabelaJogoTitulo";
	const campoDePesquisaPorNomeId = "idCampoDePesquisaNome";
	const campoDeSelecaoGeneroId = "idCampoDeSelecaoGenero";
	const inputPrecoMinId = "idInputPrecoMin";
	const inputPrecoMaxId = "idInputPrecoMax"
	const menuBotaoHeaderId = "idMenuBotaoHeader";
	const botaAdicionarId = "idBotaoAdicionar";
	const botaoNavBackAdicionarJogo = "idAdicionarJogoBotaoNavBack";

	Opa5.createPageObjects({
		paginaJogo: {
			actions: {
				aoApertarEmMais: function () {
					return this.waitFor({
						id: tabelaJogoId,
						viewName: nomeDaViewJogo,
						actions: new Press(),
						errorMessage: "A tabela não tem botão para carregar mais items"
					});
				},

				aoColocarTextoNoCampoDePesquisaDeNome: function (jogoNome) {
					return this.waitFor({
						id: campoDePesquisaPorNomeId,
						viewName: nomeDaViewJogo,
						actions: new EnterText({
							text: jogoNome
						}),
						errorMessage: "O campo de pesquisa não foi encontrado"
					});
				},

				limparFiltroDePesquisa: function () {
					return this.waitFor({
						id: campoDePesquisaPorNomeId,
						viewName: nomeDaViewJogo,
						actions: new EnterText({
							text: " "
						}),
						errorMessage: "O campo de pesquisa não foi encontrado",
					})
				},

				aoEscolherGeneroNoSelect: function (generoSelecionado) {
					return this.waitFor({
						id: campoDeSelecaoGeneroId,
						viewName: nomeDaViewJogo,
						actions: new Press(),
						success: function() {
							this.waitFor({
								controlType: "sap.ui.core.ListItem",
								matchers: [
									new Properties({ text: generoSelecionado})
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
						viewName: nomeDaViewJogo,
						actions: new Press(),
						success: function() {
							this.waitFor({
								controlType: "sap.ui.core.Item",
								matchers: [
									new Properties({ text: "Todos"})
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
						viewName: nomeDaViewJogo,
						actions: new EnterText({
							text: precoMin
						}),
						errorMessage: "O input de preço mínimo não foi encontrado"
					})
				},

				limparFiltroPrecoMin: function() {
					return this.waitFor({
						id: inputPrecoMinId,
						viewName: nomeDaViewJogo,
						actions: new EnterText({
							text: " "
						}),
						errorMessage: "O input de preço mínimo não foi encontrado"
					})
				},

				aoColocarValorNoInputPrecoMax: function (precoMax) {
					return this.waitFor({
						id: inputPrecoMaxId,
						viewName: nomeDaViewJogo,
						actions: new EnterText({
							text: precoMax
						}),
						errorMessage: "O input de preço máximo não foi encontrado"
					})
				},

				limparFiltroPrecoMax: function () {
					return this.waitFor({
						id: inputPrecoMaxId,
						viewName: nomeDaViewJogo,
						actions: new EnterText({
							text: " "
						}),
						errorMessage: "O input de preço máximo não foi encontrado"
					})
				},

				alternarEntreModoClaroEscuro: function (modo) {
					return this.waitFor({
						id: menuBotaoHeaderId,
						viewName: nomeDaViewJogo,
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
				aoClicarNoBotaoAdicionar: function () {
					return this.waitFor({
						id: botaAdicionarId,
						viewName: nomeDaViewJogo,
						actions: new Press(),
						errorMessage: "Botão adicionar jogo não foi encontrado"
					})
				},

				aoClicarNoBotaoNavBack: function () {
					return this.waitFor({
						id: botaoNavBackAdicionarJogo,
						viewName: nomeDaViewAdicionarJogo,
						actions: new Press(),
						errorMessage: "Botão para voltar para tela de listagem não foi encontrado"
					})
				},
			},
			assertions: {
				aTabelaDeveTerPaginacao: function () {
					return this.waitFor({
						id: tabelaJogoId,
						viewName: nomeDaViewJogo,
						matchers: new AggregationLengthEquals({
							name: "items",
							length: 10
						}),
						success: function () {
							Opa5.assert.ok(true, "A tabela tem 10 itens na primeira página.");
						},
						errorMessage: "A tabela não contém paginação."
					});
				},

				oTituloDeveMostrarQuantidadeDeItems: function () {
					return this.waitFor({
						id: tabelaJogoTituloId,
						viewName: nomeDaViewJogo,
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

				aTabelaDeveTerQuantidadeDeItemsCorrespondente: function (quantidade) {
					return this.waitFor({
						id: tabelaJogoId,
						viewName: nomeDaViewJogo,
						check: function(tabela){
							return tabela.getItems().length === quantidade
						},
						success : function () {
							Opa5.assert.ok(true, "A tabela tem a quantidade de items correta");
						},
						errorMessage: "A tabela não tem a quantidade de items correta"
					});
				},

				aTelaComTituloCorrespondenteFoiCarregadaCorretamente: function (titulo) {
					return this.waitFor({
						controlType: "sap.m.Title",
						matchers: new PropertyStrictEquals({
							name: 'text',
							value: titulo
						}),
						success: () => Opa5.assert.ok(true, `A tela com título ${titulo} foi carregada corretamente`),
						errorMessage: `A tela com título ${titulo} não foi carregada corretamente`
					})
				}
			}
		}
	});
});