using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Singletons;
using Cod3rsGrowth.Servico.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes.Testes
{
    public class TesteDoServicoJogo : TesteBase
    {
        private readonly ServicoJogo _servicoJogo;

        public TesteDoServicoJogo()
        {
            _servicoJogo = ServiceProvider.GetService<ServicoJogo>()
                ?? throw new Exception($"Erro ao obter o serviço {nameof(ServicoJogo)}");

            JogoSingleton.Instancia.Clear();
        }

        [Fact]
        public void obter_todos_quando_chamado_retorna_uma_lista_de_jogo()
        {
            var listaEsperada = criarLista();

            var listaDoBanco = _servicoJogo.ObterTodos();

            Assert.Equivalent(listaEsperada, listaDoBanco, true);
        }

        [Fact]
        public void obter_todos_quando_chamado_com_filtro_de_nome_deve_retornar_lista_de_jogo_de_acordo_com_filtro_passado()
        {
            criarLista();

            var listaEsperada = new List<Jogo> { new Jogo { Id = 1, Nome = "Minecraft", Genero = Dominio.EnumGenero.Genero.SOBREVIVENCIA, Preco = 100m} };

            var listaDoBanco = _servicoJogo.ObterTodos(new FiltroJogo { Nome = "mine"});

            Assert.Equivalent(listaEsperada, listaDoBanco);
        }

        [Fact]
        public void obter_todos_quando_chamado_com_filtro_invalido_deve_retornar_lista_de_jogo_vazia()
        {
            criarLista();

            var listaEsperada = new List<Jogo> { };

            var listaDoBanco = _servicoJogo.ObterTodos(new FiltroJogo { Nome = "Elden Ring"});

            Assert.Equivalent(listaEsperada, listaDoBanco);
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
        public void adicionar_quando_chamado_nao_deve_adicionar_jogo_caso_nome_seja_nulo()
        {
            var jogo = new Jogo { Id = 4, Genero = Dominio.EnumGenero.Genero.RPG, Preco = 200.00m };

            var mensagemDeErro = Assert.Throws<FluentValidation.ValidationException>(() => _servicoJogo.Adicionar(jogo));

            Assert.Equal("O campo nome é obrigatório", mensagemDeErro.Errors.First().ErrorMessage);
        }

        [Fact]
        public void adicionar_quando_chamado_nao_deve_adicionar_jogo_caso_nome_seja_repetido()
        {
            criarLista();

            var jogoRepetido = new Jogo { Id = 4, Nome = "Counter Strike 2", Genero = Dominio.EnumGenero.Genero.FPS, Preco = 60m };

            var mensagemDeErro = Assert.Throws<FluentValidation.ValidationException>(() => _servicoJogo.Adicionar(jogoRepetido));

            Assert.Equal("Já existe um jogo com esse nome cadastrado", mensagemDeErro.Errors.First().ErrorMessage);
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
        public void atualizar_quando_chamado_nao_deve_atualizar_jogo_caso_nome_seja_nulo()
        {
            criarLista();

            var jogoAtualizado = new Jogo { Id = 1, Genero = Dominio.EnumGenero.Genero.SOBREVIVENCIA, Preco = 150m };

            var mensagemDeErro = Assert.Throws<FluentValidation.ValidationException>(() => _servicoJogo.Atualizar(jogoAtualizado));

            Assert.Equal("O campo nome é obrigatório", mensagemDeErro.Errors.First().ErrorMessage);
        }

        [Fact]
        public void deletar_quando_chamado_deve_remover_o_jogo_com_id_um()
        {
            criarLista();

            var jogoDeletado = new Jogo { Id = 1, Nome = "Minecraft", Genero = Dominio.EnumGenero.Genero.SOBREVIVENCIA, Preco = 100m };

            var listaDeJogoSingleton = JogoSingleton.Instancia;

            _servicoJogo.Deletar(jogoDeletado.Id);

            Assert.DoesNotContain(listaDeJogoSingleton, jogo => jogo == jogoDeletado);
        }

        [Fact]
        public void deletar_quando_chamado_nao_deve_remover_jogo_com_id_invalido()
        {
            var tamanhoDaListaDoBanco = criarLista().Count;

            var tamanhoDaListaEsperado = 3;

            var jogoDeletado = new Jogo { Id = 4, Nome = "Spider Man", Genero = Dominio.EnumGenero.Genero.MMORPG, Preco = 250m };

            _servicoJogo.Deletar(jogoDeletado.Id);

            Assert.Equal(tamanhoDaListaEsperado, tamanhoDaListaDoBanco);
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