using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Singletons;
using Cod3rsGrowth.Servico.Interfaces;

namespace Cod3rsGrowth.Servico.Servicos
{
    public class ServicoTesteDeJogo : IServicoTesteDeJogo
    {
        public List<TesteDeJogo> CriarLista()
        {
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

            return listaDeTesteDeJogo;
        }
    }
}