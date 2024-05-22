using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Servicos;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Testes.Mocks;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes
{
    public static class ModuloDeInjecao
    {
        public static void AdicionarServicosAoEscopo(ServiceCollection servicos)
        {
            servicos.AddScoped<IServicoJogo, ServicoJogo>();
            servicos.AddScoped<IJogoRepositorio, JogoRepositorioMock>();
            servicos.AddScoped<ITesteDeJogoRepositorio, TesteDeJogoRepositorioMock>();
        }
    }
}