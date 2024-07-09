using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servico.Servicos;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;

namespace Cod3rsGrowth.Forms
{
    public partial class TelaCadastroTesteDeJogo : Form
    {
        private readonly ServicoTesteDeJogo _servicoTesteDeJogo;
        private readonly ServicoJogo _servicoJogo;
        private TesteDeJogo _testeDeJogoQueVaiSerAtualizado;
        private const MessageBoxButtons BotaoOkDaCaixaDeMensagem = MessageBoxButtons.OK;

        public TelaCadastroTesteDeJogo(ServicoTesteDeJogo servicoTesteDeJogo, ServicoJogo servicoJogo, TesteDeJogo testeDeJogo = null)
        {
            InitializeComponent();

            _servicoTesteDeJogo = servicoTesteDeJogo;
            _servicoJogo = servicoJogo;
            _testeDeJogoQueVaiSerAtualizado = testeDeJogo;

            var comboBoxJogos = _servicoJogo.ObterTodos().Select(j => j.Nome).ToList();
            comboBoxJogoCadastro.DataSource = comboBoxJogos;

            if (testeDeJogo != null)
                MostrarPropriedadesDoTesteDeJogoQueVaiSerAtualizado();
        }

        public void MostrarPropriedadesDoTesteDeJogoQueVaiSerAtualizado()
        {
            textBoxCadastroNomeResponsavel.Text = _testeDeJogoQueVaiSerAtualizado.NomeResponsavelDoTeste;
            textBoxCadastroDescricao.Text = _testeDeJogoQueVaiSerAtualizado.Descricao;
            numericUpDownCadastroNota.Value = _testeDeJogoQueVaiSerAtualizado.Nota;
            comboBoxJogoCadastro.SelectedItem = _servicoJogo.ObterPorId(_testeDeJogoQueVaiSerAtualizado.IdJogo).Nome;
            checkBoxCadastroAprovado.Checked = _testeDeJogoQueVaiSerAtualizado.Aprovado;
        }

        private void EventoCancelaCadastroDeTesteDeJogo(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void EventoQueSalvaTesteDeJogo(object sender, EventArgs e)
        {
            var idJogo = _servicoJogo.ObterTodos().Where(j => j.Nome == comboBoxJogoCadastro.SelectedItem.ToString()).Select(j => j.Id).FirstOrDefault();
            const string tituloDaCaixaDeMensagem = "Erro de validação";
            const MessageBoxIcon iconeDeErroDaCaixaDeMensagem = MessageBoxIcon.Error;

            if (!ValidarTela())
                return;

            try
            {
                if (_testeDeJogoQueVaiSerAtualizado != null)
                {
                    var testeDeJogoAtualizado = new TesteDeJogo
                    {
                        Id = _testeDeJogoQueVaiSerAtualizado.Id,
                        NomeResponsavelDoTeste = textBoxCadastroNomeResponsavel.Text,
                        Descricao = textBoxCadastroDescricao.Text,
                        Nota = numericUpDownCadastroNota.Value,
                        DataRealizacaoTeste = DateTime.Today,
                        IdJogo = idJogo,
                        Aprovado = checkBoxCadastroAprovado.Checked
                    };

                    _servicoTesteDeJogo.Atualizar(testeDeJogoAtualizado);

                    this.Dispose();

                    return;
                }

                var novoTesteDeJogo = new TesteDeJogo
                {
                    NomeResponsavelDoTeste = textBoxCadastroNomeResponsavel.Text,
                    Descricao = textBoxCadastroDescricao.Text,
                    Nota = numericUpDownCadastroNota.Value,
                    DataRealizacaoTeste = DateTime.Today,
                    Aprovado = checkBoxCadastroAprovado.Checked,
                    IdJogo = idJogo
                };

                _servicoTesteDeJogo.Adicionar(novoTesteDeJogo);

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

        private static void MostrarMensagemErro(string mensagemDeErro, string tituloErro, MessageBoxButtons botaoCaixaDeMensagem, MessageBoxIcon iconeCaixaDeMensagem)
        {
            MessageBox.Show(mensagemDeErro, tituloErro, botaoCaixaDeMensagem, iconeCaixaDeMensagem);
        }

        private bool ValidarTela()
        {
            const string tituloDaCaixaDeMensagem = "Campo não preenchido";
            const MessageBoxIcon iconeDaCaixaDeMensagem = MessageBoxIcon.Warning;

            if (textBoxCadastroNomeResponsavel.Text.IsNullOrEmpty())
            {
                const string mensagemDeErroDeValidacaoDeTela = "Preencha o campo nome do responsável";

                MostrarMensagemErro(mensagemDeErroDeValidacaoDeTela, tituloDaCaixaDeMensagem, BotaoOkDaCaixaDeMensagem, iconeDaCaixaDeMensagem);

                return false;
            }

            return true;
        }
    }
}