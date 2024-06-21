using LinqToDB.Mapping;
using System;

namespace Cod3rsGrowth.Dominio.Entidades 
{
    [Table("TesteDeJogo")]    
    public class TesteDeJogo
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }
        [Column]
        public string NomeResponsavelDoTeste { get; set; }
        [Column]
        public string Descricao { get; set; }
        [Column]
        public decimal Nota { get; set; }
        [Column]
        public bool Aprovado { get; set; }
        [Column]
        public DateTime DataRealizacaoTeste { get; set; }
        [Column]
        public int JogoId { get; set; }
    }
}