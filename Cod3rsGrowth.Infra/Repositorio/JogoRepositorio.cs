using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Infra.Interfaces;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cod3rsGrowth.Infra.Repositorio
{
    public class JogoRepositorio : IJogoRepositorio
    {
        private readonly DbCod3rsGrowth bancoDeDados;

        public JogoRepositorio(DbCod3rsGrowth db)
        {
            bancoDeDados = db;
        }

        public void Adicionar(Jogo jogo)
        {
            bancoDeDados.Insert(jogo);
        }

        public void Atualizar(Jogo jogo)
        {
            bancoDeDados.Update(jogo);
        }

        public void Deletar(int id)
        {
            bancoDeDados.Jogo
                .Delete(j => j.Id == id);
        }

        public Jogo ObterPorId(int id)
        {
            return bancoDeDados.GetTable<Jogo>()
                .FirstOrDefault(j => j.Id == id);
        }

        public List<Jogo> ObterTodos(FiltroJogo? filtro = null)
        {
            var jogos = bancoDeDados.GetTable<Jogo>().AsQueryable();

            if (!string.IsNullOrEmpty(filtro?.Nome))
            {
                jogos = jogos.Where(j => j.Nome.StartsWith(filtro.Nome, StringComparison.OrdinalIgnoreCase));
            }
            if (filtro?.Genero != null)
            {
                jogos = jogos.Where(j => j.Genero == filtro.Genero);
            }
            if (filtro?.Preco != null)
            {
                jogos = jogos.Where(j => j.Preco == filtro.Preco);
            }

            return jogos.ToList();
        }

        public bool VerificarSeTemNomeRepetido(Jogo jogo)
        {
            var jogoComNomeRepetido = bancoDeDados.GetTable<Jogo>().ToList().Find(j => j.Nome == jogo.Nome);

            if (jogoComNomeRepetido != null)
            {
                if (jogoComNomeRepetido.Id != jogo.Id)
                {
                    return false;
                }
            }
            return true;
        }
    }
}