using Cod3rsGrowth.Dominio.EnumGenero;
namespace Cod3rsGrowth.Dominio.Entidades
{
    public class Jogo
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public Genero Genero { get; private set; }
        public decimal Preco { get; private set; }
        
    }
}
