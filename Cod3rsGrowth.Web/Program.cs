using Cod3rsGrowth.Web.Injecao;
using FluentMigrator.Runner;

var builder = WebApplication.CreateBuilder(args);

var loggerFactory = new LoggerFactory();

var servicos = new ServiceCollection();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.AdicionarServicosAoEscopo();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.TratarExcecoes(app.Services.GetRequiredService<ILoggerFactory>());

using (var escopo = app.Services.CreateScope())
{
    var executarMigracao = escopo.ServiceProvider.GetRequiredService<IMigrationRunner>();
    executarMigracao.MigrateUp();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();