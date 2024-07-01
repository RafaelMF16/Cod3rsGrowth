using Cod3rsGrowth.Forms.Injecao;
using Cod3rsGrowth.Servico.Servicos;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Forms
{
    public static class Program 
    {
        private static IServiceProvider? _serviceProvider;

        [STAThread]
        static void Main()
        {
            ExecutarMigracao();

            _serviceProvider = PegarServicos() 
                ?? throw new Exception($"Erro ao obter o servi�o");

            ApplicationConfiguration.Initialize();

            Application.Run(_serviceProvider.GetRequiredService<TelaListagem>());
        }

        public static void ExecutarMigracao()
        {
            var servicos = new ServiceCollection();

            servicos.AdicionarMigracoesEBancoDeDadosAoEscopo();

            using(var serviceProvider = servicos.BuildServiceProvider())
            {
                var executarMigracao = serviceProvider.GetRequiredService<IMigrationRunner>()
                    ?? throw new Exception($"Erro ao obter o servi�o {typeof(IMigrationRunner)}");

                executarMigracao.MigrateUp();
            }
        }

        public static IServiceProvider PegarServicos()
        {
            var servicos = new ServiceCollection();

            servicos.AdicionarServicosAoEscopo();

            return servicos.BuildServiceProvider();
        }
    }
}