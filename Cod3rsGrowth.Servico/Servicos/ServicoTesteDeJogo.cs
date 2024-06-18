using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorio;
using FluentValidation;
using System;
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
            try
            {
                _testeDeJogoValidador.ValidateAndThrow(testeDeJogo);
                _testeDeJogoRepositorio.Adicionar(testeDeJogo);
            } 
            catch (ValidationException validationException)
            {
                throw new ValidationException(validationException.Errors);
            } 
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public void Atualizar(TesteDeJogo testeDeJogo)
        {
            try
            {
                _testeDeJogoValidador.ValidateAndThrow(testeDeJogo);
                _testeDeJogoRepositorio.Atualizar(testeDeJogo);
            }
            catch (ValidationException validationException)
            {
                throw new ValidationException(validationException.Errors);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public void Deletar(int id)
        {
            _testeDeJogoRepositorio.Deletar(id);
        }

        public TesteDeJogo ObterPorId(int id)
        {
            return _testeDeJogoRepositorio.ObterPorId(id)
                ?? throw new Exception($"Erro ao obter teste de jogo com id {id}");
        }

        public List<TesteDeJogo> ObterTodos(FiltroTesteDeJogo? filtro = null)
        {
            return _testeDeJogoRepositorio.ObterTodos(filtro);
        }
    }
}