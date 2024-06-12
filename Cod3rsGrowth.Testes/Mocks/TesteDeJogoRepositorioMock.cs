using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorio;
using Cod3rsGrowth.Infra.Singletons;
using FluentValidation;

namespace Cod3rsGrowth.Testes.Mocks
{
    public class TesteDeJogoRepositorioMock : ITesteDeJogoRepositorio
    {
        private TesteDeJogoSingleton _instancia;
        private readonly IValidator<TesteDeJogo> _testeDeJogoValidador;

        public TesteDeJogoRepositorioMock(IValidator<TesteDeJogo> validador)
        {
            _instancia = TesteDeJogoSingleton.Instancia;

            _testeDeJogoValidador = validador;
        }
        public void Adicionar(TesteDeJogo testeDeJogo)

        {
            _testeDeJogoValidador.ValidateAndThrow(testeDeJogo);

            _instancia.Add(testeDeJogo);
        }

        public void Atualizar(TesteDeJogo testeDeJogoAtualizado)
        {
            _testeDeJogoValidador.ValidateAndThrow(testeDeJogoAtualizado);

            var testeDeJogoDesatualizado = _instancia.Find(testeDeJogo => testeDeJogo.Id == testeDeJogoAtualizado.Id)
                ?? throw new Exception($"Erro ao obter teste de jogo com id {testeDeJogoAtualizado.Id}");

            var index = _instancia.IndexOf(testeDeJogoDesatualizado);

            _instancia[index] = testeDeJogoAtualizado;
        }

        public void Deletar(int id)
        {
            var testeDeJogoQueVaiSerDeletado = _instancia.Find(testeDeJogo => testeDeJogo.Id == id)
                ?? throw new Exception($"Erro ao obter teste de jogo com id {id}");

            _instancia.Remove(testeDeJogoQueVaiSerDeletado);
        }

        public TesteDeJogo ObterPorId(int id)
        {
            var obterTesteDeJogo = _instancia.Find(x => x.Id == id)
                ?? throw new Exception($"Erro ao obter teste de jogo com id {id}");

            return obterTesteDeJogo;
        }

        public List<TesteDeJogo> ObterTodos(FiltroTesteDeJogo? filtro = null)
        {
            var testesDeJogo = _instancia.ToList();

            if (!string.IsNullOrEmpty(filtro?.NomeResponsavelTeste))
            {
                testesDeJogo = testesDeJogo.FindAll(t => t.NomeResponsavelDoTeste.StartsWith(filtro.NomeResponsavelTeste, StringComparison.OrdinalIgnoreCase));
            }
            if (filtro?.Aprovado != null)
            {
                testesDeJogo = testesDeJogo.FindAll(t => t.Aprovado == filtro.Aprovado);
            }
            if (filtro?.DataRealizacaoTeste != null)
            {
                testesDeJogo = testesDeJogo.FindAll(t => t.DataRealizacaoTeste == filtro.DataRealizacaoTeste);
            }

            return testesDeJogo;
        }
    }
}