sap.ui.define([], () => {
    "use strict";

    return {
        formatarJogosGratis(sStatus) {
            const oResourceBundle = this.getOwnerComponent().getModel("i18n").getResourceBundle(); 

            if (sStatus == 0) {
                return oResourceBundle.getText("jogoComPrecoZero");
            }

            return "R$" + sStatus;
        }
    }
})