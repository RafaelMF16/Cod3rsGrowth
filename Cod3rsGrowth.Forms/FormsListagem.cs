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

        private void FormsListaJogo_Load(object sender, EventArgs e)
        {
            tabelaJogo.DataSource = _servicoJogo.ObterTodos();
        }
    }
}