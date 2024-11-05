sap.ui.define([
    'sap/m/MessageBox'
], function (MessageBox) {
    return ("ui5.codersgrowth.app.servicos.validacao",{

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