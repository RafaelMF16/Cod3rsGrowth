using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Singletons;
using Cod3rsGrowth.Servico.Interfaces;

namespace Cod3rsGrowth.Servico.Servicos
{
    public class ServicoJogo : IServicoJogo
    {
        public List<Jogo> CriarLista()
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

            return listaJogoSingleton;
        }
    }
}