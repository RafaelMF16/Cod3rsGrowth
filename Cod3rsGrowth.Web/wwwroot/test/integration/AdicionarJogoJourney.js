sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/AdicionarOuEditarJogo"
], (opaTest) => {
	"use strict";

	QUnit.module("Tela de adição de jogos");

	opaTest("Deve poder voltar para tela de listagem ao clicar no botão cancelar", function (Given, When, Then) {
		// Arrangements
		Given.euInicioMinhaApp({
			componentConfig: {
				name: "ui5.codersgrowth"
			}
		});

        //Ações
		When.paginaAdicionarOuEditarJogo.aoClicarNoBotaoAdicionar();
        When.paginaAdicionarOuEditarJogo.aoClicarNoBotaoDeCancelar();

		//Asserções
		Then.paginaAdicionarOuEditarJogo.aTelaComTituloCorrespondenteFoiCarregadaCorretamente("Jogos (20)");
	});

	opaTest("Os inputs devem ficar em estado de erro caso tente salvar com eles vazios", function (Given, When, Then) {
		//Ações
		When.paginaAdicionarOuEditarJogo.aoClicarNoBotaoAdicionar();
		When.paginaAdicionarOuEditarJogo.aoClicarNoBotaoSalvar();

		//Asserções
		Then.paginaAdicionarOuEditarJogo.oInputComIdCorrespondenteFicouNoEstadoEsperado("idInputNome", "Error");
		Then.paginaAdicionarOuEditarJogo.oInputComIdCorrespondenteFicouNoEstadoEsperado("idInputPreco", "Error");
		Then.paginaAdicionarOuEditarJogo.oInputComIdCorrespondenteFicouNoEstadoEsperado("idSelectGenero", "Error");
	});

	opaTest("Os inputs devem ficar com texto de campo obrigatório caso estejam vazios", function (Given, When, Then) {
		//Asserções
		Then.paginaAdicionarOuEditarJogo.oInputComIdCorrespondenteFicouComTextoDeCampoObrigatorio("idInputNome", "O campo nome é obrigatório");
		Then.paginaAdicionarOuEditarJogo.oInputComIdCorrespondenteFicouComTextoDeCampoObrigatorio("idInputPreco", "O campo preço é obrigatório");
		Then.paginaAdicionarOuEditarJogo.oInputComIdCorrespondenteFicouComTextoDeCampoObrigatorio("idSelectGenero", "O campo gênero é obrigatório");
	});

	opaTest("O input nome deve ficar em estado padrão caso seja preenchido", function (Given, When, Then) {
		//Ações
		When.paginaAdicionarOuEditarJogo.adicionarValorAoInputNome("FarCry4");
		When.paginaAdicionarOuEditarJogo.aoClicarNoBotaoSalvar();

		//Asserções
		Then.paginaAdicionarOuEditarJogo.oInputComIdCorrespondenteFicouNoEstadoEsperado("idInputNome", "None");
	});

	opaTest("O input preço deve ficar em estado padrão caso seja preenchido", function (Given, When, Then) {
		//Ações
		When.paginaAdicionarOuEditarJogo.limparInputNome();
		When.paginaAdicionarOuEditarJogo.adicionarValorAoInputPreco("100");
		When.paginaAdicionarOuEditarJogo.aoClicarNoBotaoSalvar();

		//Asserções
		Then.paginaAdicionarOuEditarJogo.oInputComIdCorrespondenteFicouNoEstadoEsperado("idInputPreco", "None");
	});

	opaTest("O select gênero deve ficar em estado padrão caso seja preenchido", function (Given, When, Then) {
		//Ações
		When.paginaAdicionarOuEditarJogo.limparInputPreco();
		When.paginaAdicionarOuEditarJogo.selecionarGeneroNoSelect("FPS");
		When.paginaAdicionarOuEditarJogo.aoClicarNoBotaoSalvar();

		//Asserções
		Then.paginaAdicionarOuEditarJogo.oInputComIdCorrespondenteFicouNoEstadoEsperado("idSelectGenero", "None");
	});

	opaTest("Deve ser possível ver a caixa de mensagem de erro", function (Given, When, Then) {
		//Ações
		When.paginaAdicionarOuEditarJogo.adicionarValorAoInputNome("Minecraft");
		When.paginaAdicionarOuEditarJogo.adicionarValorAoInputPreco("20000");
		When.paginaAdicionarOuEditarJogo.selecionarGeneroNoSelect("FPS");
		When.paginaAdicionarOuEditarJogo.aoClicarNoBotaoSalvar();

		//Asserções
		Then.paginaAdicionarOuEditarJogo.aCaixaDeMensagemApareceu("Erro")
	});

	opaTest("Deve ser possível clicar em visualizar detalhes", function (Given, When, Then) {
		//Ações
		When.paginaAdicionarOuEditarJogo.aoClicarEmVisualizarDetalhes();
	});

	opaTest("Deve ser possível clicar em fechar na caixa de mensagem de erro", function (Given, When, Then) {
		//Ações
		When.paginaAdicionarOuEditarJogo.aoClicarEmFechar();

		//Asserções
		Then.paginaAdicionarOuEditarJogo.aTelaComTituloCorrespondenteFoiCarregadaCorretamente("Adicionar Jogo")
	});

	opaTest("Deve ser possível clicar em OK na caixa de mensagem de sucesso", function (Given, When, Then) {
		//Ações
		When.paginaAdicionarOuEditarJogo.adicionarValorAoInputNome("FarCry 5");
		When.paginaAdicionarOuEditarJogo.adicionarValorAoInputPreco("120");
		When.paginaAdicionarOuEditarJogo.selecionarGeneroNoSelect("FPA");
		When.paginaAdicionarOuEditarJogo.aoClicarNoBotaoSalvar();
		When.paginaAdicionarOuEditarJogo.aoClicarNoBotaoDeOkNaCaixaDeMensagemDeSucesso();
		
		//Asserções
		Then.paginaAdicionarOuEditarJogo.aTelaComTituloCorrespondenteFoiCarregadaCorretamente("Jogos (21)")

		//FinalizarJornada
		Then.iTeardownMyApp();
	});
});