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
        private const MessageBoxButtons BotaoOkDaCaixaDeMensagem = MessageBoxButtons.OK;

        public TelaCadastroJogo(ServicoJogo servicoJogo, Jogo jogo = null)
        {
            InitializeComponent();

            const int valorPadraoComboBox = 0;

            _servicoJogo = servicoJogo;

            _jogoQueVaiSerAtualizado = jogo;

            comboBoxEnumCadastro.SelectedIndex = valorPadraoComboBox;

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
            const MessageBoxIcon iconeDeErroDaCaixaDeMensagem = MessageBoxIcon.Error;
            const string tituloDaCaixaDeMensagem = "Erro de validação";

            if(ValidarTela() == false) 
                return;

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

                MostrarMensagemErro(mensagemDeErro, tituloDaCaixaDeMensagem, BotaoOkDaCaixaDeMensagem, iconeDeErroDaCaixaDeMensagem);
            }
            catch (Exception ex)
            {
                const string tituloDoErro = "Erro inesperado";
                MostrarMensagemErro(ex.Message, tituloDoErro, BotaoOkDaCaixaDeMensagem, iconeDeErroDaCaixaDeMensagem);
            }
        }

        private static void MostrarMensagemErro(string mensagemDeErro, string tituloErro, MessageBoxButtons botaoDaCaixaDeMensagem, MessageBoxIcon iconeDaCaixaDeMensagem)
        {
            MessageBox.Show(mensagemDeErro, tituloErro, botaoDaCaixaDeMensagem, iconeDaCaixaDeMensagem);
        }

        private bool ValidarTela()
        {
            const string tituloDaCaixaDeMensagem = "Campo não preenchido";
            const MessageBoxIcon iconeDaCaixaDeMensagem = MessageBoxIcon.Warning;
            var mensagemDeErro = "";

            if (textBoxCadastroNome.Text.IsNullOrEmpty())
            {
                mensagemDeErro += "Preencha o campo nome \n";
            }
            if (comboBoxEnumCadastro.SelectedIndex == decimal.Zero)
            {
                mensagemDeErro += "Preencha o campo Gênero";
            }
            if (mensagemDeErro.IsNullOrEmpty())
                return true;

            MostrarMensagemErro(mensagemDeErro, tituloDaCaixaDeMensagem, BotaoOkDaCaixaDeMensagem, iconeDaCaixaDeMensagem);
            return false;
        }
    }
}