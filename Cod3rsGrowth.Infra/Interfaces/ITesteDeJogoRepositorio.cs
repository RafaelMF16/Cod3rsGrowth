using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Infra.Interfaces
{
    public interface ITesteDeJogoRepositorio
    {
        List<TesteDeJogo> ObterTodos();
        TesteDeJogo ObterPorId(int id);
        void Adicionar(TesteDeJogo testeDeJogo);
        void Atualizar(TesteDeJogo testeDeJogo);
        void Deletar(TesteDeJogo testeDeJogo);
    }
}