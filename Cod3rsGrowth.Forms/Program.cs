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
                ?? throw new Exception($"Erro ao obter os serviços");

            var servicoJogo = _serviceProvider.GetRequiredService<ServicoJogo>();

            var servicoTesteDeJogo = _serviceProvider.GetRequiredService<ServicoTesteDeJogo>();

            ApplicationConfiguration.Initialize();

            Application.Run(new TelaListagem(servicoJogo, servicoTesteDeJogo));
        }

        public static void ExecutarMigracao()
        {
            var servicos = new ServiceCollection();

            servicos.AdicionarMigracoesEBancoDeDadosAoEscopo();

            using(var serviceProvider = servicos.BuildServiceProvider())
            {
                var executarMigracao = serviceProvider.GetRequiredService<IMigrationRunner>()
                    ?? throw new Exception($"Erro ao obter o serviço {typeof(IMigrationRunner)}");

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