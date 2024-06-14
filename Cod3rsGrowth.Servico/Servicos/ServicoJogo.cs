using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;

namespace Cod3rsGrowth.Servico.Servicos
{
    public class ServicoJogo
    {
        private readonly IValidator<Jogo> _jogoValidador;
        private readonly IJogoRepositorio _jogoRepositorio;

        public ServicoJogo(IValidator<Jogo> jogoValidador, IJogoRepositorio jogoRepositorio)
        {
            _jogoRepositorio = jogoRepositorio;
            _jogoValidador = jogoValidador;
        }
        public void Adicionar(Jogo jogo)
        {
            ValidationResult result = _jogoValidador.Validate(jogo, options => options.IncludeRuleSets("Adicionar", "default"));

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            } 
                _jogoRepositorio.Adicionar(jogo);
        }

        public void Atualizar(Jogo jogo)
        {
            _jogoValidador.ValidateAndThrow(jogo);
            _jogoRepositorio.Atualizar(jogo);
        }

        public void Deletar(int id)
        {
            _jogoRepositorio.Deletar(id);
        }

        public Jogo ObterPorId(int id)
        {
            return _jogoRepositorio.ObterPorId(id);
        }

        public List<Jogo> ObterTodos(FiltroJogo? filtro = null)
        {
            return _jogoRepositorio.ObterTodos(filtro);
        }
    }
}