﻿using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Servico.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        private readonly ServicoJogo _servicoJogo;

        public JogoController(ServicoJogo servicoJogo)
        {
            _servicoJogo = servicoJogo
                ?? throw new Exception($"Erro ao obter o serviço {typeof(ServicoJogo)}");
        }

        [HttpGet]
        public IActionResult ObterTodos([FromQuery] FiltroJogo filtroJogo)
        {
            var listaDeJogosDoBanco = _servicoJogo.ObterTodos(filtroJogo);

            return Ok(listaDeJogosDoBanco);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var jogoDoBanco = _servicoJogo.ObterPorId(id);

            return Ok(jogoDoBanco);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Jogo jogo)
        {
            _servicoJogo.Adicionar(jogo);

            return Ok(jogo);
        }

        [HttpPatch]
        public IActionResult Editar([FromBody] Jogo jogo)
        {
            _servicoJogo.Atualizar(jogo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            _servicoJogo.Deletar(id);

            return NoContent();
        }
    }
}