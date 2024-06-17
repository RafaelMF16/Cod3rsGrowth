using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorio;
using FluentValidation;
using System.Collections.Generic;

namespace Cod3rsGrowth.Servico.Servicos
{
    public class ServicoTesteDeJogo
    {
        private readonly IValidator<TesteDeJogo> _testeDeJogoValidador;
        private readonly ITesteDeJogoRepositorio _testeDeJogoRepositorio;

        public ServicoTesteDeJogo(IValidator<TesteDeJogo> testeDeJogoValidador, ITesteDeJogoRepositorio testeDeJogoRepositorio)
        {
            _testeDeJogoRepositorio = testeDeJogoRepositorio;
            _testeDeJogoValidador = testeDeJogoValidador;
        }

        public void Adicionar(TesteDeJogo testeDeJogo)
        {
            _testeDeJogoValidador.ValidateAndThrow(testeDeJogo);
            _testeDeJogoRepositorio.Adicionar(testeDeJogo);
        }

        public void Atualizar(TesteDeJogo testeDeJogo)
        {
            _testeDeJogoValidador.ValidateAndThrow(testeDeJogo);
            _testeDeJogoRepositorio.Atualizar(testeDeJogo);
        }

        public void Deletar(int id)
        {
            _testeDeJogoRepositorio.Deletar(id);
        }

        public TesteDeJogo ObterPorId(int id)
        {
            return _testeDeJogoRepositorio.ObterPorId(id);
        }

        public List<TesteDeJogo> ObterTodos(FiltroTesteDeJogo? filtro = null)
        {
            return _testeDeJogoRepositorio.ObterTodos(filtro);
        }
    }
}