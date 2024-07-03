using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servico.Servicos;

namespace Cod3rsGrowth.Forms
{
    public partial class TelaCadastroTesteDeJogo : Form
    {
        private readonly ServicoTesteDeJogo _servicoTesteDeJogo;
        private readonly ServicoJogo _servicoJogo;
        private TesteDeJogo _testeDeJogoQueVaiSerAtualizado;
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
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}