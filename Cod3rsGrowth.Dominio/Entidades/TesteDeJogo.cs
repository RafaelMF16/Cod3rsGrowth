using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Cod3rsGrowth.Dominio.Entidades
{
    public class TesteDeJogo
    {
        public int Id { get; private set; }
        public ResponsavelDoTeste ResponsavelDoTeste { get; private set; }
        public string Descricao { get; private set; }
        public decimal Nota { get; private set; }
        public bool Aprovado { get; private set; }
        public DateTime DataRealizacaoTeste { get; private set; }
        public Jogo JogoId { get; private set; }
    }
}
