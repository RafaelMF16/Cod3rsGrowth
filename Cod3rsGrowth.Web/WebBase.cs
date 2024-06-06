namespace Cod3rsGrowth.Web
{
    public class WebBase : IDisposable
    {
        protected ServiceProvider ServiceProvider;

        public WebBase()
        {
            var servicos = new ServiceCollection();
            ModuloDeInjecao.AdicionarServicosAoEscopo(servicos);
            ServiceProvider = servicos.BuildServiceProvider();
        }

        public void Dispose()
        {
            ServiceProvider.Dispose();
        }
    }
}