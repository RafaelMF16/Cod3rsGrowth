using Cod3rsGrowth.Infra;
using LinqToDB;
using LinqToDB.AspNet;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Forms
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
        }
    }
}