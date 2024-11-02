sap.ui.define([
	
], function () {
	"use strict";

	return { 
        obterTodos: function (url, view) {
            const erroAoObterDadosDaAPI = "Erro ao obter dados da API";

            return fetch(url)
                .then(response => {
                    if (response.ok)
                        return response.json();
                    else {
                        return response.json()
                            .then(error => {
                                throw new Error(error.message || erroAoObterDadosDaAPI)
                            });
                    }
                })
                .catch(error => {
                    this._exibirMensagemDeErro(error, view);
                    throw error;
                })
        },

        _exibirMensagemDeErro: function (erro, view) {
            const propriedadesI18n = view.getModel("i18n").getResourceBundle();
            const erroDeValidacao = "Erro de validação";
        
            const construirDetalhes = (status, detalhe) => {
                return `
                    <p><strong>${propriedadesI18n.getText("MessageBox.Erro.Status")}:</strong> ${status || "N/A"}</p>
                    <p><strong>${propriedadesI18n.getText("MessageBox.Erro.Detalhes")}:</strong></p>
                    <p>${detalhe || "Detalhes não disponíveis"}</p>
                `;
            };
        
            const opcoesMessageBox = {
                title: propriedadesI18n.getText("MessageBox.Erro.Titulo"),
                styleClass: "sResponsivePaddingClasses",
                dependentOn: view
            };
        
            if (erro?.Title === erroDeValidacao && erro.Extensions?.ErroDeValidacao) {
                const mensagensDeErro = Object.values(erro.Extensions.ErroDeValidacao).join("\r\n");
                
                MessageBox.error(`${erro.Title}\n\n${mensagensDeErro}`, {
                    ...opcoesMessageBox,
                    id: "messageBoxErroDeValidacao",
                    details: construirDetalhes(erro.Status, erro.Detail)
                });
            } else {
                MessageBox.error(`${erro.Title || "Erro"}`, {
                    ...opcoesMessageBox,
                    id: "messageBoxErroInesperado",
                    details: construirDetalhes(erro.Status, erro.Detail)
                });
            }
        }        
    }
});