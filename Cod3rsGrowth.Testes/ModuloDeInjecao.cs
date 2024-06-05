using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Servico.Servicos;
using Cod3rsGrowth.Servico.Validadores;
using Cod3rsGrowth.Testes.Mocks;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes
{
    public static class ModuloDeInjecao
    {
        public static void AdicionarServicosAoEscopo(ServiceCollection servicos)
        {
            servicos.AddScoped<IValidator<Jogo>, JogoValidador>();
            servicos.AddScoped<IValidator<TesteDeJogo>, TesteDeJogoValidador>();
            servicos.AddScoped<IJogoRepositorio, JogoRepositorioMock>();
            servicos.AddScoped<ITesteDeJogoRepositorio, TesteDeJogoRepositorioMock>();
            servicos.AddScoped<ServicoJogo>();
            servicos.AddScoped<ServicoTesteDeJogo>();
        }
    }
}