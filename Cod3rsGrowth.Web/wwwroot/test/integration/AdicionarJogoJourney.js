sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/AdicionarJogo"
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
		When.paginaAdicionarJogo.aoClicarNoBotaoAdicionar();
        When.paginaAdicionarJogo.aoClicarNoBotaoDeCancelar();

		//Asserções
		Then.paginaAdicionarJogo.aTelaComTituloCorrespondenteFoiCarregadaCorretamente("Jogos (20)");
	});

	opaTest("Os inputs devem ficar em estado de erro caso tente salvar com eles vazios", function (Given, When, Then) {
		//Ações
		When.paginaAdicionarJogo.aoClicarNoBotaoAdicionar();
		When.paginaAdicionarJogo.aoClicarNoBotaoSalvar();

		//Asserções
		Then.paginaAdicionarJogo.oInputComIdCorrespondenteFicouNoEstadoEsperado("idInputNome", "Error");
		Then.paginaAdicionarJogo.oInputComIdCorrespondenteFicouNoEstadoEsperado("idInputPreco", "Error");
		Then.paginaAdicionarJogo.oInputComIdCorrespondenteFicouNoEstadoEsperado("idSelectGenero", "Error");
	});

	opaTest("Os inputs devem ficar com texto de campo obrigatório caso estejam vazios", function (Given, When, Then) {
		//Asserções
		Then.paginaAdicionarJogo.oInputComIdCorrespondenteFicouComTextoDeCampoObrigatorio("idInputNome", "O campo nome é obrigatório");
		Then.paginaAdicionarJogo.oInputComIdCorrespondenteFicouComTextoDeCampoObrigatorio("idInputPreco", "O campo preço é obrigatório");
		Then.paginaAdicionarJogo.oInputComIdCorrespondenteFicouComTextoDeCampoObrigatorio("idSelectGenero", "O campo gênero é obrigatório");
	});

	opaTest("O input nome deve ficar em estado padrão caso seja preenchido", function (Given, When, Then) {
		//Ações
		When.paginaAdicionarJogo.adicionarValorAoInputNome("FarCry4");
		When.paginaAdicionarJogo.aoClicarNoBotaoSalvar();

		//Asserções
		Then.paginaAdicionarJogo.oInputComIdCorrespondenteFicouNoEstadoEsperado("idInputNome", "None");
	});

	opaTest("O input preço deve ficar em estado padrão caso seja preenchido", function (Given, When, Then) {
		//Ações
		When.paginaAdicionarJogo.limparInputNome();
		When.paginaAdicionarJogo.adicionarValorAoInputPreco("100");
		When.paginaAdicionarJogo.aoClicarNoBotaoSalvar();

		//Asserções
		Then.paginaAdicionarJogo.oInputComIdCorrespondenteFicouNoEstadoEsperado("idInputPreco", "None");
	});

	opaTest("O select gênero deve ficar em estado padrão caso seja preenchido", function (Given, When, Then) {
		//Ações
		When.paginaAdicionarJogo.limparInputPreco();
		When.paginaAdicionarJogo.selecionarGeneroNoSelect("FPS");
		When.paginaAdicionarJogo.aoClicarNoBotaoSalvar();

		//Asserções
		Then.paginaAdicionarJogo.oInputComIdCorrespondenteFicouNoEstadoEsperado("idSelectGenero", "None");
	});

	opaTest("Deve ser possível ver a caixa de mensagem de erro", function (Given, When, Then) {
		//Ações
		When.paginaAdicionarJogo.adicionarValorAoInputNome("Minecraft");
		When.paginaAdicionarJogo.adicionarValorAoInputPreco("20000");
		When.paginaAdicionarJogo.selecionarGeneroNoSelect("FPS");
		When.paginaAdicionarJogo.aoClicarNoBotaoSalvar();

		//Asserções
		Then.paginaAdicionarJogo.aCaixaDeMensagemApareceu("Erro")
	});

	opaTest("Deve ser possível clicar em visualizar detalhes", function (Given, When, Then) {
		//Ações
		When.paginaAdicionarJogo.aoClicarEmVisualizarDetalhes();
	});

	opaTest("Deve ser possível clicar em fechar na caixa de mensagem de erro", function (Given, When, Then) {
		//Ações
		When.paginaAdicionarJogo.aoClicarEmFechar();

		//Asserções
		Then.paginaAdicionarJogo.aTelaComTituloCorrespondenteFoiCarregadaCorretamente("Adicionar Jogo")
	});

	opaTest("Deve ser possível clicar em OK na caixa de mensagem de sucesso", function (Given, When, Then) {
		//Ações
		When.paginaAdicionarJogo.adicionarValorAoInputNome("FarCry 5");
		When.paginaAdicionarJogo.adicionarValorAoInputPreco("120");
		When.paginaAdicionarJogo.selecionarGeneroNoSelect("FPA");
		When.paginaAdicionarJogo.aoClicarNoBotaoSalvar();
		When.paginaAdicionarJogo.aoClicarNoBotaoDeOkNaCaixaDeMensagemDeSucesso();
		

		//Asserções
		Then.paginaAdicionarJogo.aTelaComTituloCorrespondenteFoiCarregadaCorretamente("Jogos (21)")

		//FinalizarJornada
		Then.iTeardownMyApp();
	});
});