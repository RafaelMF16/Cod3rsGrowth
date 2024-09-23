sap.ui.define([
    'ui5/codersgrowth/app/BaseController',
    '../model/formatter',
    '../servicos/validacao',
    'ui5/codersgrowth/common/ConstantesDaRota',
    'ui5/codersgrowth/common/ConstantesDoBanco'
], function(BaseController, formatter, validacao, ConstantesDaRota, ConstantesDoBanco) {
    'use strict';

    const InputNomeId = "idInputNome";
    const InputPrecoId = "idInputPreco";
    const SelectGeneroId = "idSelectGenero";
    const TituloPaginaAdicionarOuEditar = "tituloPaginasAdicionarOuEditar";
    
    var idJogo = "";
    
    return BaseController.extend("ui5.codersgrowth.app.adicionarJogo.AdicionarJogo",{
        formatter: formatter,
        validacao: validacao,
        constantesDoBanco: ConstantesDoBanco,

        onInit: function () {
            this.getRouter().getRoute("appAdicionarJogo").attachMatched(this._aoCoincidirRota, this);
        },

        _aoCoincidirRota: function (oEvent) {
            const nomeListaGeneros = "listaGeneros";
            const tituloPaginaEditar = "Editar Jogo";
            const titutloPaginaAdicionar = "Adicionar Jogo";
            const viewAdicionarJogo = this._obterViewAdicionarJogo();
            
            this._obterIdJogoPelaRota(oEvent);
            
            this.fazerRequisicaoGet(ConstantesDoBanco.CAMINHO_PARA_API_GENERO, nomeListaGeneros, viewAdicionarJogo);
            
            if (idJogo){
                const urlObterPorId = ConstantesDoBanco.CAMINHO_PARA_API_JOGO + `/${idJogo}`;

                this._mudarTituloDaPagina(tituloPaginaEditar);
                this._limparValueState();
                this.fazerRequisicaoObterPorId(urlObterPorId, viewAdicionarJogo);
            } else {
                this._mudarTituloDaPagina(titutloPaginaAdicionar);
                this._limparCampos();
                this._limparValueState();
            }
        },

        _obterViewAdicionarJogo(){
            return this.getView();
        },

        _obterIdJogoPelaRota(evento) {
            idJogo = evento.getParameters().arguments.jogoId;
        },

        _limparCampos: function () {
            this.getView().byId(InputNomeId).setValue("");
            this.getView().byId(InputPrecoId).setValue();
            this.getView().byId(SelectGeneroId).setSelectedKey();
        },

        _limparValueState: function () {
            const valueStatePadrao = "None";

            this.getView().byId(InputNomeId).setValueState(valueStatePadrao);
            this.getView().byId(InputPrecoId).setValueState(valueStatePadrao);
            this.getView().byId(SelectGeneroId).setValueState(valueStatePadrao);
        },

        _pegarValorDosCampos: function () {
            const generoNaoDefinido = "NAODEFINIDO";

            let valorInputNome = this.getView().byId(InputNomeId).getValue();
            let valorInputPreco = this.getView().byId(InputPrecoId).getValue();
            let valorSelectGenero = parseInt(this.getView().byId(SelectGeneroId).getSelectedKey());

            let jogo = {};

            if (valorInputNome)
                jogo.nome = valorInputNome;

            if (valorInputPreco)
                jogo.preco = valorInputPreco;

            if (valorSelectGenero != generoNaoDefinido)
                jogo.genero = valorSelectGenero;

            if (idJogo)
                jogo.id = idJogo;

            return jogo;
        },

        _mudarTituloDaPagina: function (titulo) {
            this.getView().byId(TituloPaginaAdicionarOuEditar).setText(titulo);
        },

        _prepararMensagemDeAtencao: function () {
            const propriedadesI18n = this.getView().getModel("i18n").getResourceBundle();
            const mensagem = "Tem certeza que deseja cancelar?"
            const viewAdicionarJogo = this.getView();
            this.mostrarMensagemDeAviso(viewAdicionarJogo, propriedadesI18n, mensagem, idJogo);
        },

        salvarJogo: function () {
            const jogo = this._pegarValorDosCampos();
            const viewAdicionarJogo = this.getView();
            const opcoes = {
                method: 'POST',
                body: JSON.stringify(jogo),
                headers: {
                    "Content-type": "application/json; charset=UTF-8"
                }
            };
            
            if (idJogo) {
                opcoes.method = 'PATCH'
            }

            if (this.validacao.validarTela(jogo, viewAdicionarJogo))
                this.fazerRequisicaoPostOuPatch(ConstantesDoBanco.CAMINHO_PARA_API_JOGO, opcoes, jogo, viewAdicionarJogo);
        },

        cancelarAdicaoDeJogo: function () {
            this._prepararMensagemDeAtencao();
        },

        colocarValorNoInput: function (jogo) {
            const generos = this.getView().byId(SelectGeneroId).getItems();
            const generoQueVaiSerSelecionadoNoSelect = generos.find(genero => genero.mProperties.text === jogo.genero);
            
            this.getView().byId(InputNomeId).setValue(jogo.nome);
            this.getView().byId(InputPrecoId).setValue(jogo.preco);
            this.getView().byId(SelectGeneroId).setSelectedItem(generoQueVaiSerSelecionadoNoSelect);
        },

        aoClicarVoltarParaTelaDeListagem: function () {
            this.navegarPara(ConstantesDaRota.NOME_DA_ROTA_DA_LISTAGEM_DE_JOGOS);
        }
    });
});