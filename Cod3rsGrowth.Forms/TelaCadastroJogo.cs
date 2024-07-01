using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.EnumGenero;
using Cod3rsGrowth.Servico.Servicos;

namespace Cod3rsGrowth.Forms
{
    public partial class TelaCadastroJogo : Form
    {
        private Jogo _jogo = new Jogo();
        private readonly ServicoJogo _servicoJogo;

        public TelaCadastroJogo(ServicoJogo servicoJogo)
        {
            _servicoJogo = servicoJogo;
            InitializeComponent();
        }

        private void EventoDeCancelarCadastro(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void EventoQueSalvaJogoNoBancoDeDados(object sender, EventArgs e)
        {
            try
            {
                _jogo.Nome = textBoxCadastroNome.Text;
                _jogo.Genero = (Genero)comboBoxEnumCadastro.SelectedIndex;
                _jogo.Preco = numericUpDownCadastroPreco.Value;

                _servicoJogo.Adicionar(_jogo);

                this.Dispose();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}