using Cod3rsGrowth.Dominio.Entidades;
using LinqToDB;

namespace Cod3rsGrowth.Infra
{
    public class DbCod3rsGrowth : LinqToDB.Data.DataConnection
    {
        public DbCod3rsGrowth(DataOptions<DbCod3rsGrowth> options) : base("Cod3rsGrowth") { }

        public ITable<Jogo> Jogo => this.GetTable<Jogo>();
        public ITable<TesteDeJogo> TesteDeJogo => this.GetTable<TesteDeJogo>();
    }
}