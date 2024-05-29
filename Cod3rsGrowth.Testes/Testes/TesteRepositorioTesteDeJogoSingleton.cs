﻿using Cod3rsGrowth.Dominio.Entidades;
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

            TesteDeJogoSingleton.Instancia.Clear();
        }

        [Fact]
        public void obter_todos_quando_chamado_retorna_uma_lista_de_teste_de_jogo()
        {
            var listaEsperada = criarLista();

            var listaDoBanco = _servicoTesteDeJogo.ObterTodos();

            Assert.Equivalent(listaEsperada, listaDoBanco);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void obter_por_id_quando_chamado_retorna_o_teste_de_jogo_que_tem_o_id_um_dois_ou_tres(int id)
        {
            criarLista();

            var idEsperado = id;

            var testeDeJogo = _servicoTesteDeJogo.ObterPorId(id);

            Assert.Equal(idEsperado, testeDeJogo.Id);
        }

        [Fact]
        public void obter_por_id_quando_chamado_lanca_excecao_caso_o_id_passado_seja_quatro()
        {
            criarLista();

            var idNulo = 4;

            Assert.Throws<Exception>(() => _servicoTesteDeJogo.ObterPorId(idNulo));
        }

        [Fact]
        public void adicionar_quando_chamado_adiciona_teste_de_jogo_no_repositorio_singleton()
        {
            var testeDeJogo = new TesteDeJogo {
                Id = 4,
                NomeResponsavelDoTeste = "Victor",
                Descricao = "Gostei muito, mas o jogo é muito fácil",
                Nota = 8m,
                Aprovado = true,
                DataRealizacaoTeste = DateTime.Today,
                JogoId = 4
            };

            _servicoTesteDeJogo.Adicionar(testeDeJogo);

            Assert.Contains(TesteDeJogoSingleton.Instancia, testeDeJogo1 => testeDeJogo1 == testeDeJogo);
        }

        [Fact]
        public void adicionar_quando_chamado_nao_deve_adicionar_teste_de_jogo_caso_nota_nao_esteja_entre_zero_e_dez()
        {
            var testeDeJogo = new TesteDeJogo
            {
                Id = 4,
                NomeResponsavelDoTeste = "Victor",
                Descricao = "Gostei muito, mas o jogo é muito fácil",
                Nota = 12m,
                Aprovado = true,
                DataRealizacaoTeste = DateTime.Today,
                JogoId = 4
            };

            var mensagemDeErro = Assert.Throws<FluentValidation.ValidationException>(() => _servicoTesteDeJogo.Adicionar(testeDeJogo));

            Assert.Equal("Nota deve estar entre 0 e 10", mensagemDeErro.Errors.First().ErrorMessage);
        }

        [Fact]
        public void adicionar_quando_chamado_nao_deve_adicionar_teste_de_jogo_caso_data_realizacao_teste_nao_seja_a_data_atual()
        {
            var testeDeJogo = new TesteDeJogo
            {
                Id = 4,
                NomeResponsavelDoTeste = "Victor",
                Descricao = "Gostei muito, mas o jogo é muito fácil",
                Nota = 8m,
                Aprovado = true,
                DataRealizacaoTeste = DateTime.Parse("30/05/2024"),
                JogoId = 4
            };

            var mensagemDeErro = Assert.Throws<FluentValidation.ValidationException>(() => _servicoTesteDeJogo.Adicionar(testeDeJogo));

            Assert.Equal("Data de realização do teste deve ser a data atual", mensagemDeErro.Errors.First().ErrorMessage);
        }

        public List<TesteDeJogo> criarLista()
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