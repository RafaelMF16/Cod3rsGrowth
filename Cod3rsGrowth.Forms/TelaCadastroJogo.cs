using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.EnumGenero;
using Cod3rsGrowth.Servico.Servicos;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;

namespace Cod3rsGrowth.Forms
{
    public partial class TelaCadastroJogo : Form
    {
        private readonly ServicoJogo _servicoJogo;
        private Jogo? _jogoQueVaiSerAtualizado;
        public TelaCadastroJogo(ServicoJogo servicoJogo, Jogo jogo = null)
        {
            InitializeComponent();

            _servicoJogo = servicoJogo;

            _jogoQueVaiSerAtualizado = jogo;

            if (_jogoQueVaiSerAtualizado != null)
                MostrarPropriedadesDoJogoQueVaiSerAtualizado(_jogoQueVaiSerAtualizado);
        }

        public void MostrarPropriedadesDoJogoQueVaiSerAtualizado(Jogo jogo)
        {
            textBoxCadastroNome.Text = jogo.Nome;
            comboBoxEnumCadastro.SelectedIndex = (int)jogo.Genero;
            numericUpDownCadastroPreco.Value = jogo.Preco;
        }

        private void EventoDeCancelarCadastro(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void EventoQueSalvaJogoNoBancoDeDados(object sender, EventArgs e)
        {
            const MessageBoxButtons botaoOkDaCaixaDeMensagem = MessageBoxButtons.OK;
            const MessageBoxIcon iconeDeErroDaCaixaDeMensagem = MessageBoxIcon.Error;
            const string tituloDoErroDeValidacao = "Erro de validação";

            if (textBoxCadastroNome.Text.IsNullOrEmpty())
            {
                const string mensagemDeErroDaValidacaoDeTelaNome = "Preencha o campo nome";

                MostrarMensagemErro(mensagemDeErroDaValidacaoDeTelaNome, tituloDoErroDeValidacao, botaoOkDaCaixaDeMensagem, iconeDeErroDaCaixaDeMensagem);
            }
            else if (comboBoxEnumCadastro.SelectedIndex == decimal.Zero)
            {
                const string mensagemDeErroDaValidacaoDeTelaGenero = "Preencha o campo Gênero";

                MostrarMensagemErro(mensagemDeErroDaValidacaoDeTelaGenero, tituloDoErroDeValidacao, botaoOkDaCaixaDeMensagem, iconeDeErroDaCaixaDeMensagem);
            }
            else
            {
                try
                {
                    if (_jogoQueVaiSerAtualizado != null)
                    {
                        var jogoAtualizado = new Jogo
                        {
                            Id = _jogoQueVaiSerAtualizado.Id,
                            Nome = textBoxCadastroNome.Text,
                            Genero = (Genero)comboBoxEnumCadastro.SelectedIndex,
                            Preco = numericUpDownCadastroPreco.Value
                        };

                        _servicoJogo.Atualizar(jogoAtualizado);

                        this.Dispose();

                        return;
                    }

                    var novoJogo = new Jogo
                    {
                        Nome = textBoxCadastroNome.Text,
                        Genero = (Genero)comboBoxEnumCadastro.SelectedIndex,
                        Preco = numericUpDownCadastroPreco.Value
                    };

                    _servicoJogo.Adicionar(novoJogo);

                    this.Dispose();
                }
                catch (ValidationException validationException)
                {

                    var listaDeErros = validationException.Errors.ToList();
                    var mensagemDeErro = "";

                    listaDeErros.ForEach(erro => mensagemDeErro += $"{erro.ToString()} \n");

                    MostrarMensagemErro(mensagemDeErro, tituloDoErroDeValidacao, botaoOkDaCaixaDeMensagem, iconeDeErroDaCaixaDeMensagem);
                }
                catch (Exception ex)
                {
                    const string tituloDoErro = "Erro inesperado";
                    MostrarMensagemErro(ex.Message, tituloDoErro, botaoOkDaCaixaDeMensagem, iconeDeErroDaCaixaDeMensagem);
                }
            }
        }

        private static void MostrarMensagemErro(string mensagemDeErro, string tituloErro, MessageBoxButtons botaoDaCaixaDeMensagem, MessageBoxIcon iconeDaCaixaDeMensagem)
        {
            MessageBox.Show(mensagemDeErro, tituloErro, botaoDaCaixaDeMensagem, iconeDaCaixaDeMensagem);
        }
    }
}