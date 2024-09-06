sap.ui.define([], () => {
    "use strict";

    return {
        formatarJogosGratis(preco) {
            const oResourceBundle = this.getOwnerComponent().getModel("i18n").getResourceBundle();
            const menorValor = 0;
            
            if (preco === menorValor) {
                return oResourceBundle.getText("jogoComPrecoZero");
            }

            return "R$" + preco;
        },

        formatarValorPadraoSelectParaTelaDeListagem(descricao) {
            const propriedadesI18n = this.getOwnerComponent().getModel("i18n").getResourceBundle();
            const enumNaoDefinido = "Não definido";

            if (descricao === enumNaoDefinido){
                return propriedadesI18n.getText("todosOsGeneros");
            }

            return descricao;
        },

        formatarValorPadraoSelectParaTelaDeCriacao(descricao) {
            const propriedadesI18n = this.getOwnerComponent().getModel("i18n").getResourceBundle();
            const enumNaoDefinido = "Não definido";

            if (descricao === enumNaoDefinido){
                return propriedadesI18n.getText("SelecioneUmGenero");
            }

            return descricao;
        }
    }
})