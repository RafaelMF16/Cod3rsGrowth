using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Infra.Interfaces;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cod3rsGrowth.Infra.Repositorio
{
    public class TesteDeJogoRepositorio : ITesteDeJogoRepositorio
    {
        private readonly DbCod3rsGrowth bancoDeDados;

        public TesteDeJogoRepositorio(DbCod3rsGrowth db)
        {
            bancoDeDados = db;
        }
        public void Adicionar(TesteDeJogo testeDeJogo)
        {
            bancoDeDados.Insert(testeDeJogo);
        }

        public void Atualizar(TesteDeJogo testeDeJogo)
        {
            bancoDeDados.Update(testeDeJogo);
        }

        public void Deletar(int id)
        {
            bancoDeDados.TesteDeJogo
                .Delete(t => t.Id == id);
        }

        public TesteDeJogo ObterPorId(int id)
        {
            return bancoDeDados.GetTable<TesteDeJogo>()
                .FirstOrDefault(t => t.Id == id);
        }

        public List<TesteDeJogo> ObterTodos(FiltroTesteDeJogo? filtro = null)
        {
            var testesDeJogos = bancoDeDados.GetTable<TesteDeJogo>().AsQueryable();

            if (!string.IsNullOrEmpty(filtro?.NomeResponsavelTeste))
                testesDeJogos = testesDeJogos.Where(t => t.NomeResponsavelDoTeste.Contains(filtro.NomeResponsavelTeste, StringComparison.OrdinalIgnoreCase));
            
            if (filtro?.Aprovado != null)
                testesDeJogos = testesDeJogos.Where(t => t.Aprovado == filtro.Aprovado);

            if (filtro?.DataRealizacaoTeste != null)
                testesDeJogos = testesDeJogos.Where(t => t.DataRealizacaoTeste == filtro.DataRealizacaoTeste);

            return testesDeJogos.ToList();
        }
    }
}