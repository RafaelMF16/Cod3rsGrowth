using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Dominio.Interfaces
{
    public interface IServicoJogo
    {
        List<Jogo> ObterTodos();
        List<Jogo> RemoverElemento(int id);
    }
}