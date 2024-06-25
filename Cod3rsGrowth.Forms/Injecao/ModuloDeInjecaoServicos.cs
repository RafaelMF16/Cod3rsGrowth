using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorio;
using Cod3rsGrowth.Servico.Servicos;
using Cod3rsGrowth.Servico.Validadores;
using FluentValidation;
using LinqToDB;
using LinqToDB.AspNet;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Forms.Injecao
{
    public static class ModuloDeInjecaoServicos
    {
        public static void AdicionarServicosAoEscopo(this ServiceCollection servicos)
        {
            const string nomeVariavelAmbiente = "ConnectionString";
            var stringConexao = Environment.GetEnvironmentVariable(nomeVariavelAmbiente)
                ?? throw new Exception($"Variavel de ambiente [{nomeVariavelAmbiente}] não encontrada");

            servicos.AddLinqToDBContext<DbCod3rsGrowth>((provider, options)
                => options
                .UseSqlServer(stringConexao));

            servicos.AddScoped<ServicoJogo>();
            servicos.AddScoped<ServicoTesteDeJogo>();
            servicos.AddScoped<IValidator<Jogo>, JogoValidador>();
            servicos.AddScoped<IValidator<TesteDeJogo>, TesteDeJogoValidador>();
            servicos.AddScoped<IJogoRepositorio, JogoRepositorio>();
            servicos.AddScoped<ITesteDeJogoRepositorio, TesteDeJogoRepositorio>();
            servicos.AddScoped<FormsListagem>();
        }
    }
}