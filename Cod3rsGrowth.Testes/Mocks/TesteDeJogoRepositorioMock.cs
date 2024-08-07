﻿using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Singletons;

namespace Cod3rsGrowth.Testes.Mocks
{
    public class TesteDeJogoRepositorioMock : ITesteDeJogoRepositorio
    {
        private TesteDeJogoSingleton _instancia;

        public TesteDeJogoRepositorioMock()
        {
            _instancia = TesteDeJogoSingleton.Instancia;
        }
        public void Adicionar(TesteDeJogo testeDeJogo)

        {
            _instancia.Add(testeDeJogo);
        }

        public void Atualizar(TesteDeJogo testeDeJogoAtualizado)
        {
            var testeDeJogoDesatualizado = _instancia.Find(testeDeJogo => testeDeJogo.Id == testeDeJogoAtualizado.Id);

            var index = _instancia.IndexOf(testeDeJogoDesatualizado);

            _instancia[index] = testeDeJogoAtualizado;
        }

        public void Deletar(int id)
        {
            var testeDeJogoQueVaiSerDeletado = _instancia.Find(testeDeJogo => testeDeJogo.Id == id);

            _instancia.Remove(testeDeJogoQueVaiSerDeletado);
        }

        public TesteDeJogo ObterPorId(int id)
        {
            return _instancia.Find(x => x.Id == id);
        }

        public List<TesteDeJogo> ObterTodos(FiltroTesteDeJogo? filtro = null)
        {
            var testesDeJogo = _instancia.ToList();

            if (!string.IsNullOrEmpty(filtro?.NomeResponsavelTeste))
            {
                testesDeJogo = testesDeJogo.FindAll(t => t.NomeResponsavelDoTeste.StartsWith(filtro.NomeResponsavelTeste, StringComparison.OrdinalIgnoreCase));
            }
            if (filtro?.Aprovado != null)
            {
                testesDeJogo = testesDeJogo.FindAll(t => t.Aprovado == filtro.Aprovado);
            }
            if (filtro?.DataMinRealizacaoTeste != null)
            {
                testesDeJogo = testesDeJogo.FindAll(t => t.DataRealizacaoTeste == filtro.DataMinRealizacaoTeste);
            }

            return testesDeJogo;
        }
    }
}