sap.ui.define([
    'sap/m/MessageBox'
], function (MessageBox) {
    return ("ui5.codersgrowth.app.servicos.validacao",{

        mostrarMensagemDeErro: function (erro, view) {
			const propriedadesI18n = view.getModel("i18n").getResourceBundle();
			const erroDeValidacao = "Erro de validação"

			if (erro.Title === erroDeValidacao) {
				const mensagensDeErro = Object.values(erro.Extensions.ErroDeValidacao).join("\r \n");

				MessageBox.error(`${erro.Title} \n \n ${mensagensDeErro}`, {
					title: propriedadesI18n.getText("tituloMessageBoxErro"),
					id: "messageBoxErroDeValidacao",
					details: 
						`<p><strong>${propriedadesI18n.getText("statusMessageBoxErro")}:<strong> ${erro.Status}` +
						`<p><strong>${propriedadesI18n.getText("detalhesMessageBoxErro")}<strong>` +
						`<p>${erro.Detail}`,
					styleClass: "sResponsivePaddingClasses",
					dependentOn: view
				});
			}
			else {
				MessageBox.error(`${erro.Title}`, {
					title: propriedadesI18n.getText("tituloMessageBoxErro"),
					id: "messageBoxErroInesperado",
					details: 
						`<p><strong>${propriedadesI18n.getText("statusMessageBoxErro")}:<strong> ${erro.Status}` +
						`<p><strong>${propriedadesI18n.getText("detalhesMessageBoxErro")}<strong>` +
						`<p>${erro.Detail}`,
					styleClass: "sResponsivePaddingClasses",
					dependentOn: view
				});
			}
		},

        validarTela: function (jogo, view) {
            const inputNomeId = "idInputNome";
            const inputPrecoId = "idInputPreco";
            const selectGeneroId = "idSelectGenero";
            const valueStateDeErro = "Error";
            const valueStatePadrao = "None";
            const stringVazia = "";

            if (!jogo.nome || jogo.nome.trim() === stringVazia) {
                view.byId(inputNomeId).setValueState(valueStateDeErro);
            }
            else {
                view.byId(inputNomeId).setValueState(valueStatePadrao);
            }
                
            if (!jogo.preco || jogo.preco.trim() === stringVazia) {
                view.byId(inputPrecoId).setValueState(valueStateDeErro);
            }
            else {
                view.byId(inputPrecoId).setValueState(valueStatePadrao);
            }

            if (!jogo.genero) {
                view.byId(selectGeneroId).setValueState(valueStateDeErro);
            }
            else {
                view.byId(selectGeneroId).setValueState(valueStatePadrao);
            }
        },
    })
})