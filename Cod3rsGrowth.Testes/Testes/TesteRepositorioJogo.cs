using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Singletons;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes.Testes
{
    public class TesteRepositorioJogo : TesteBase
    {
        private readonly IJogoRepositorio _servico;

        public TesteRepositorioJogo()
        {
            _servico = ServiceProvider.GetService<IJogoRepositorio>()
                ?? throw new Exception($"Erro ao obter serviço {nameof(IJogoRepositorio)}");
        }

        public void CriarLista()
        {
            var listaJogoSingleton = JogoSingleton.Instancia;

            var listaDeJogo = new List<Jogo>
            {
                new Jogo
                {
                    Id = 1,
                    Nome = "Minecraft",
                    Genero = Dominio.EnumGenero.Genero.SOBREVIVENCIA,
                    Preco = 100m
                },
                new Jogo
                {
                    Id = 2,
                    Nome = "GTA",
                    Genero = Dominio.EnumGenero.Genero.TPS,
                    Preco = 200m
                },
                new Jogo
                {
                    Id = 3,
                    Nome = "Counter Strike 2",
                    Genero = Dominio.EnumGenero.Genero.FPS,
                    Preco = 60m
                }
            };

            listaJogoSingleton.AddRange(listaDeJogo);
        }
    }
}