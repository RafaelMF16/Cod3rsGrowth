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

        validarTela: function (jogo, modeloValueState) {
            const valueStateDeErro = "Error";
            const valueStatePadrao = "None";
            const stringVazia = "";
            const generoNaoDefinido = 0;
            
            !jogo.nome || jogo.nome.trim() === stringVazia
                ? modeloValueState.valueStateNome = valueStateDeErro
                : modeloValueState.valueStateNome = valueStatePadrao
              
            !jogo.preco || jogo.preco.trim() === stringVazia
                ? modeloValueState.valueStatePreco = valueStateDeErro
                : modeloValueState.valueStatePreco = valueStatePadrao
            
            !jogo.genero || jogo.genero === generoNaoDefinido
                ? modeloValueState.valueStateGenero = valueStateDeErro
                : modeloValueState.valueStateGenero = valueStatePadrao
            
            if (jogo.nome && jogo.preco && jogo.genero)
                return true;
            else
                return false;
        },
    })
})