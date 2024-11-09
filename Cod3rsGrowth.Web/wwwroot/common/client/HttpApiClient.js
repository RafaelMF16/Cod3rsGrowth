sap.ui.define([
	'sap/m/MessageBox',
    'sap/m/MessageToast'
], function (
    MessageBox,
    MessageToast
) {
	"use strict";

    const CONTENT_TYPE_JSON = "application/json";

	return { 
        get: function (url, view) {
            return fetch(url)
                .then(response => {
                    if (!response.ok){
                        response.json()
                            .then(response => {
                                this._exibirMensagemDeErro(response, view);
                            });
                    } else {
                        return response.json();
                    }
                })
                .catch(error => {
                    throw error;
                });
        },

        post: function (url, dados, view) {
            const opcoes = {
                method: 'POST',
                headers: {
                    Accept: CONTENT_TYPE_JSON,
                    'Content-Type': CONTENT_TYPE_JSON
                },
                body: JSON.stringify(dados)
            };

            return fetch(url, opcoes)
                .then(response => {
                    if (!response.ok){
                        return response.json()
                            .then(response => {
                                this._exibirMensagemDeErro(response, view);
                                throw new Error("Erro na requisição");
                            });
                    } else {
                        this._exibirMensagemDeSucesso(view);
                        return response.json()
                            .then(response => response.id);                
                    }
                })
                .catch(error => {
                    throw error;
                });
        },

        patch: function (url, dados, view) {
            const opcoes = {
                method: 'PATCH',
                headers: {
                    Accept: CONTENT_TYPE_JSON,
                    'Content-Type': CONTENT_TYPE_JSON
                },
                body: JSON.stringify(dados)
            };

            return fetch(url, opcoes)
                .then(response => {
                    if (!response.ok){
                        response.json()
                            .then(response => {
                                this._exibirMensagemDeErro(response, view);
                            });
                    } else {
                        this._exibirMensagemDeSucesso(view);               
                    }
                })
                .catch(error => {
                    throw error;
                });
        },

        delete: function (url, view) {
            const opcoes = {
                method: 'DELETE',
                headers: {
                    Accept: CONTENT_TYPE_JSON,
                    'Content-Type': CONTENT_TYPE_JSON
                },
            };

            return fetch(url, opcoes)
                .then(response => {
                    if (!response.ok){
                        response.json()
                            .then(response => {
                                this._exibirMensagemDeErro(response, view);
                            });
                    } else {
                        this._exibirMensagemDeSucesso(view);               
                    }
                })
                .catch(error => {
                    throw error;
                });
        },

        _exibirMensagemDeErro: function (error, view) {
            const erroDeValidacao = "Erro de validação"
            const propriedadesI18n = view.getModel("i18n").getResourceBundle();
            let mensagemDeErro = "";

            if (error.Title === erroDeValidacao) {
                mensagemDeErro = Object.values(error.Extensions.ErroDeValidacao).join("\r \n");
            } else {
                mensagemDeErro = "<p>Erro inesperado.</p>";
            }
        
            MessageBox.error(mensagemDeErro, {
                title: propriedadesI18n.getText("MessageBox.Erro.Titulo"),
                id: "messageBoxErroAPI",
                details: error.Detail,
                styleClass: "sResponsivePaddingClasses",
                dependentOn: view
            });
        },
        
        _exibirMensagemDeSucesso: function (view) {
            const propriedadesI18n = view.getModel("i18n").getResourceBundle();

            MessageToast.show(propriedadesI18n.getText("MessageToast.OperacaoConcluidaComSucesso"));
        }
    }
});