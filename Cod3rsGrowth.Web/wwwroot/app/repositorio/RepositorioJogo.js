sap.ui.define([
    "ui5/codersgrowth/common/client/HttpApiClient",
    "ui5/codersgrowth/common/ConstantesDoBanco"
], function (
    HttpApiClient,
    ConstantesDoBanco
) {
    "use strict";

    return {
        obterTodosJogos: function (filtros, view) {
            let url = ConstantesDoBanco.CAMINHO_PARA_API_JOGO;
            
            if (filtros) {
                let urlParams = new URLSearchParams(filtros);
                let queryParams = urlParams.toString();
                url += queryParams 
                    ? `?${queryParams}` 
                    : '';
            }
            return HttpApiClient.obterTodos(url, view);
        },

        obterTodosGeneros: function (view) {
            let url = ConstantesDoBanco.CAMINHO_PARA_API_GENERO;

            return HttpApiClient.obterTodos(url, view);
        },

        obterPorId: function (id, view) {
            let url = `${ConstantesDoBanco.CAMINHO_PARA_API_JOGO}/${id}`;
            return HttpApiClient.get(url, view);
        },

        remover: function (id, view) {
            let url = `${ConstantesDoBanco.CAMINHO_PARA_API_JOGO}/${id}`;
            return HttpApiClient.delete(url, view);
        },

        atualizar: function (dados, view) {
            let url = ConstantesDoBanco.CAMINHO_PARA_API_JOGO
            return HttpApiClient.uploadPost(url, dados, view);
        },
        
        criar: function (dados, view) {
            let url = ConstantesDoBanco.CAMINHO_PARA_API_JOGO;

            return HttpApiClient.criar(url, dados, view);
        },

    }
});