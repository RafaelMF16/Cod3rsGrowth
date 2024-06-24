using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Migracao;
using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorio;
using Cod3rsGrowth.Servico.Servicos;
using Cod3rsGrowth.Servico.Validadores;
using FluentMigrator.Runner;
using FluentValidation;
using LinqToDB;
using LinqToDB.AspNet;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Forms.Injecao
{
    public static class ModuloDeInjecao
    {
        public static IConfiguration? Configuration { get; }

        public static void AdicionarServicosAoEscopo(ServiceCollection servicos)
        {
            const string nomeVariavelAmbiente = "ConnectionString";
            var stringConexao = Environment.GetEnvironmentVariable(nomeVariavelAmbiente)
                ?? throw new Exception($"Variavel de ambiente [{nomeVariavelAmbiente}] não encontrada");

            servicos.AddLinqToDBContext<DbCod3rsGrowth>((provider, options)
                => options
                .UseSqlServer(Configuration.GetConnectionString(stringConexao)));

            servicos.AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                .AddSqlServer()
                .WithGlobalConnectionString(stringConexao)
                .ScanIn(typeof(_20240620104300_migracao_tabela_jogo).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);

            servicos.AddScoped<IValidator<Jogo>, JogoValidador>();
            servicos.AddScoped<IValidator<TesteDeJogo>, TesteDeJogoValidador>();
            servicos.AddScoped<IJogoRepositorio, JogoRepositorio>();
            servicos.AddScoped<ITesteDeJogoRepositorio, TesteDeJogoRepositorio>();
            servicos.AddScoped<ServicoJogo>();
            servicos.AddScoped<ServicoTesteDeJogo>();
        }
    }
}