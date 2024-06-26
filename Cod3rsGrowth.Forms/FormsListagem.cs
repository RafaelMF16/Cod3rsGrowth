using Cod3rsGrowth.Dominio.EnumGenero;
using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Servico.Servicos;

namespace Cod3rsGrowth.Forms
{
    public partial class FormsListagem : Form
    {
        private readonly ServicoJogo _servicoJogo;
        private readonly ServicoTesteDeJogo _servicoTesteDeJogo;

        public FormsListagem(ServicoJogo servicoJogo, ServicoTesteDeJogo servicoTesteDeJogo)
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
        }

        private void EventoDePesquisaPorNomeDoJogo(object sender, EventArgs e)
        {
            var filtroJogo = new FiltroJogo
            {
                Nome = textBoxJogo.Text,
                Genero = (Genero)comboBoxEnum.SelectedIndex,
                PrecoMin = numericUpDownPrecoMin.Value,
                PrecoMax = numericUpDownPrecoMax.Value
            };

            tabelaJogo.DataSource = _servicoJogo.ObterTodos(filtroJogo);
        }

        private void EventoDeFiltroPorGenero(object sender, EventArgs e)
        {
            var filtroJogo = new FiltroJogo
            {
                Nome = textBoxJogo.Text,
                Genero = (Genero)comboBoxEnum.SelectedIndex,
                PrecoMin = numericUpDownPrecoMin.Value,
                PrecoMax = numericUpDownPrecoMax.Value
            };

            tabelaJogo.DataSource = _servicoJogo.ObterTodos(filtroJogo);
        }

        private void EventoDeFiltroPorPrecoMin(object sender, EventArgs e)
        {
            var filtroJogo = new FiltroJogo
            {
                Nome = textBoxJogo.Text,
                Genero = (Genero)comboBoxEnum.SelectedIndex,
                PrecoMin = numericUpDownPrecoMin.Value,
                PrecoMax = numericUpDownPrecoMax.Value
            };

            tabelaJogo.DataSource = _servicoJogo.ObterTodos(filtroJogo);
        }
        private void EventoDeFiltroPorPrecoMax(object sender, EventArgs e)
        {
            var filtroJogo = new FiltroJogo
            {
                Nome = textBoxJogo.Text,
                Genero = (Genero)comboBoxEnum.SelectedIndex,
                PrecoMin = numericUpDownPrecoMin.Value,
                PrecoMax = numericUpDownPrecoMax.Value
            };

            tabelaJogo.DataSource = _servicoJogo.ObterTodos(filtroJogo);
        }

        private void EventoDePesquisaPorNomeDoResponsavel(object sender, EventArgs e)
        {
            var filtroTesteDeJogo = new FiltroTesteDeJogo { NomeResponsavelTeste = textBoxTDJ.Text };
            tabelaTesteDeJogo.DataSource = _servicoTesteDeJogo.ObterTodos(filtroTesteDeJogo);
        }
    }
}