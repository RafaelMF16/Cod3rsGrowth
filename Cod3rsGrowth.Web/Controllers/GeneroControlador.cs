using Cod3rsGrowth.Dominio.EnumGenero;
using Cod3rsGrowth.Servico.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroControlador : ControllerBase
    {
        [HttpGet]
        public IActionResult ObterGeneros()
        {
            var generos = Enum.GetValues(typeof(Genero))
                                 .Cast<Genero>()
                                 .Select(enumerador => new
                                 {
                                     Key = (int)enumerador,
                                     Descricao = ServicoGenero.ObterDescricaoEnum(enumerador)
                                 })
                                 .ToList();

            return Ok(generos);
        }
    }
}