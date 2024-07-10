using Cod3rsGrowth.Dominio.Entidades;
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

        [HttpGet]
        public IActionResult ObterTodos()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Jogo jogo)
        {
            _servicoJogo.Adicionar(jogo);

            return Ok();
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