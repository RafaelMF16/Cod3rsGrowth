using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;

namespace Cod3rsGrowth.Testes
{
    public class TesteDeJogoRepositorioMock : ITesteDeJogoRepositorio
    {
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
            throw new NotImplementedException();
        }
    }
}