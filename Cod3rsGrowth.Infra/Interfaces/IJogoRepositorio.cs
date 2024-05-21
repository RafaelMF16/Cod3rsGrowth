namespace Cod3rsGrowth.Infra.Interfaces
{
    public interface IJogoRepositorio
    {
        void ObterTodos();
        void ObterPorId();
        void adicionar();
        void atualizar();
        void remover();
    }
}