using Cod3rsGrowth.Dominio.Migracao;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Forms.Injecao
{
    public static class ModuloDeInjecao
    {
        public static void AdicionarMigracoesEBancoDeDadosAoEscopo(this ServiceCollection servicos)
        {
            const string nomeVariavelAmbiente = "ConnectionString";
            var stringConexao = Environment.GetEnvironmentVariable(nomeVariavelAmbiente)
                ?? throw new Exception($"Variavel de ambiente [{nomeVariavelAmbiente}] não encontrada");

            servicos.AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                .AddSqlServer()
                .WithGlobalConnectionString(stringConexao)
                .ScanIn(typeof(_20240620104300_migracao_tabela_jogo).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }
    }
}