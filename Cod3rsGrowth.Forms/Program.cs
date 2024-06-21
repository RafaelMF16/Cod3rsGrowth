namespace Cod3rsGrowth.Forms
{
    public static class Program 
    {
        [STAThread]
        static void Main()
        {
            var migracao = new Migracao();
            migracao.ExecutarMigracao();
            ApplicationConfiguration.Initialize();
            Application.Run(new FormsListaJogo());
        }
    }
}