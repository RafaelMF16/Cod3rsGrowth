using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Infra.Repositorio;
using Cod3rsGrowth.Web.Injecao;
using FluentMigrator.Runner;
using Microsoft.Extensions.FileProviders;

const string argumentoBancoDeDadosDeTestes = "BancoDeDadosTeste";

var builder = WebApplication.CreateBuilder(args);

if (args.FirstOrDefault() == argumentoBancoDeDadosDeTestes)
{
    const string stringDeConexaoDoBancoDeDadosDeTestes = "ConnectionStringBancoDeDadosDeTestes";
    ConnectionString.connectionString = stringDeConexaoDoBancoDeDadosDeTestes;
}

builder.AdicionarServicosAoEscopo();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UsarManipuladorDeExcecoes(app.Services.GetRequiredService<ILoggerFactory>());

using (var escopo = app.Services.CreateScope())
{
    var executarMigracao = escopo.ServiceProvider.GetRequiredService<IMigrationRunner>();
    executarMigracao.MigrateUp();
}

app.UseStaticFiles(new StaticFileOptions 
{
    ServeUnknownFileTypes = true 
});

app.UseFileServer(new FileServerOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "wwwroot")),
    EnableDirectoryBrowsing = true
});

app.UseRouting();

app.UseCors("SapApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

if (args?.FirstOrDefault() == argumentoBancoDeDadosDeTestes)
{
    using (var escopo = app.Services.CreateScope())
    {
        var contextoBancoDeDados = escopo.ServiceProvider.GetRequiredService<DbCod3rsGrowth>();
        DeletarJogosRepositorio.DeletarJogosAdicionadosEmTeste(contextoBancoDeDados);
    }
}

app.Run();