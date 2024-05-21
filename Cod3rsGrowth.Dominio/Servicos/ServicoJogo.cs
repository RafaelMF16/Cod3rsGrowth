using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;

namespace Cod3rsGrowth.Dominio.Servicos
{
    public class ServicoJogo : IServicoJogo
    {
        public List<Jogo> ObterTodos()
        {
            var listaDeJogos = new List<Jogo>
            {
                new Jogo { Id = 1, Nome = "Minecraft", Genero = EnumGenero.Genero.SOBREVIVENCIA, Preco = 150m },
                new Jogo { Id = 2, Nome = "GTA", Genero = EnumGenero.Genero.TPS, Preco = 200m }
            };
            return listaDeJogos;
        }       
    }
}