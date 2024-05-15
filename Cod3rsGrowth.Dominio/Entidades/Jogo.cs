using Cod3rsGrowth.Dominio.EnumGenero;
namespace Cod3rsGrowth.Dominio.Entidades
{
    public class Jogo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Genero Genero { get; set; }
        public decimal Preco { get; set; }
    }
}