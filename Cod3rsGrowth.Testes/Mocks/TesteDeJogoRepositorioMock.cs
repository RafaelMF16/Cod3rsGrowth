using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Singletons;

namespace Cod3rsGrowth.Testes.Mocks
{
    public class TesteDeJogoRepositorioMock : ITesteDeJogoRepositorio
    {
        private TesteDeJogoSingleton _instancia = TesteDeJogoSingleton.Instancia;
        public void Adicionar(TesteDeJogo testeDeJogo)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public List<TesteDeJogo> ObterTodos()
        {
            var listaDoBanco = _instancia;

            return listaDoBanco;
        }
    }
}