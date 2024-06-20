using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Forms
{
    public class Migracao : FormsBase
    {
        public void ExecutarMigracao()
        {
            var executar = ServiceProvider.GetRequiredService<IMigrationRunner>();
            executar.MigrateUp();
        }
    }
}