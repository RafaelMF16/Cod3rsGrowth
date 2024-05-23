using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servico.Interfaces;

namespace Cod3rsGrowth.Servico.Servicos
{
    public class ServicoJogo : IServicoJogo
    {
        public List<Jogo> ObterTodos()
        {
            var listaDeJogos = new List<Jogo>
            {
                new Jogo { Id = 1, Nome = "Minecraft", Genero = Dominio.EnumGenero.Genero.SOBREVIVENCIA, Preco = 150m },
                new Jogo { Id = 2, Nome = "GTA", Genero = Dominio.EnumGenero.Genero.TPS, Preco = 200m }
            };
            return listaDeJogos;
        }       
    }
}