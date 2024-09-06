using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.EnumGenero;
using Cod3rsGrowth.Dominio.Migracao;
using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorio;
using Cod3rsGrowth.Servico.Servicos;
using Cod3rsGrowth.Servico.Validadores;
using FluentMigrator.Runner;
using FluentValidation;
using LinqToDB;
using LinqToDB.AspNet;

namespace Cod3rsGrowth.Web.Injecao
{
    public static class ModuloDeInjecaoApi
    {
        public static void AdicionarServicosAoEscopo(this WebApplicationBuilder builder)
        {
            var nomeVariavelAmbiente = ConnectionString.connectionString;
            var stringConexao = Environment.GetEnvironmentVariable(nomeVariavelAmbiente)
                ?? throw new Exception($"Variavel de ambiente [{nomeVariavelAmbiente}] não encontrada");

            builder.Services.AddLinqToDBContext<DbCod3rsGrowth>((provider, options)
                => options
                .UseSqlServer(stringConexao));

            builder.Services.AddScoped<ServicoJogo>();
            builder.Services.AddScoped<ServicoTesteDeJogo>();
            builder.Services.AddScoped<IValidator<Jogo>, JogoValidador>();
            builder.Services.AddScoped<IValidator<TesteDeJogo>, TesteDeJogoValidador>();
            builder.Services.AddScoped<IJogoRepositorio, JogoRepositorio>();
            builder.Services.AddScoped<ITesteDeJogoRepositorio, TesteDeJogoRepositorio>();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddMvc().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.Converters.Add(new EnumConverter<Genero>());
            });

            builder.Services.AddCors(p => p.AddPolicy("SapApp", builder =>
            {
                builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));

            builder.Services.AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                .AddSqlServer()
                .WithGlobalConnectionString(stringConexao)
                .ScanIn(typeof(_20240620104300_migracao_tabela_jogo).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }
    }
}