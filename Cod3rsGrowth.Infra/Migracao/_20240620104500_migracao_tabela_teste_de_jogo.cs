using FluentMigrator;

namespace Cod3rsGrowth.Dominio.Migracao
{
    [Migration(20240620104500)]
    public class _20240620104500_migracao_tabela_teste_de_jogo : Migration
    {
        public override void Down()
        {
            Delete.Table("TesteDeJogo");
        }

        public override void Up()
        {
            Create.Table("TesteDeJogo")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("NomeResponsavelDoTeste").AsString().NotNullable()
                .WithColumn("Descricao").AsString()
                .WithColumn("Nota").AsDecimal(3, 1).NotNullable()
                .WithColumn("Aprovado").AsBoolean().NotNullable()
                .WithColumn("DataRealizacaoTeste").AsDateTime().NotNullable()
                .WithColumn("IdJogo").AsInt64().ForeignKey("Jogo", "Id").OnDeleteOrUpdate(System.Data.Rule.Cascade);
        }
    }
}