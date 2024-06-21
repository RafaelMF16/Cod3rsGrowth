using Cod3rsGrowth.Dominio.EnumGenero;

namespace Cod3rsGrowth.Dominio.Filtros
{
    public class FiltroJogo
    {
        public string? Nome { get; set; }
        public Genero? Genero { get; set; }
        public  decimal? Preco { get; set; }
    }
}