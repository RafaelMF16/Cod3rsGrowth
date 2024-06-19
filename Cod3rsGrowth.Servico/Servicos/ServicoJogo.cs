using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using FluentValidation;
using System;
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
            try
            {
                _jogoValidador.ValidateAndThrow(jogo);
                _jogoRepositorio.Adicionar(jogo);
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

        public void Atualizar(Jogo jogo)
        {
            try
            {
                _jogoValidador.ValidateAndThrow(jogo);
                _jogoRepositorio.Atualizar(jogo);
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
            _jogoRepositorio.Deletar(id);
        }

        public Jogo ObterPorId(int id)
        {
            return _jogoRepositorio.ObterPorId(id)
                ?? throw new Exception($"Erro ao obter jogo com id {id}");
        }

        public List<Jogo> ObterTodos(FiltroJogo? filtro = null)
        {
            return _jogoRepositorio.ObterTodos(filtro);
        }
    }
}