using FluentMigrator;

namespace Cod3rsGrowth.Dominio.Migracao
{
    [Migration(20240620104300)]
    public class _20240620104300_migracao_tabela_jogo : Migration
    {
        public override void Down()
        {
            Delete.Table("Jogo");
        }

        public override void Up()
        {
            Create.Table("Jogo")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Nome").AsString().NotNullable()
                .WithColumn("Genero").AsInt16().NotNullable()
                .WithColumn("Preco").AsDecimal();
        }
    }
}