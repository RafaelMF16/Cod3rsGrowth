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

        public TelaListagem(ServicoJogo servicoJogo, ServicoTesteDeJogo servicoTesteDeJogo)
        {
            InitializeComponent();
            _servicoJogo = servicoJogo;
            _servicoTesteDeJogo = servicoTesteDeJogo;
        }

        private void CarregarPrimeiraTela(object sender, EventArgs e)
        {
            tabelaJogo.DataSource = _servicoJogo.ObterTodos();

            tabelaTesteDeJogo.DataSource = _servicoTesteDeJogo.ObterTodos();

            const int valorPadraoGenero = 0;
            comboBoxEnum.SelectedIndex = valorPadraoGenero;

            FormatarColunaIdJogo();
        }

        private void EventoDePesquisaPorNomeDoJogo(object sender, EventArgs e)
        {
            _filtroJogo.Nome = textBoxJogo.Text;
            tabelaJogo.DataSource = _servicoJogo.ObterTodos(_filtroJogo);
        }

        private void EventoDeFiltroPorGenero(object sender, EventArgs e)
        {
            _filtroJogo.Genero = (Genero)comboBoxEnum.SelectedIndex;
            tabelaJogo.DataSource = _servicoJogo.ObterTodos(_filtroJogo);
        }

        private void EventoDeFiltroPorPrecoMin(object sender, EventArgs e)
        {
            _filtroJogo.PrecoMin = numericUpDownPrecoMin.Value;
            tabelaJogo.DataSource = _servicoJogo.ObterTodos(_filtroJogo);
        }
        private void EventoDeFiltroPorPrecoMax(object sender, EventArgs e)
        {
            _filtroJogo.PrecoMax = numericUpDownPrecoMax.Value;
            tabelaJogo.DataSource = _servicoJogo.ObterTodos(_filtroJogo);
        }

        private void EventoDePesquisaPorNomeDoResponsavel(object sender, EventArgs e)
        {
            _filtroTesteDejogo.NomeResponsavelTeste = textBoxTDJ.Text;
            tabelaTesteDeJogo.DataSource = _servicoTesteDeJogo.ObterTodos(_filtroTesteDejogo);
        }

        private void EventoDeFiltroPorAprovado(object sender, EventArgs e)
        {
            if (checkBoxAprovado.CheckState == CheckState.Checked)
                if (checkBoxReprovado.CheckState == CheckState.Checked)
                {
                    checkBoxReprovado.Checked = false;
                    checkBoxAprovado.Checked = true;
                }

            _filtroTesteDejogo.Aprovado = checkBoxAprovado.Checked;

            tabelaTesteDeJogo.DataSource = _servicoTesteDeJogo.ObterTodos(_filtroTesteDejogo);
        }

        private void EventoDeFiltroPorReprovado(object sender, EventArgs e)
        {
            if (checkBoxReprovado.CheckState == CheckState.Checked)
                if (checkBoxAprovado.CheckState == CheckState.Checked)
                {
                    checkBoxAprovado.Checked = false;
                    checkBoxReprovado.Checked = true;
                }

            _filtroTesteDejogo.Reprovado = checkBoxReprovado.Checked;

            tabelaTesteDeJogo.DataSource = _servicoTesteDeJogo.ObterTodos(_filtroTesteDejogo);
        }

        private void EventoDeFiltroPorDataMinima(object sender, EventArgs e)
        {
            _filtroTesteDejogo.DataMinRealizacaoTeste = dateTimePickerDataInicial.Value.Date;
            tabelaTesteDeJogo.DataSource = _servicoTesteDeJogo.ObterTodos(_filtroTesteDejogo);
        }

        private void EventoDeFiltroPorDataMaxima(object sender, EventArgs e)
        {
            _filtroTesteDejogo.DataMaxRealizacaoTeste = dateTimePickerDataFinal.Value.Date;
            tabelaTesteDeJogo.DataSource = _servicoTesteDeJogo.ObterTodos(_filtroTesteDejogo);
        }

        private void EventoDeResetDeData(object sender, EventArgs e)
        {
            LimparFiltroDeData(_filtroTesteDejogo);
            tabelaTesteDeJogo.DataSource = _servicoTesteDeJogo.ObterTodos(_filtroTesteDejogo);
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
            tabelaJogo.DataSource = _servicoJogo.ObterTodos();
        }

        private void EventoParaAbrirTelaDeCadastroDeTesteDeJogo(object sender, EventArgs e)
        {
            var telaCadastroDeTesteDeJogo = new TelaCadastroTesteDeJogo(_servicoTesteDeJogo, _servicoJogo);
            telaCadastroDeTesteDeJogo.ShowDialog();
            tabelaTesteDeJogo.DataSource = _servicoTesteDeJogo.ObterTodos();
        }

        private void EventoQueDeletaJogoDoBancoDeDados(object sender, EventArgs e)
        {
            const int colunaId = 0;
            const int colunaNome = 1;

            try
            {
                var idJogoQueVaiSerRemovido = (int)tabelaJogo.CurrentRow.Cells[colunaId].Value;
                var nomeJogoQueVaiSerRemovido = tabelaJogo.CurrentRow.Cells[colunaNome].Value;

                var mensagemDeAviso = MessageBox.Show($"Deseja remover o jogo {nomeJogoQueVaiSerRemovido}?", "Remover Jogo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (mensagemDeAviso == DialogResult.Yes)
                    _servicoJogo.Deletar(idJogoQueVaiSerRemovido);

                tabelaJogo.DataSource = _servicoJogo.ObterTodos();
;            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}