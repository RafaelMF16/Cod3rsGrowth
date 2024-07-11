using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Servico.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogoControlador : ControllerBase
    {
        private readonly ServicoJogo _servicoJogo;

        public JogoControlador(ServicoJogo servicoJogo)
        {
            _servicoJogo = servicoJogo
                ?? throw new Exception($"Erro ao obter o serviço {typeof(ServicoJogo)}");
        }

        [HttpGet("FiltroJogo")]
        public IActionResult ObterTodos([FromQuery] FiltroJogo filtroJogo)
        {
            var listaDeJogosDoBanco = _servicoJogo.ObterTodos(filtroJogo);

            return Ok(listaDeJogosDoBanco);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Jogo jogo)
        {
            throw new NotImplementedException();
        }

        [HttpPatch]
        public IActionResult Editar()
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public IActionResult Apagar(int id)
        {
            throw new NotImplementedException();
        }
    }
}