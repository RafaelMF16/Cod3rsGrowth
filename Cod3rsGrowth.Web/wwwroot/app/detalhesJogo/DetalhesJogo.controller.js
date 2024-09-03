sap.ui.define([
    'ui5/codersgrowth/app/BaseController',
    '../model/formatter',
    'sap/m/MessageBox'
], function (BaseController, formatter, MessageBox) {
    'use strict';

    var idJogo = "";

    return BaseController.extend("ui5.codersgrowth.app.detalhesJogo.DetalhesJogo", {
        formatter: formatter,
        onInit: function() {
            this.getRouter().getRoute("appDetalhesJogo").attachMatched(this._aoCoincidirRota, this);
        },

        _aoCoincidirRota: function(evento) {
            idJogo = this._obterIdJogoPelaRota(evento);
            const viewDetalhesJogo = this.getView();
            const jogo = "jogo";
            const urlObterPorId = `/api/JogoControlador/${idJogo}`

            this.fazerRequisicaoGet(urlObterPorId, jogo, viewDetalhesJogo);
        },

        _obterIdJogoPelaRota(evento) {
            const idJogo = evento.getParameters().arguments.jogoId;

            return idJogo;
        },

        _navegarPara(nomeRota){
            this.getRouter()
                .navTo(nomeRota, {
                    jogoId: idJogo
                });
        },

        _pegarNomeDoJogo: function () {
            const detalhesJogoTituloId = "idJogoNomeTitulo";
            const tituloDetalhes = "Detalhes:"
            const nomeJogoPosicao = 1;
            let tituloJogo = this.getView().byId(detalhesJogoTituloId).mProperties.text.split(tituloDetalhes)[nomeJogoPosicao];
            
            return tituloJogo;
        },

        _mostrarMensagemDeAtencao: function () {
            const propriedadesI18n = this.getView().getModel("i18n").getResourceBundle();

            const viewDetalhesJogo = this.getView();

            const opcoes = {
                method: 'DELETE',
                headers: {
                    "Content-type": "application/json; charset=UTF-8"
                }
            };

            let jogoNome = this._pegarNomeDoJogo();

            MessageBox.warning(`Tem certeza que deseja remover o ${jogoNome}`, {
                title: propriedadesI18n.getText("tituloMessageBoxAtencao"),
                id: "messageBoxAtencaoId",
                styleClass: "sResponsivePaddingClasses",
                dependentOn: this.getView(),
                actions: [MessageBox.Action.OK, MessageBox.Action.CANCEL],
                onClose: (sAction) => {
                    if (sAction === MessageBox.Action.OK) {
                        const urlDeletarJogo = `/api/JogoControlador/${idJogo}`
                        this.fazerRequisicaoDelete(urlDeletarJogo, opcoes, jogoNome, viewDetalhesJogo);
                    }
                }
            });
        },

        aoClicarIrParaEdicao: function () {
            const rotaAdicionarJogo = "appAdicionarJogo";
            this._navegarPara(rotaAdicionarJogo);
        },

        aoClicarRemoverJogo: function () {
            this._mostrarMensagemDeAtencao();
        }
    })
})