﻿using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Singletons;
using Cod3rsGrowth.Servico.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes.Testes
{
    public class TesteServicoTesteDeJogo : TesteBase
    {
        private readonly IServicoTesteDeJogo _servicoJogo;

        public TesteServicoTesteDeJogo()
        {
            _servicoJogo = ServiceProvider.GetService<IServicoTesteDeJogo>()
                ?? throw new Exception($"Erro ao obter serviço {nameof(IServicoTesteDeJogo)}");
        }

        [Fact]
        public void Criar_Lista_Quando_Chamado_Deve_Retornar_Lista_De_Teste_De_Jogo()
        {
            var listaEsperada = new List<TesteDeJogo>
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

            var listaDoBanco = _servicoJogo.CriarLista();

            Assert.Equivalent(listaEsperada, listaDoBanco);
        }

        [Fact]
        public void Criar_Lista_Quando_Chamado_Deve_Retornar_Uma_Lista_Do_Tipo_Teste_De_Jogo()
        {
            var listaDoBanco = _servicoJogo.CriarLista().ToList();

            Assert.IsType<List<TesteDeJogo>>(listaDoBanco);
        }
    }
}