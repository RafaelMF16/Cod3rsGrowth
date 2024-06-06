using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servico.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes.Testes
{
    public class TesteServicoJogo : TesteBase
    {
        private readonly ServicoJogo _servicoJogo;

        public TesteServicoJogo()
        {
            _servicoJogo = ServiceProvider.GetService<ServicoJogo>()
                ?? throw new Exception($"Erro ao obter serviço {nameof(ServicoJogo)}");
        }

        [Fact]
        public void criar_lista_quando_chamado_deve_retornar_lista_de_jogos()
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
        public void criar_lista_quando_chamado_deve_retornar_uma_lista_do_tipo_jogo()
        {
            var listaDoBanco = _servicoJogo.CriarLista().ToList();

            Assert.IsType<List<Jogo>>(listaDoBanco);
        }
    }
}