using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.EnumGenero;
using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Servico.Servicos;

namespace Cod3rsGrowth.Forms
{
    public partial class TelaListagem : Form
    {
        private readonly ServicoJogo _servicoJogo;
        private readonly ServicoTesteDeJogo _servicoTesteDeJogo;
        private FiltroJogo _filtroJogo = new FiltroJogo();
        private FiltroTesteDeJogo _filtroTesteDejogo = new FiltroTesteDeJogo();
        const string tituloDaCaixaDeMensagem = "Erro";
        const MessageBoxButtons botaoDaCaixaDeMensagem = MessageBoxButtons.OK;
        const MessageBoxIcon iconeDaCaixaDeMensagem = MessageBoxIcon.Warning;

        public TelaListagem(ServicoJogo servicoJogo, ServicoTesteDeJogo servicoTesteDeJogo)
        {
            InitializeComponent();
            _servicoJogo = servicoJogo;
            _servicoTesteDeJogo = servicoTesteDeJogo;
        }

        private void CarregarPrimeiraTela(object sender, EventArgs e)
        {
            Obterjogos(_filtroJogo);

            ObterTestesDeJogo(_filtroTesteDejogo);

            const int valorPadraoGenero = 0;
            comboBoxEnum.SelectedIndex = valorPadraoGenero;

            FormatarColunaIdJogo();
        }

        private void EventoDePesquisaPorNomeDoJogo(object sender, EventArgs e)
        {
            _filtroJogo.Nome = textBoxJogo.Text;
            Obterjogos(_filtroJogo);
        }

        private void EventoDeFiltroPorGenero(object sender, EventArgs e)
        {
            _filtroJogo.Genero = (Genero)comboBoxEnum.SelectedIndex;
            Obterjogos(_filtroJogo);
        }

        private void EventoDeFiltroPorPrecoMin(object sender, EventArgs e)
        {
            _filtroJogo.PrecoMin = numericUpDownPrecoMin.Value;
            Obterjogos(_filtroJogo);
        }

        private void EventoDeFiltroPorPrecoMax(object sender, EventArgs e)
        {
            _filtroJogo.PrecoMax = numericUpDownPrecoMax.Value;
            Obterjogos(_filtroJogo);
        }

        private void EventoDePesquisaPorNomeDoResponsavel(object sender, EventArgs e)
        {
            _filtroTesteDejogo.NomeResponsavelTeste = textBoxTDJ.Text;
            ObterTestesDeJogo(_filtroTesteDejogo);
        }

        private void EventoDeFiltroPorAprovado(object sender, EventArgs e)
        {
            if (checkBoxAprovado.CheckState == CheckState.Checked && checkBoxReprovado.CheckState == CheckState.Checked)
            {
                checkBoxReprovado.Checked = false;
                checkBoxAprovado.Checked = true;
            }

            _filtroTesteDejogo.Aprovado = checkBoxAprovado.Checked;

            ObterTestesDeJogo(_filtroTesteDejogo);
        }

        private void EventoDeFiltroPorReprovado(object sender, EventArgs e)
        {
            if (checkBoxReprovado.CheckState == CheckState.Checked && checkBoxAprovado.CheckState == CheckState.Checked)
            {
                checkBoxAprovado.Checked = false;
                checkBoxReprovado.Checked = true;
            }

            _filtroTesteDejogo.Reprovado = checkBoxReprovado.Checked;

            ObterTestesDeJogo(_filtroTesteDejogo);
        }

        private void EventoDeFiltroPorDataMinima(object sender, EventArgs e)
        {
            _filtroTesteDejogo.DataMinRealizacaoTeste = dateTimePickerDataInicial.Value.Date;
            ObterTestesDeJogo(_filtroTesteDejogo);
        }

        private void EventoDeFiltroPorDataMaxima(object sender, EventArgs e)
        {
            _filtroTesteDejogo.DataMaxRealizacaoTeste = dateTimePickerDataFinal.Value.Date;
            ObterTestesDeJogo(_filtroTesteDejogo);
        }

        private void EventoDeResetDeData(object sender, EventArgs e)
        {
            LimparFiltroDeData(_filtroTesteDejogo);
            ObterTestesDeJogo(_filtroTesteDejogo);
        }

        private void LimparFiltroDeData(FiltroTesteDeJogo filtroTesteDeJogo)
        {
            filtroTesteDeJogo.DataMinRealizacaoTeste = null;
            filtroTesteDeJogo.DataMaxRealizacaoTeste = null;
        }

        private void FormatarColunaIdJogo()
        {
            tabelaTesteDeJogo.AutoGenerateColumns = false;
            tabelaTesteDeJogo.CellFormatting += EventoDeFormatacaoDaCelulaIdJogo;
        }

        private void EventoDeFormatacaoDaCelulaIdJogo(object sender, DataGridViewCellFormattingEventArgs e)
        {
            const string NomeDaColunaJogo = "Jogo";

            if (tabelaTesteDeJogo.Columns[e.ColumnIndex].HeaderText == NomeDaColunaJogo)
            {
                var testeDeJogo = tabelaTesteDeJogo.Rows[e.RowIndex].DataBoundItem as TesteDeJogo;

                if (testeDeJogo != null)
                {
                    var jogo = _servicoJogo.ObterPorId(testeDeJogo.IdJogo);

                    if (jogo != null)
                        e.Value = jogo.Nome;
                }
            }
        }

        private void EventoParaAbrirTelaDeCadastroDeJogo(object sender, EventArgs e)
        {
            var telaCadastroJogo = new TelaCadastroJogo(_servicoJogo);
            telaCadastroJogo.ShowDialog();
            Obterjogos(_filtroJogo);
        }

        private void EventoParaAbrirTelaDeCadastroDeTesteDeJogo(object sender, EventArgs e)
        {
            var telaCadastroDeTesteDeJogo = new TelaCadastroTesteDeJogo(_servicoTesteDeJogo, _servicoJogo);
            telaCadastroDeTesteDeJogo.ShowDialog();
            ObterTestesDeJogo(_filtroTesteDejogo);
        }

        private void EventoQueDeletaJogoDoBancoDeDados(object sender, EventArgs e)
        {
            const int colunaId = 0;
            const int colunaNome = 1;

            var mensagemMostrada = MostrarMensagemDeErroTabelaJogo(tituloDaCaixaDeMensagem, botaoDaCaixaDeMensagem, iconeDaCaixaDeMensagem);

            if (mensagemMostrada == true)
                return;

            try
            {
                var idJogoQueVaiSerRemovido = (int)tabelaJogo.CurrentRow.Cells[colunaId].Value;
                var nomeJogoQueVaiSerRemovido = tabelaJogo.CurrentRow.Cells[colunaNome].Value;
                var mensagemDeAviso = MessageBox.Show($"Todos os testes relacionados com {nomeJogoQueVaiSerRemovido} serão removidos. Deseja remover o jogo {nomeJogoQueVaiSerRemovido}?",
                    "Remover Jogo", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (mensagemDeAviso == DialogResult.Yes)
                {
                    _servicoJogo.Deletar(idJogoQueVaiSerRemovido);

                    Obterjogos(_filtroJogo);
                    ObterTestesDeJogo(_filtroTesteDejogo);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void EventoQueDeletaTesteDeJogoDoBancoDeDados(object sender, EventArgs e)
        {
            const int colunaId = 0;

            var mensagemMostrada = MostrarMensagemDeErroTabelaTesteDeJogo(tituloDaCaixaDeMensagem, botaoDaCaixaDeMensagem, iconeDaCaixaDeMensagem);

            if (mensagemMostrada == true)
                return;

            try
            {
                var idTesteDeJogoQueVaiSerRemovido = (int)tabelaTesteDeJogo.CurrentRow.Cells[colunaId].Value;
                var mensagemDeAviso = MessageBox.Show($"Deseja remover o teste de jogo?", "Remover Teste de Jogo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (mensagemDeAviso == DialogResult.Yes)
                {
                    _servicoTesteDeJogo.Deletar(idTesteDeJogoQueVaiSerRemovido);

                    ObterTestesDeJogo(_filtroTesteDejogo);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void EventoQueAbreTelaDeAtualizacaoDeJogo(object sender, EventArgs e)
        {
            var mensagemMostrada = MostrarMensagemDeErroTabelaJogo(tituloDaCaixaDeMensagem, botaoDaCaixaDeMensagem, iconeDaCaixaDeMensagem);

            if (mensagemMostrada == true)
                return;

            const int colunaId = 0;
            var idJogoQueVaiSerAtualizado = (int)tabelaJogo.CurrentRow.Cells[colunaId].Value;
            var jogoSelecionado = _servicoJogo.ObterPorId(idJogoQueVaiSerAtualizado);
            var telaDeAtualizacao = new TelaCadastroJogo(_servicoJogo, jogoSelecionado);

            telaDeAtualizacao.ShowDialog();

            tabelaJogo.DataSource = _servicoJogo.ObterTodos();
        }

        private void EventoQueAbreTelaDeAtualizacaoDeTesteDeJogo(object sender, EventArgs e)
        {
            var mensagemMostrada = MostrarMensagemDeErroTabelaTesteDeJogo(tituloDaCaixaDeMensagem, botaoDaCaixaDeMensagem, iconeDaCaixaDeMensagem);

            if (mensagemMostrada == true)
                return;

            const int colunaId = 0;
            var idTesteDeJogoQueVaiSerAtualizado = (int)tabelaTesteDeJogo.CurrentRow.Cells[colunaId].Value;
            var testeDeJogoSelecionado = _servicoTesteDeJogo.ObterPorId(idTesteDeJogoQueVaiSerAtualizado);
            var telaDeAtualizacao = new TelaCadastroTesteDeJogo(_servicoTesteDeJogo, _servicoJogo, testeDeJogoSelecionado);

            telaDeAtualizacao.ShowDialog();

            ObterTestesDeJogo(_filtroTesteDejogo);
        }

        private void Obterjogos(FiltroJogo filtroJogo)
        {
            tabelaJogo.DataSource = _servicoJogo.ObterTodos(filtroJogo);
        }

        private void ObterTestesDeJogo(FiltroTesteDeJogo filtroTesteDeJogo)
        {
            tabelaTesteDeJogo.DataSource = _servicoTesteDeJogo.ObterTodos(filtroTesteDeJogo);
        }

        private bool MostrarMensagemDeErroTabelaJogo(string tituloDaCaixaDeMensagem, MessageBoxButtons botaoDaCaixaDeMensagem, MessageBoxIcon iconeDaCaixaDeMensagem)
        {
            var mensagemDeErro = "";

            if (tabelaJogo.SelectedRows.Count == decimal.Zero)
            {
                mensagemDeErro = "Nenhum jogo foi selecionado";

                MessageBox.Show(mensagemDeErro, tituloDaCaixaDeMensagem, botaoDaCaixaDeMensagem, iconeDaCaixaDeMensagem);

                return true;
            }

            if (tabelaJogo.SelectedRows.Count > decimal.One)
            {
                mensagemDeErro = "Selecione apenas um jogo";

                MessageBox.Show(mensagemDeErro, tituloDaCaixaDeMensagem, botaoDaCaixaDeMensagem, iconeDaCaixaDeMensagem);

                return true;
            }

            return false;
        }

        private bool MostrarMensagemDeErroTabelaTesteDeJogo(string tituloDaCaixaDeMensagem, MessageBoxButtons botaoDaCaixaDeMensagem, MessageBoxIcon iconeDaCaixaDeMensagem)
        {
            var mensagemDeErro = "";

            if (tabelaTesteDeJogo.SelectedRows.Count == decimal.Zero)
            {
                mensagemDeErro = "Nenhum teste de jogo foi selecionado";

                MessageBox.Show(mensagemDeErro, tituloDaCaixaDeMensagem, botaoDaCaixaDeMensagem, iconeDaCaixaDeMensagem);

                return true;
            }

            if (tabelaTesteDeJogo.SelectedRows.Count > decimal.One)
            {
                mensagemDeErro = "Selecione apenas um teste de jogo";

                MessageBox.Show(mensagemDeErro, tituloDaCaixaDeMensagem, botaoDaCaixaDeMensagem, iconeDaCaixaDeMensagem);

                return true;
            }

            return false;
        }
    }
}