using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes
{
    public class TesteServicoJogo : TesteBase
    {
        public IServicoJogo ServicoJogo;
        public TesteServicoJogo()
        {   
            ServicoJogo = ServiceProvider.GetService<IServicoJogo>();
        }

        [Fact]
        public void TesteSeObterTodosRetornaListaDeJogos()
        {
            //Arrange
            var resultadoAtual = new List<Jogo>();

            //Act
            resultadoAtual.Add(new Jogo { Id = 1, Nome = "Minecraft", Genero = Dominio.EnumGenero.Genero.SOBREVIVENCIA, Preco = 150m });
            resultadoAtual.Add(new Jogo { Id = 2, Nome = "GTA", Genero = Dominio.EnumGenero.Genero.TPS, Preco = 200m });
            var resultadoEsperado = ServicoJogo.ObterTodos();

            //Assert
            Assert.Equivalent(resultadoEsperado, resultadoAtual);
        }
    }
}