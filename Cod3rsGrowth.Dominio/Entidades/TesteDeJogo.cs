namespace Cod3rsGrowth.Dominio.Entidades
{
    public class TesteDeJogo
    {
        public int Id { get; set; }
        public string NomeResponsavelDoTeste { get; set; }
        public string Descricao { get; set; }
        public decimal Nota { get; set; }
        public bool Aprovado { get; set; }
        public DateTime DataRealizacaoTeste { get; set; }
        public Jogo JogoId { get; set; }
    }
}