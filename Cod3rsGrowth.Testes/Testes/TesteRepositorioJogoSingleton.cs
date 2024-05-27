using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Singletons;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes.Testes
{
    public class TesteRepositorioJogoSingleton : TesteBase
    {
        private readonly IJogoRepositorio _servicoJogo;

        public TesteRepositorioJogoSingleton()
        {
            _servicoJogo = ServiceProvider.GetService<IJogoRepositorio>()
                ?? throw new Exception($"Erro ao obter o serviço {nameof(IJogoRepositorio)}");
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

        [Fact]
        public void Obter_Todos_Quando_Chamado_Retorna_Uma_Lista_De_Jogo()
        {
            var listaEsperada = new List<Jogo>
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
            
            CriarLista();
            var listaDoBanco = _servicoJogo.ObterTodos();
            
            Assert.Equivalent(listaEsperada, listaDoBanco);
        }
    }
}