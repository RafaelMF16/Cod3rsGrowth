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
    const nomeDaViewDetalhesJogo = "detalhesJogo.DetalhesJogo"
	const tabelaidJogo = "idTabelaJogo";

    Opa5.createPageObjects({
        paginaDetalhesOuRemoverJogo: {
            actions: {
                aoClicarNoBotaoNavBack: function () {
                    return this.waitFor({
                        controlType: "sap.m.Button",
                        viewName: nomeDaViewDetalhesJogo,
                        matchers: [
                            new Properties({
								icon: "sap-icon://nav-back"
							})
                        ],
                        actions: new Press(),
                        errorMessage: "Não foi possível clicar no botão nav back"
                    })   
                },

                aoClicarNoItemDaTabela: function () {
					return this.waitFor({
						controlType: "sap.m.ObjectIdentifier",
						viewName: nomeDaViewJogo,
						matchers:[
							new Properties({
								title: "Counter-Strike: Global Offensive"
							})
						],
						actions: new Press(),
						errorMessage: "Não foi possível clicar no item"
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
						viewName: nomeDaViewDetalhesJogo,
						matchers: [
							new Properties({
								text: "Editar"
							})
						],
						actions: new Press(),
						errorMessage: "Não foi possível clicar no botão de editar"
					})
				},

				aoClicarNoBotaoRemover: function () {
					return this.waitFor({
						controlType: "sap.m.Button",
						viewName: nomeDaViewDetalhesJogo,
						matchers: new Properties({
							text: "Remover"
						}),
						actions: new Press(),
						errorMessage: "Não foi possível clicar no botão remover"
					})
				},

				aoApertarEmMais: function () {
					return this.waitFor({
						id: tabelaidJogo,
						viewName: nomeDaViewJogo,
						actions: new Press(),
						errorMessage: "A tabela não tem botão para carregar mais items"
					});
				},

				aoClicarNosBotoesDaCaixaDeMensagem: function (textoBotao) {
					return this.waitFor({
						controlType: "sap.m.Button",
						matchers: new Properties({
							text: textoBotao
						}),
						actions: new Press(),
						errorMessage: "O botão de Sim/Não não foi encontrado"
					});
				},

				aoClicarNoBotaoOk: function () {
					return this.waitFor({
						controlType: "sap.m.Button",
						viewName: nomeDaViewDetalhesJogo,
						matchers: new Properties({
							text: "OK"
						}),
						actions: new Press(),
						errorMessage: "O botão de cancelar não foi encontrado"
					});
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
					})
				},

                oPrecoDoJogoDeveEstarCorreto: function (preco) {
                    return this.waitFor({
                        controlType: "sap.m.Text",
                        matchers: new PropertyStrictEquals({
                            name: 'text',
                            value: preco
                        }),
                        success: () => Opa5.assert.ok(true, "O preço do jogo está correto")
                    })
                },

                oGeneroDoJogoDeveEstarCorreto: function (genero) {
                    return this.waitFor({
                        controlType: "sap.m.Text",
                        matchers: new PropertyStrictEquals({
                            name: 'text',
                            value: genero
                        }),
                        success: () => Opa5.assert.ok(true, "O gênero do jogo está correto")
                    })
                }
            }
        }
    });
});