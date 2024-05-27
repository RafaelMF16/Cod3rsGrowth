using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servico.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes.Testes
{
    public class TesteServicoJogo : TesteBase
    {
        private readonly IServicoJogo _servicoJogo;

        public TesteServicoJogo()
        {
            _servicoJogo = ServiceProvider.GetService<IServicoJogo>()
                ?? throw new Exception($"Erro ao obter serviço {nameof(IServicoJogo)}");
        }

        [Fact]
        public void Criar_Lista_Quando_Chamado_Deve_Retornar_Lista_De_Jogos()
        {
            var listaEsperada = new List<Jogo>
            {
                new Jogo { Id = 1, Nome = "Minecraft", Genero = Dominio.EnumGenero.Genero.SOBREVIVENCIA, Preco = 100m },
                new Jogo { Id = 2, Nome = "GTA", Genero = Dominio.EnumGenero.Genero.TPS, Preco = 200m },
                new Jogo { Id = 3, Nome = "Counter Strike 2", Genero = Dominio.EnumGenero.Genero.FPS, Preco = 60m}
            };

            var listaDoBanco = _servicoJogo.CriarLista();

            Assert.Equivalent(listaEsperada, listaDoBanco);
        }

        [Fact]
        public void Criar_Lista_Quando_Chamado_Deve_Retornar_Uma_Lista_Do_Tipo_Jogo()
        {
            var listaDoBanco = _servicoJogo.CriarLista().ToList();

            Assert.IsType<List<Jogo>>(listaDoBanco);
        }
    }
}