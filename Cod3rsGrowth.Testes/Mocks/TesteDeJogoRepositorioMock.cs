using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
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

        public void Atualizar(TesteDeJogo testeDeJogo)
        {
            throw new NotImplementedException();
        }

        public void Deletar(TesteDeJogo testeDeJogo)
        {
            throw new NotImplementedException();
        }

        public TesteDeJogo ObterPorId(int id)
        {
            var obterTesteDeJogo = _instancia.Where(x => x.Id == id).FirstOrDefault()
                ?? throw new Exception($"Erro ao obter teste de jogo com id {id}");

            return obterTesteDeJogo;
        }

        public List<TesteDeJogo> ObterTodos()
        {
            var listaDoBanco = _instancia;

            return listaDoBanco;
        }
    }
}