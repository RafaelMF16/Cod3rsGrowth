using Cod3rsGrowth.Dominio.Entidades;
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
            throw new System.NotImplementedException();
        }

        public List<TesteDeJogo> ObterTodos(FiltroTesteDeJogo? filtro = null)
        {
            var testesDeJogos = bancoDeDados.GetTable<TesteDeJogo>().ToList();
            
                if (!string.IsNullOrEmpty(filtro?.NomeResponsavelTeste))
                {
                    testesDeJogos = testesDeJogos.FindAll(t => t.NomeResponsavelDoTeste.StartsWith(filtro.NomeResponsavelTeste, StringComparison.OrdinalIgnoreCase));
                }
                if (filtro?.Aprovado != null)
                {
                    testesDeJogos = testesDeJogos.FindAll(t => t.Aprovado == filtro.Aprovado);
                }
                if (filtro?.DataRealizacaoTeste != null)
                {
                    testesDeJogos = testesDeJogos.FindAll(t => t.DataRealizacaoTeste == filtro.DataRealizacaoTeste);
                }

            return testesDeJogos;
        }
    }
}