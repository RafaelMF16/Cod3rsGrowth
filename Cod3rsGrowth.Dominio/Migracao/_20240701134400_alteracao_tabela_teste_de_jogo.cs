using FluentMigrator;

namespace Cod3rsGrowth.Dominio.Migracao
{
    [Migration(20240701134400)]
    public class _20240701134400_alteracao_tabela_teste_de_jogo : Migration
    {
        public override void Down()
        {
            Delete.Table("TesteDeJogo");
        }

        public override void Up()
        {
            Alter.Table("TesteDeJogo")
                .AlterColumn("IdJogo").AsInt64().ForeignKey("Jogo", "Id");
        }
    }
}