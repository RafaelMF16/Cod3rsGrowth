using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Singletons;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes.Testes
{
    public class TesteRepositorioTesteDeJogoSingleton : TesteBase
    {
        private readonly ITesteDeJogoRepositorio _servicoTesteDeJogo;

        public TesteRepositorioTesteDeJogoSingleton()
        {
            _servicoTesteDeJogo = ServiceProvider.GetService<ITesteDeJogoRepositorio>()
                ?? throw new Exception($"Erro ao obter serviço{nameof(ITesteDeJogoRepositorio)}");
        }

        [Fact]
        public void Obter_Todos_Quando_Chamado_Retorna_Uma_Lista_De_Teste_De_Jogo()
        {
            var listaEsperada = CriarLista();

            var listaDoBanco = _servicoTesteDeJogo.ObterTodos();

            Assert.Equivalent(listaEsperada, listaDoBanco);
        }

        [Fact]
        public void Obter_Por_Id_Quando_Chamado_Retorna_O_Teste_De_Jogo_Que_Tem_O_Id_Passado_Como_Parametro()
        {
            CriarLista();

            var idEsperado = 1;

            var testeDeJogo = _servicoTesteDeJogo.ObterPorId(1);

            Assert.Equal(idEsperado, testeDeJogo.Id);
        }

        [Fact]
        public void Obter_Por_Id_Quando_Chamado_Lanca_Excecao_Caso_O_Id_Passado_Seja_Nulo()
        {
            CriarLista();

            Assert.Throws<Exception>(() => _servicoTesteDeJogo.ObterPorId(4));
        }

        public List<TesteDeJogo> CriarLista()
        {
            var listaTesteDeJogoSingleton = TesteDeJogoSingleton.Instancia;

            var listaDeTesteDeJogo = new List<TesteDeJogo>
            {
                new TesteDeJogo
                {
                    Id = 1,
                    NomeResponsavelDoTeste = "Rafael",
                    Descricao = "O jogo é top",
                    Nota = 9m,
                    Aprovado = true,
                    DataRealizacaoTeste = DateTime.Parse("22/05/2024"),
                    JogoId = 1
                },
                new TesteDeJogo
                {
                    Id = 2,
                    NomeResponsavelDoTeste = "Paulo",
                    Descricao = "Não gostei do jogo",
                    Nota = 4.5m,
                    Aprovado = false,
                    DataRealizacaoTeste = DateTime.Parse("10/04/2024"),
                    JogoId = 2
                },
                new TesteDeJogo
                {
                    Id = 3,
                    NomeResponsavelDoTeste = "Italo",
                    Descricao = "Não é um jogo perfeito, mas é jogável",
                    Nota = 7.4m,
                    Aprovado = true,
                    DataRealizacaoTeste = DateTime.Parse("15/06/2024"),
                    JogoId = 3
                }
            };

            listaTesteDeJogoSingleton.AddRange(listaDeTesteDeJogo);

            return listaDeTesteDeJogo;
        }
    }
}