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

        formatarValorPadraoComboBox(descricao) {
            const oResourceBundle = this.getOwnerComponent().getModel("i18n").getResourceBundle();
            const enumNaoDefinido = "Não definido";

            if (descricao === enumNaoDefinido){
                return oResourceBundle.getText("todosOsGeneros");
            }

            return descricao;
        }   
    }
})