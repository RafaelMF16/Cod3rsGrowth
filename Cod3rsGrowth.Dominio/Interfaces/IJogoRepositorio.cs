using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Filtros;
using System.Collections.Generic;

namespace Cod3rsGrowth.Infra.Interfaces
{
    public interface IJogoRepositorio
    {
        List<Jogo> ObterTodos(FiltroJogo? filtro = null);
        Jogo ObterPorId(int id);
        void Adicionar(Jogo jogo);
        void Atualizar(Jogo jogo);
        void Deletar(int id);
        bool VerificarSeTemNomeRepetido(Jogo jogo);
    }
}