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
            servicos.AddLinqToDBContext<DbCod3rsGrowth>((provider, options)
                => options
                .UseSqlServer(Configuration.GetConnectionString("Cod3rsGrowth")));
        }
    }
}