using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using LinqToDB;
using System.Collections.Generic;
using System.Linq;

namespace Cod3rsGrowth.Infra.Repositorio
{
    public class JogoRepositorio : IJogoRepositorio
    {
        DbCod3rsGrowth bancoDeDados;

        public JogoRepositorio(DbCod3rsGrowth bancoDeDados)
        {
            this.bancoDeDados = bancoDeDados;
        }

        public void Adicionar(Jogo jogo)
        {
            throw new System.NotImplementedException();
        }

        public void Atualizar(Jogo jogo)
        {
            throw new System.NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new System.NotImplementedException();
        }

        public Jogo ObterPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Jogo> ObterTodos(FiltroJogo? filtro = null)
        {
            var jogos = bancoDeDados.GetTable<Jogo>();

            if (filtro != null)
            {
                if (filtro.Nome != null)
                {
                    jogos = (ITable<Jogo>)jogos.Where(j => j.Nome == filtro.Nome);
                }
                if (filtro.Genero != null)
                {
                    jogos = (ITable<Jogo>)jogos.Where(j => j.Genero == filtro.Genero);
                }
                if (filtro.Preco != null)
                {
                    jogos = (ITable<Jogo>)jogos.Where(j => j.Preco == filtro.Preco);
                }
            }

            return jogos.ToList();
        }
    }
}