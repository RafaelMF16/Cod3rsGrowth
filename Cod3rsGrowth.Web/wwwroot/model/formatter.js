sap.ui.define([], () => {
    "use strict";

    return {
        formatarJogosGratis(preco) {
            const oResourceBundle = this.getOwnerComponent().getModel("i18n").getResourceBundle();

            if (preco == 0) {
                return oResourceBundle.getText("jogoComPrecoZero");
            }

            return "R$" + preco;
        },

        formatarValorPadraoComboBox(descricao) {
            const oResourceBundle = this.getOwnerComponent().getModel("i18n").getResourceBundle();

            if (descricao == "Padrão caso enum não seja definido"){
                return oResourceBundle.getText("todosOsGeneros");
            }

            return descricao;
        }   
    }
})