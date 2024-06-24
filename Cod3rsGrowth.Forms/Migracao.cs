using Cod3rsGrowth.Forms.Injecao;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Forms
{
    public class Migracao : FormsBase
    {
        public void ExecutarMigracao()
        {
            var executarMigracao = ServiceProvider.GetRequiredService<IMigrationRunner>();
            executarMigracao.MigrateUp();
        }
    }
}