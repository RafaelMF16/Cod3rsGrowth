using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.EnumGenero;
using Cod3rsGrowth.Servico.Servicos;

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
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}