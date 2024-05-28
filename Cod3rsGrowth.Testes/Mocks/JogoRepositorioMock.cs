﻿using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Singletons;

namespace Cod3rsGrowth.Testes.Mocks
{
    public class JogoRepositorioMock : IJogoRepositorio
    {
        private JogoSingleton _instancia = JogoSingleton.Instancia;

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
            var obterJogo = _instancia.Where(x => x.Id == id).FirstOrDefault()
                ?? throw new Exception($"Erro ao obter jogo com id {id}");

            return obterJogo;
        }

        public List<Jogo> ObterTodos()
        {
            var listaDoBanco = _instancia;

            return listaDoBanco;
        }
    }
}