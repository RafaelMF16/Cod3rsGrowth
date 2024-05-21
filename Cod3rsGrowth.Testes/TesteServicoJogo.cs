using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes
{
    public class TesteServicoJogo : TesteBase
    {
        private readonly IServicoJogo _servicoJogo;

        public TesteServicoJogo()
        {
            _servicoJogo = ServiceProvider.GetService<IServicoJogo>()
                ?? throw new Exception($"Erro ao obter servico {nameof(IServicoJogo)}");
        }

        [Fact]
        public void Obter_Todos_Quando_Chamado_Deve_Retornar_Lista_De_Jogos()
        {
            var listaEsperada = new List<Jogo>
            {
                new Jogo { Id = 1, Nome = "Minecraft", Genero = Dominio.EnumGenero.Genero.SOBREVIVENCIA, Preco = 150m },
                new Jogo { Id = 2, Nome = "GTA", Genero = Dominio.EnumGenero.Genero.TPS, Preco = 200m }
            };

            var listaDoBanco = _servicoJogo.ObterTodos();

            Assert.Equivalent(listaEsperada, listaDoBanco);
        }

        [Fact]
        public void Obter_Todos_Quando_Chamado_Deve_Retornar_Uma_Lista_Do_Tipo_Jogo()
        {
            var listaDoBanco = _servicoJogo.ObterTodos();

            Assert.IsType<List<Jogo>>(listaDoBanco);
        }
    }
}