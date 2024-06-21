using Cod3rsGrowth.Dominio.EnumGenero;
using LinqToDB.Mapping;

namespace Cod3rsGrowth.Dominio.Entidades
{
    [Table("Jogo")]
    public class Jogo
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }
        [Column]
        public string Nome { get; set; }
        [Column]
        public Genero Genero { get; set; }
        [Column]
        public decimal Preco { get; set; }
    }
}