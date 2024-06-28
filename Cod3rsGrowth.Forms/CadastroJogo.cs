using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Forms
{
    public partial class CadastroJogo : Form
    {
        private Jogo _jogo = new Jogo();
        private TesteDeJogo _testeDeJogo = new TesteDeJogo();
        public CadastroJogo()
        {
            InitializeComponent();
        }

        private void EventoDeCancelarCadastro(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}