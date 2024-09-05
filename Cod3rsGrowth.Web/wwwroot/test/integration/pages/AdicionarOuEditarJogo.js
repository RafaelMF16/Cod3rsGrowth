sap.ui.define([
	"sap/ui/test/Opa5",
	"sap/ui/test/actions/Press",
	'sap/ui/test/actions/EnterText',
	'sap/ui/test/matchers/I18NText',
	'sap/ui/test/matchers/Properties',
	'sap/ui/test/matchers/PropertyStrictEquals'
], (Opa5, Press, EnterText, I18NText, Properties, PropertyStrictEquals) => {
	"use strict";
    
	const nomeDaViewAdicionarOuEditarJogo = "adicionarJogo.AdicionarJogo";
	const nomeDaViewJogo = "listagemJogo.ListagemJogo";
	const nomeDaViewDetalhesJogo = "detalhesJogo.DetalhesJogo"
	const botaoCancelarCriacaoJogoId = "idBotaoCancelarCriacaoJogo";
	const botaAdicionarId = "idBotaoAdicionar";
	const botaoSalvarCriacaoJogoId = "idBotaoSalvarCriacaoJogo";
	const inputNomeId = "idInputNome";
	const inputPrecoId = "idInputPreco";
	const selectGeneroId = "idSelectGenero";

	Opa5.createPageObjects({
		paginaAdicionarOuEditarJogo: {
			actions: {
				aoClicarNoBotaoDeCancelar: function () {
					return this.waitFor({
						id: botaoCancelarCriacaoJogoId,
						viewName: nomeDaViewAdicionarOuEditarJogo,
						actions: new Press(),
						errorMessage: "O botão de cancelar não foi encontrado"
					});
				},

				aoClicarNoBotaoAdicionar: function () {
					return this.waitFor({
						id: botaAdicionarId,
						viewName: nomeDaViewJogo,
						actions: new Press(),
						errorMessage: "Botão adicionar jogo não foi encontrado"
					});
				},

				aoClicarNoBotaoSalvar: function () {
					return this.waitFor({
						id: botaoSalvarCriacaoJogoId,
						viewName: nomeDaViewAdicionarOuEditarJogo,
						actions: new Press(),
						errorMessage: "Botão salvar na tela de criação não foi encontrado"
					});
				},

				adicionarValorAoInputNome: function (nomeJogo) {
					return this.waitFor({
						id: inputNomeId,
						viewName: nomeDaViewAdicionarOuEditarJogo,
						actions: new EnterText({
							text: nomeJogo
						}),
						errorMessage: "O input nome não foi encontado"
					});
				},

				limparInputNome: function () {
					return this.waitFor({
						id: inputNomeId,
						viewName: nomeDaViewAdicionarOuEditarJogo,
						actions: new EnterText({
							text: " "
						}),
						errorMessage: "O input nome não foi encontrado",
					});
				},

				adicionarValorAoInputPreco: function (precoJogo) {
					this.waitFor({
						id: inputPrecoId, 
						viewName: nomeDaViewAdicionarOuEditarJogo,
						actions: new EnterText({
							text: precoJogo
						}),
						errorMessage: "O input preço não foi encontrado",
					});
				},

				limparInputPreco: function () {
					return this.waitFor({
						id: inputPrecoId,
						viewName: nomeDaViewAdicionarOuEditarJogo,
						actions: new EnterText({
							text: " "
						}),
						errorMessage: "O input preço não foi encontrado",
					});
				},

				selecionarGeneroNoSelect: function (generoSelecionado) {
					return this.waitFor({
						id: selectGeneroId,
						viewName: nomeDaViewAdicionarOuEditarJogo,
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
					});
				},

				aoClicarEmVisualizarDetalhes: function () {
					this.waitFor({
						controlType: "sap.m.Link",
						actions: new Press(),
						success: function () {
							Opa5.assert.ok(true, "foi possível clicar em visualizar detalhes")
						},
						errorMessage: "Não foi possível clicar em visualizar detalhes"
					})
				},

				aoClicarEmFechar: function () {
					this.waitFor({
						controlType: "sap.m.Button",
						actions: new Press(),
						errorMessage: "Não foi possível clicar em fechar"
					})
				},

				aoClicarNoBotaoDeOkNaCaixaDeMensagemDeSucesso: function () {
					this.waitFor({
						controlType: "sap.m.Dialog",
						success: function () {
							this.waitFor({
								controlType: "sap.m.Button",
								matchers: [
									new Properties({ text: "OK"}),
								],
								actions: new Press(),
							})
						}
					})
				},

				aoClicarNoItemDaTabela: function (jogoNome) {
					return this.waitFor({
						controlType: "sap.m.ObjectIdentifier",
						viewName: nomeDaViewJogo,
						matchers:[
							new Properties({
								title: jogoNome
							})
						],
						actions: new Press(),
						errorMessage: "Não foi possível clicar no item"
					})
				},

				aoClicarNoBotaoEditar: function () {
					return this.waitFor({
						controlType : "sap.m.Button",
						matchers: [
							new Properties({
								text: "Editar"
							})
						],
						actions: new Press(),
						errorMessage: "Não foi possível clicar no botão de editar"
					})
				},

				aoClicarNoBotaoNavBack: function () {
					return this.waitFor({
						controlType : "sap.m.Button",
						matchers: [
							new Properties({
								icon: "sap-icon://nav-back"
							})
						],
						actions: new Press(),
						errorMessage: "Não foi possível clicar no botão de nav back"
					})
				},

				aoClicarNoBotaoSim: function () {
					return this.waitFor({
						controlType: "sap.m.Button",
						matchers: new PropertyStrictEquals({
							name: "text",
							value: "Sim"
						}),
						actions: new Press(),
						errorMessage: "Não foi possível clicar no botão Sim"
					})
				}
			},
			assertions: {
				aTelaComTituloCorrespondenteFoiCarregadaCorretamente: function (titulo) {
					return this.waitFor({
						controlType: "sap.m.Title",
						matchers: new PropertyStrictEquals({
							name: 'text',
							value: titulo
						}),
						success: () => Opa5.assert.ok(true, `A tela com título ${titulo} foi carregada corretamente`),
						errorMessage: `A tela com título ${titulo} não foi carregada corretamente`
					});
				},

				oInputComIdCorrespondenteFicouNoEstadoEsperado: function (inputId, estado) {
					return this.waitFor({
						id: inputId,
						viewName: nomeDaViewAdicionarOuEditarJogo,
						check: function (input) {
							return input.getValueState() === estado;
						},
						success: () => Opa5.assert.ok(true, "O input está em estado de erro"),
						errorMessage: "O input não está em estado de erro"
					});
				},

				oInputComIdCorrespondenteFicouComTextoDeCampoObrigatorio: function (inputId, textoDoErro) {
					this.waitFor({
						id: inputId,
						viewName: nomeDaViewAdicionarOuEditarJogo,
						check: function (input) {
							return input.getValueStateText() === textoDoErro;
						},
						success: () => Opa5.assert.ok(true, "O texto de campo obrigatório apareceu"),
						errorMessage: "O texto de campo obrigatório não apareceu"
					});
				},

				aCaixaDeMensagemApareceu: function () {
					this.waitFor({
						controlType: "sap.m.Dialog",
						matchers: new I18NText({
							key: "tituloMessageBoxErro",
							propertyName: "title"
						}),
						success: function () {
							Opa5.assert.ok(true, "A caixa de mensagem de erro apareceu corretamente");
						},
						errorMessage: "A caixa de mensagem de erro não apareceu"
					});
				},

				oGeneroDoJogoDeveEstarCorreto: function () {
                    return this.waitFor({
                        id: selectGeneroId,
						viewName: nomeDaViewAdicionarOuEditarJogo,
                        success: function (oSelect) {
							Opa5.assert.strictEqual(oSelect.getSelectedKey(), "10", "O gênero do jogo está correto")
						},
						errorMessage: "O gênero está incorreto"
                    })
                },

				oNomeDoJogoDeveEstarCorreto: function () {
					return this.waitFor({
						id: inputNomeId,
						viewName: nomeDaViewAdicionarOuEditarJogo,
						success: function (inputNome) {
							Opa5.assert.strictEqual(inputNome.getValue(), "Rust", "O nome do jogo está correto")
						},
						errorMessage: "O nome está incorreto"
					})
				},

				oPrecoDoJogoDeveEstarCorreto: function () {
					return this.waitFor({
						id: inputPrecoId,
						viewName: nomeDaViewAdicionarOuEditarJogo,
						success: function (inputPreco) {
							Opa5.assert.strictEqual(inputPreco.getValue(), "90", "O preço do jogo está correto")
						},
						errorMessage: "O preço está incorreto"
					})
				}
			}
		}
	});
});