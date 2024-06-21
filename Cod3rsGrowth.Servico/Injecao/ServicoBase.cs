using Microsoft.Extensions.DependencyInjection;
using System;

namespace Cod3rsGrowth.Servico.Injecao
{
    public class ServicoBase : IDisposable
    {
        protected ServiceProvider ServiceProvider;

        public ServicoBase()
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