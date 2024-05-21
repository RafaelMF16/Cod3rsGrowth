namespace Cod3rsGrowth.Infra.Interfaces;

public interface ITesteDeJogoRepositorio
{
    void ObterTodos();
    void ObterPorId();
    void adicionar();
    void atualizar();
    void remover();
}