sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/AdicionarOuEditarJogo"
], (opaTest) => {
	"use strict";

	QUnit.module("Tela de edição de jogos");

	opaTest("Deve poder ir para tela de edição", function (Given, When, Then) {
		// Arrangements
		Given.euInicioMinhaApp({
			componentConfig: {
				name: "ui5.codersgrowth"
			}
		});

        //Ações
		When.paginaAdicionarOuEditarJogo.aoClicarNoItemDaTabela("Rust");
        When.paginaAdicionarOuEditarJogo.aoClicarNoBotaoEditar();
        

		//Asserções
		Then.paginaAdicionarOuEditarJogo.aTelaComTituloCorrespondenteFoiCarregadaCorretamente("Editar Jogo");
	});

    opaTest("Deve aparecer os dados corretos do jogo que vai ser editado", function (Given, When, Then) {
		//Asserções
		Then.paginaAdicionarOuEditarJogo.oNomeDoJogoDeveEstarCorreto();
		Then.paginaAdicionarOuEditarJogo.oPrecoDoJogoDeveEstarCorreto();
		Then.paginaAdicionarOuEditarJogo.oGeneroDoJogoDeveEstarCorreto();
	});

    opaTest("Os inputs devem ficar em estado de erro caso tente salvar com eles vazios", function (Given, When, Then) {
		//Ações
        When.paginaAdicionarOuEditarJogo.limparInputNome();
        When.paginaAdicionarOuEditarJogo.limparInputPreco();
        When.paginaAdicionarOuEditarJogo.selecionarGeneroNoSelect("Selecionar");
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
		When.paginaAdicionarOuEditarJogo.adicionarValorAoInputNome("Rust");
        When.paginaAdicionarOuEditarJogo.selecionarGeneroNoSelect("Sobrevivência");
		When.paginaAdicionarOuEditarJogo.aoClicarNoBotaoSalvar();

		//Asserções
		Then.paginaAdicionarOuEditarJogo.oInputComIdCorrespondenteFicouNoEstadoEsperado("idInputNome", "None");
		Then.paginaAdicionarOuEditarJogo.oInputComIdCorrespondenteFicouNoEstadoEsperado("idSelectGenero", "None");
	});

    opaTest("Deve ser possível ver a caixa de mensagem de erro", function (Given, When, Then) {
		//Ações
		When.paginaAdicionarOuEditarJogo.adicionarValorAoInputPreco("20000");
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
		Then.paginaAdicionarOuEditarJogo.aTelaComTituloCorrespondenteFoiCarregadaCorretamente("Editar Jogo")
	});

    opaTest("Deve ser possível clicar em OK na caixa de mensagem de sucesso", function (Given, When, Then) {
		//Ações
		When.paginaAdicionarOuEditarJogo.adicionarValorAoInputPreco("90");
		When.paginaAdicionarOuEditarJogo.aoClicarNoBotaoSalvar();
		When.paginaAdicionarOuEditarJogo.aoClicarNoBotaoDeOkNaCaixaDeMensagemDeSucesso();
		
		//Asserções
		Then.paginaAdicionarOuEditarJogo.aTelaComTituloCorrespondenteFoiCarregadaCorretamente("Jogos (21)")
	});

    opaTest("Deve poder voltar para tela de listagem ao clicar no botão cancelar", function (Given, When, Then) {
        //Ações
        When.paginaAdicionarOuEditarJogo.aoClicarNoItemDaTabela("Rust");
        When.paginaAdicionarOuEditarJogo.aoClicarNoBotaoEditar();
		When.paginaAdicionarOuEditarJogo.aoClicarNoBotaoDeCancelar();

		//Asserções
		Then.paginaAdicionarOuEditarJogo.aTelaComTituloCorrespondenteFoiCarregadaCorretamente("Jogos (21)");
	});

    opaTest("Deve poder voltar para tela de listagem ao clicar no botao nav back", function (Given, When, Then) {
        //Ações
        When.paginaAdicionarOuEditarJogo.aoClicarNoItemDaTabela("Rust");
        When.paginaAdicionarOuEditarJogo.aoClicarNoBotaoEditar();
        When.paginaAdicionarOuEditarJogo.aoClicarNoBotaoNavBack();
		
		//Asserções
		Then.paginaAdicionarOuEditarJogo.aTelaComTituloCorrespondenteFoiCarregadaCorretamente("Jogos (21)");

        //FinalizarJornada
		Then.iTeardownMyApp();
	});
});