using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Forms
{
    public class FormsBase : IDisposable
    {
        protected ServiceProvider ServiceProvider;

        public FormsBase()
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