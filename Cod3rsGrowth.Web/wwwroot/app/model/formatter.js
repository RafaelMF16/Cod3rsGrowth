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
                return propriedadesI18n.getText("textoDoValorPadraoDoSelectFiltroGenero");
            }

            return descricao;
        },

        formatarValorPadraoSelectParaTelaDeCriacao(descricao) {
            const propriedadesI18n = this.getOwnerComponent().getModel("i18n").getResourceBundle();
            const enumNaoDefinido = "Não definido";

            if (descricao === enumNaoDefinido){
                return propriedadesI18n.getText("textoDoValorPadraoDoSelectGeneroAdicionarJogo");
            }

            return descricao;
        },

        formatarStatusTexto(status){
            const propriedadesI18n = this.getOwnerComponent().getModel("i18n").getResourceBundle();
            
            if (status === true){
                return propriedadesI18n.getText("textoStatusAprovado");
            }
            
            return propriedadesI18n.getText("textoStatusReprovado");
        },

        formatarStatus(status){
            const propriedadesI18n = this.getOwnerComponent().getModel("i18n").getResourceBundle();

            if (status === true)
                return propriedadesI18n.getText("statusAprovado");

            return propriedadesI18n.getText("statusReprovado");
        },

        formatarData(dataRealizacao) {
            let data = new Date(dataRealizacao);

            let dia = data.getDate().toString().padStart(2, "0");
            let mes = (data.getMonth() + 1).toString().padStart(2, "0");
            let ano = data.getFullYear();

            return `${dia}/${mes}/${ano}`
        }
    }
})