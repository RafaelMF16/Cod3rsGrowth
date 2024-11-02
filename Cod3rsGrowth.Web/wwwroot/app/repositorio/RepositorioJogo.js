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

        obterPorId: function (id) {
            let uri = HttpApiClient.converterEmUrl(URL_DA_CONTROLLER, id);
            return HttpApiClient.get(uri);
        },

        remover: function (id) {
            let uri = HttpApiClient.converterEmUrl(URL_DA_CONTROLLER, id);
            return HttpApiClient.delete(uri);
        },

        atualizar: function (id, dados) {
            let uri = HttpApiClient.converterEmUrl(URL_DA_CONTROLLER, id);
            return HttpApiClient.uploadPost(uri, dados);
        },

        criar: function (dados) {
            let uri = HttpApiClient.converterEmUrl(URL_DA_CONTROLLER);
            return HttpApiClient.uploadPost(uri, dados);
        },

    }
});