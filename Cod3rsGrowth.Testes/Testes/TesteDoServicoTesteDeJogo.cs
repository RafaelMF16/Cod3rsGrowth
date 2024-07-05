using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Infra.Singletons;
using Cod3rsGrowth.Servico.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes.Testes
{
    public class TesteDoServicoTesteDeJogo : TesteBase
    {
        private readonly ServicoTesteDeJogo _servicoTesteDeJogo;

        public TesteDoServicoTesteDeJogo()
        {
            _servicoTesteDeJogo = ServiceProvider.GetService<ServicoTesteDeJogo>()
                ?? throw new Exception($"Erro ao obter serviço{nameof(ServicoTesteDeJogo)}");

            TesteDeJogoSingleton.Instancia.Clear();
        }

        [Fact]
        public void obter_todos_quando_chamado_retorna_uma_lista_de_teste_de_jogo()
        {
            var listaEsperada = CriarLista();

            var listaDoBanco = _servicoTesteDeJogo.ObterTodos();

            Assert.Equivalent(listaEsperada, listaDoBanco);
        }

        [Fact]
        public void obter_todos_quando_chamado_com_filtro_de_aprovado_deve_retornar_lista_de_teste_de_jogo_com_os_testes_que_tem_aprovado_igual_true()
        {
            CriarLista();

            var filtro = new FiltroTesteDeJogo { Aprovado = true };

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
                    IdJogo = 1
                },
                new TesteDeJogo
                {
                    Id = 3,
                    NomeResponsavelDoTeste = "Italo",
                    Descricao = "Não é um jogo perfeito, mas é jogável",
                    Nota = 7.4m,
                    Aprovado = true,
                    DataRealizacaoTeste = DateTime.Parse("15/06/2024"),
                    IdJogo = 3
                }
            };

            var listaDoBanco = _servicoTesteDeJogo.ObterTodos(filtro);

            Assert.Equivalent(listaEsperada, listaDoBanco);
        }

        [Fact]
        public void obter_todos_quando_chamado_com_filtro_invalido_deve_retornar_lista_de_teste_de_jogo_vazia()
        {
            CriarLista();

            var listaEsperada = new List<TesteDeJogo> { };

            var listaDoBanco = _servicoTesteDeJogo.ObterTodos(new FiltroTesteDeJogo { NomeResponsavelTeste = "Victor"});

            Assert.Equivalent(listaEsperada, listaDoBanco);
        }

        [Fact]
        public void obter_todos_quando_chamado_com_filtro_de_data_deve_retornar_teste_de_jogo_com_data_passada()
        {
            CriarLista();

            var filtro = new FiltroTesteDeJogo { DataMinRealizacaoTeste = new DateTime(2024, 04, 10) };

            var ListaEsperada = new List<TesteDeJogo>
            {
                new TesteDeJogo
                {
                    Id = 2,
                    NomeResponsavelDoTeste = "Paulo",
                    Descricao = "Não gostei do jogo",
                    Nota = 4.5m,
                    Aprovado = false,
                    DataRealizacaoTeste = DateTime.Parse("10/04/2024"),
                    IdJogo = 2
                }
            };

            var listaDoBanco = _servicoTesteDeJogo.ObterTodos(filtro);

            Assert.Equivalent(ListaEsperada, listaDoBanco);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void obter_por_id_quando_chamado_retorna_o_teste_de_jogo_que_tem_o_id_um_dois_ou_tres(int id)
        {
            CriarLista();

            var idEsperado = id;

            var testeDeJogo = _servicoTesteDeJogo.ObterPorId(id);

            Assert.Equal(idEsperado, testeDeJogo.Id);
        }

        [Fact]
        public void obter_por_id_quando_chamado_lanca_excecao_caso_o_id_passado_seja_zero()
        {
            CriarLista();

            const int idNulo = 0;

            Assert.Throws<ArgumentNullException>(() => _servicoTesteDeJogo.ObterPorId(idNulo));
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
                IdJogo = 4
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
                IdJogo = 4
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
                IdJogo = 4
            };

            var mensagemDeErro = Assert.Throws<FluentValidation.ValidationException>(() => _servicoTesteDeJogo.Adicionar(testeDeJogo));

            Assert.Equal("Data de realização do teste deve ser a data atual", mensagemDeErro.Errors.First().ErrorMessage);
        }

        [Fact]
        public void atualizar_quando_chamado_deve_atualizar_o_campo_nota_do_teste_de_jogo_com_id_dois()
        {
            CriarLista();

            var listaTesteDeJogoSingleton = TesteDeJogoSingleton.Instancia;

            var testeDeJogoAtualizado = new TesteDeJogo
            {
                Id = 2,
                NomeResponsavelDoTeste = "Paulo",
                Descricao = "Não gostei do Jogo",
                Nota = 2m,
                Aprovado = false,
                DataRealizacaoTeste = DateTime.Today,
                IdJogo = 1
            };

            _servicoTesteDeJogo.Atualizar(testeDeJogoAtualizado);

            Assert.Contains(listaTesteDeJogoSingleton, testeDeJogo => testeDeJogo == testeDeJogoAtualizado);
        }

        [Fact]
        public void atualizar_quando_chamado_lanca_excecao_caso_id_passado_nao_exista()
        {
            CriarLista();

            var testeDeJogoAtualizado = new TesteDeJogo
            {
                Id = 4,
                NomeResponsavelDoTeste = "Paulo",
                Descricao = "Não gostei do Jogo",
                Nota = 2m,
                Aprovado = false,
                DataRealizacaoTeste = DateTime.Today,
                IdJogo = 1
            };

            Assert.Throws<Exception>(() => _servicoTesteDeJogo.Atualizar(testeDeJogoAtualizado));
        }

        [Fact]
        public void atualizar_quando_chamado_nao_deve_atualizar_teste_de_jogo_caso_nome_do_responsavel_seja_nulo()
        {
            CriarLista();

            var testeDeJogoAtualizado = new TesteDeJogo
            {
                Id = 2,
                Descricao = "Não gostei do Jogo",
                Nota = 2m,
                Aprovado = false,
                DataRealizacaoTeste = DateTime.Today,
                IdJogo = 1
            };

            var mensagemDeErro = Assert.Throws<FluentValidation.ValidationException>(() => _servicoTesteDeJogo.Atualizar(testeDeJogoAtualizado));

            Assert.Equal("O campo Nome do responsável do teste é obrigatório", mensagemDeErro.Errors.First().ErrorMessage);
        }

        [Fact]
        public void deletar_quando_chamado_deve_remover_teste_de_jogo_com_id_um()
        {
            CriarLista();

            var testeDeJogoDeletado = new TesteDeJogo
            {
                Id = 1,
                NomeResponsavelDoTeste = "Rafael",
                Descricao = "O jogo é top",
                Nota = 9m,
                Aprovado = true,
                DataRealizacaoTeste = DateTime.Parse("22/05/2024"),
                IdJogo = 1
            };

            var listaDeTesteDeJogoSingleton = TesteDeJogoSingleton.Instancia;

            _servicoTesteDeJogo.Deletar(testeDeJogoDeletado.Id);

            Assert.DoesNotContain(listaDeTesteDeJogoSingleton, testeDeJogo => testeDeJogo == testeDeJogoDeletado);
        }

        [Fact]
        public void deletar_quando_chamado_nao_deve_remover_teste_de_jogo_com_id_invalido()
        {
            var tamanhoDaListaDoBanco = CriarLista().Count;

            var tamanhoDaListaEsperado = 3;

            var testeDeJogoDeletado = new TesteDeJogo
            {
                Id = 4,
                NomeResponsavelDoTeste = "Samuel",
                Descricao = "O jogo é divertido",
                Nota = 8m,
                Aprovado = true,
                DataRealizacaoTeste = DateTime.Parse("18/06/2024"),
                IdJogo = 4
            };

            _servicoTesteDeJogo.Deletar(testeDeJogoDeletado.Id);

            Assert.Equal(tamanhoDaListaEsperado, tamanhoDaListaDoBanco);
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
                    IdJogo = 1
                },
                new TesteDeJogo
                {
                    Id = 2,
                    NomeResponsavelDoTeste = "Paulo",
                    Descricao = "Não gostei do jogo",
                    Nota = 4.5m,
                    Aprovado = false,
                    DataRealizacaoTeste = DateTime.Parse("10/04/2024"),
                    IdJogo = 2
                },
                new TesteDeJogo
                {
                    Id = 3,
                    NomeResponsavelDoTeste = "Italo",
                    Descricao = "Não é um jogo perfeito, mas é jogável",
                    Nota = 7.4m,
                    Aprovado = true,
                    DataRealizacaoTeste = DateTime.Parse("15/06/2024"),
                    IdJogo = 3
                }
            };

            listaTesteDeJogoSingleton.AddRange(listaDeTesteDeJogo);

            return listaDeTesteDeJogo;
        }
    }
}