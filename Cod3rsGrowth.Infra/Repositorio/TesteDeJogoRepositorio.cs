using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using LinqToDB;
using System.Collections;
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
            throw new System.NotImplementedException();
        }

        public void Atualizar(TesteDeJogo testeDeJogo)
        {
            throw new System.NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new System.NotImplementedException();
        }

        public TesteDeJogo ObterPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<TesteDeJogo> ObterTodos(FiltroTesteDeJogo? filtro = null)
        {
            var testesDeJogos = bancoDeDados.GetTable<TesteDeJogo>().ToList();

            if (filtro != null)
            {
                if (!string.IsNullOrEmpty(filtro.NomeResponsavelTeste))
                {
                    testesDeJogos = testesDeJogos.FindAll(t => t.NomeResponsavelDoTeste == filtro.NomeResponsavelTeste);
                }
                if (filtro.Aprovado != null)
                {
                    testesDeJogos = testesDeJogos.FindAll(t => t.Aprovado == filtro.Aprovado);
                }
                if (filtro.DataRealizacaoTeste != null)
                {
                    testesDeJogos = testesDeJogos.FindAll(t => t.DataRealizacaoTeste == filtro.DataRealizacaoTeste);
                }
            }

            return testesDeJogos;
        }
    }
}