using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Servico.Servicos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TesteDeJogoControlador : ControllerBase
    {
        private readonly ServicoTesteDeJogo _servicoTesteDeJogo;

        public TesteDeJogoControlador(ServicoTesteDeJogo servicoTesteDeJogo)
        {
            _servicoTesteDeJogo = servicoTesteDeJogo
                ?? throw new Exception($"Erro ao obter o serviço {typeof(ServicoTesteDeJogo)}");
        }

        [HttpGet]
        public IActionResult ObterTodos([FromQuery] FiltroTesteDeJogo filtroTesteDeJogo)
        {
            var listaDeTesteDeJogoDoBanco = _servicoTesteDeJogo.ObterTodos(filtroTesteDeJogo);

            return Ok(listaDeTesteDeJogoDoBanco);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var jogoDoBanco = _servicoTesteDeJogo.ObterPorId(id);

            return Ok(jogoDoBanco);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] TesteDeJogo testeDeJogo)
        {
            _servicoTesteDeJogo.Adicionar(testeDeJogo);

            return Ok();
        }

        [HttpPatch]
        public IActionResult Editar([FromBody] TesteDeJogo testeDeJogo)
        {
            _servicoTesteDeJogo.Atualizar(testeDeJogo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Apagar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
