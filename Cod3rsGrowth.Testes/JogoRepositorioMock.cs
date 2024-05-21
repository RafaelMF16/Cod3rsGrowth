using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;

namespace Cod3rsGrowth.Testes
{
    public class JogoRepositorioMock : IJogoRepositorio
    {
        public void Adicionar(Jogo jogo)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Jogo jogo)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Jogo jogo)
        {
            throw new NotImplementedException();
        }

        public Jogo ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Jogo> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}