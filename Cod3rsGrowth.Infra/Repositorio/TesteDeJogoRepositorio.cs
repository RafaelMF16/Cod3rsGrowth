using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using LinqToDB;
using System.Collections.Generic;
using System.Linq;

namespace Cod3rsGrowth.Infra.Repositorio
{
    public class TesteDeJogoRepositorio : ITesteDeJogoRepositorio
    {
        DbCod3rsGrowth bancoDeDados;

        public TesteDeJogoRepositorio(DbCod3rsGrowth db)
        {
            this.bancoDeDados = db;
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
            var testesDeJogos = bancoDeDados.GetTable<TesteDeJogo>();

            if (filtro != null)
            {
                if (filtro.NomeResponsavelTeste != null)
                {
                    testesDeJogos = (ITable<TesteDeJogo>)testesDeJogos.Where(t => t.NomeResponsavelDoTeste == filtro.NomeResponsavelTeste);
                }
                if (filtro.Aprovado != null)
                {
                    testesDeJogos = (ITable<TesteDeJogo>)testesDeJogos.Where(t => t.Aprovado == filtro.Aprovado);
                }
                if (filtro.DataRealizacaoTeste != null)
                {
                    testesDeJogos = (ITable<TesteDeJogo>)testesDeJogos.Where(t => t.DataRealizacaoTeste == filtro.DataRealizacaoTeste);
                }
            }

            return testesDeJogos.ToList();
        }
    }
}