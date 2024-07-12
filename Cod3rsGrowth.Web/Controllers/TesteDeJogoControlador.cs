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
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Criar()
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
