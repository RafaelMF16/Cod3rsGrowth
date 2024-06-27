using System;

namespace Cod3rsGrowth.Dominio.Filtros
{
    public class FiltroTesteDeJogo
    {
        public string? NomeResponsavelTeste { get; set; }
        public bool? Aprovado { get; set; }
        public bool? Reprovado { get; set; }
        public DateTime? DataMinRealizacaoTeste { get; set; }
        public DateTime? DataMaxRealizacaoTeste { get; set; }
    }
}