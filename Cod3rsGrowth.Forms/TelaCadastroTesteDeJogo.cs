using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servico.Servicos;

namespace Cod3rsGrowth.Forms
{
    public partial class TelaCadastroTesteDeJogo : Form
    {
        private readonly ServicoTesteDeJogo _servicoTesteDeJogo;
        private readonly ServicoJogo _servicoJogo;
        private TesteDeJogo _testeDeJogo = new TesteDeJogo();
        public TelaCadastroTesteDeJogo(ServicoTesteDeJogo servicoTesteDeJogo, ServicoJogo servicoJogo)
        {
            _servicoTesteDeJogo = servicoTesteDeJogo;
            _servicoJogo = servicoJogo;

            InitializeComponent();
        }

        private void EventoCancelaCadastroDeTesteDeJogo(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void EventoQueSalvaTesteDeJogo(object sender, EventArgs e)
        {
            var idJogo = _servicoJogo.ObterTodos().Where(j => j.Nome == comboBoxJogoCadastro.SelectedItem.ToString()).Select(j => j.Id).FirstOrDefault();

            try
            {
                _testeDeJogo.NomeResponsavelDoTeste = textBoxCadastroNomeResponsavel.Text;
                _testeDeJogo.Descricao = textBoxCadastroDescricao.Text;
                _testeDeJogo.Nota = numericUpDownCadastroNota.Value;
                _testeDeJogo.DataRealizacaoTeste = DateTime.Today;
                _testeDeJogo.Aprovado = checkBoxCadastroAprovado.Checked;
                _testeDeJogo.IdJogo = idJogo;

                _servicoTesteDeJogo.Adicionar(_testeDeJogo);

                this.Dispose();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void EventoDeCarregamentoDaTelaDeCadastroDeJogo(object sender, EventArgs e)
        {
            var comboBoxJogos = _servicoJogo.ObterTodos().Select(j => j.Nome).ToList();
            comboBoxJogoCadastro.DataSource = comboBoxJogos;
        }
    }
}
