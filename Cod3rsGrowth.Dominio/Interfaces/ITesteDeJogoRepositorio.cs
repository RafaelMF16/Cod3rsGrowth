using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Repositorio;
using System.Collections.Generic;

namespace Cod3rsGrowth.Infra.Interfaces
{
    public interface ITesteDeJogoRepositorio
    {
        List<TesteDeJogo> ObterTodos(FiltroTesteDeJogo? filtro = null);
        TesteDeJogo ObterPorId(int id);
        void Adicionar(TesteDeJogo testeDeJogo);
        void Atualizar(TesteDeJogo testeDeJogo);
        void Deletar(int id);
    }
}