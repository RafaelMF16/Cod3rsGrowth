﻿using Cod3rsGrowth.Dominio.Entidades;
using System.Collections.Generic;

namespace Cod3rsGrowth.Infra.Interfaces
{
    public interface IJogoRepositorio
    {
        List<Jogo> ObterTodos();
        Jogo ObterPorId(int id);
        void Adicionar(Jogo jogo);
        void Atualizar(Jogo jogo);
        void Deletar(int id);
    }
}