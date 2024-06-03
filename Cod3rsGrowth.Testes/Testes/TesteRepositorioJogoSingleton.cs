using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Singletons;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes.Testes
{
    public class TesteRepositorioJogoSingleton : TesteBase
    {
        private readonly IJogoRepositorio _servicoJogo;

        public TesteRepositorioJogoSingleton()
        {
            _servicoJogo = ServiceProvider.GetService<IJogoRepositorio>()
                ?? throw new Exception($"Erro ao obter o serviço {nameof(IJogoRepositorio)}");

            JogoSingleton.Instancia.Clear();
        }

        [Fact]
        public void obter_todos_quando_chamado_retorna_uma_lista_de_jogo()
        {
            var listaEsperada = criarLista();

            var listaDoBanco = _servicoJogo.ObterTodos();

            Assert.Equivalent(listaEsperada, listaDoBanco, true);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void obter_por_id_quando_chamado_retorna_o_jogo_que_tem_o_id_um_dois_ou_tres(int id)
        {
            criarLista();

            var idEsperado = id;

            var jogo = _servicoJogo.ObterPorId(id);

            Assert.Equal(idEsperado, jogo.Id);
        }

        [Fact]
        public void obter_por_id_quando_chamado_lanca_excecao_caso_o_id_passado_seja_quatro()
        {
            criarLista();

            var idNulo = 4;

            Assert.Throws<Exception>(() => _servicoJogo.ObterPorId(idNulo));
        }

        [Fact]
        public void adicionar_quando_chamado_adiciona_jogo_no_repositorio_singleton()
        {
            var jogo = new Jogo { Id = 4, Nome = "Elden Ring", Genero = Dominio.EnumGenero.Genero.RPG, Preco = 200.00m };

            _servicoJogo.Adicionar(jogo);

            Assert.Contains(JogoSingleton.Instancia, jogo1 => jogo1 == jogo);
        }

        [Fact]
        public void adicionar_quando_chamado_nao_deve_adicionar_jogo_caso_id_seja_nulo()
        {
            var jogo = new Jogo { Nome = "Elden Ring", Genero = Dominio.EnumGenero.Genero.RPG, Preco = 200.00m };

            var mensagemDeErro = Assert.Throws<FluentValidation.ValidationException>(() => _servicoJogo.Adicionar(jogo));

            Assert.Equal("O campo id é obrigatório", mensagemDeErro.Errors.First().ErrorMessage);
        }
        
        [Fact]
        public void adicionar_quando_chamado_nao_deve_adicionar_jogo_caso_enum_seja_vazio()
        {
            var jogo = new Jogo { Id = 4, Nome = "Elden Ring", Preco = 200.00m };

            var mensagemDeErro = Assert.Throws<FluentValidation.ValidationException>(() => _servicoJogo.Adicionar(jogo));

            Assert.Equal("O Gênero não é válido", mensagemDeErro.Errors.First().ErrorMessage);
        }

        [Fact]
        public void atualizar_quando_chamado_deve_atualizar_o_campo_preco_do_jogo_com_id_um()
        {
            criarLista();

            var listaDeJogoSingleton = JogoSingleton.Instancia;

            var jogoAtualizado = new Jogo { Id = 1, Nome = "Minecraft", Genero = Dominio.EnumGenero.Genero.SOBREVIVENCIA, Preco = 150m};

            _servicoJogo.Atualizar(jogoAtualizado);

            Assert.Contains(listaDeJogoSingleton, jogo => jogo == jogoAtualizado);
        }

        [Fact]
        public void atualizar_quando_chamado_lanca_excecao_caso_id_passado_nao_exista()
        {
            criarLista();

            var jogoAtualizado = new Jogo { Id = 4, Nome = "Terraria", Genero = Dominio.EnumGenero.Genero.RPG, Preco = 150m };

            Assert.Throws<Exception>(() => _servicoJogo.Atualizar(jogoAtualizado));
        }

        [Fact]
        public void atualizar_quando_chamado_nao_deve_atualizar_jogo_caso_id_seja_nulo()
        {
            criarLista();

            var jogoAtualizado = new Jogo { Nome = "Minecraft", Genero = Dominio.EnumGenero.Genero.SOBREVIVENCIA, Preco = 150m };

            var mensagemDeErro = Assert.Throws<FluentValidation.ValidationException>(() => _servicoJogo.Atualizar(jogoAtualizado));

            Assert.Equal("O campo id é obrigatório", mensagemDeErro.Errors.First().ErrorMessage);
        }

        public List<Jogo> criarLista()
        {
            var listaJogoSingleton = JogoSingleton.Instancia;

            var listaDeJogo = new List<Jogo>
            {
                new Jogo
                {
                    Id = 1,
                    Nome = "Minecraft",
                    Genero = Dominio.EnumGenero.Genero.SOBREVIVENCIA,
                    Preco = 100m
                },
                new Jogo
                {
                    Id = 2,
                    Nome = "GTA",
                    Genero = Dominio.EnumGenero.Genero.TPS,
                    Preco = 200m
                },
                new Jogo
                {
                    Id = 3,
                    Nome = "Counter Strike 2",
                    Genero = Dominio.EnumGenero.Genero.FPS,
                    Preco = 60m
                }
            };

            listaJogoSingleton.AddRange(listaDeJogo);

            return listaDeJogo;
        }
    }
}