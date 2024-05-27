using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes
{
    public class TesteBase : IDisposable
    {
        protected ServiceProvider ServiceProvider;

        public TesteBase()
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