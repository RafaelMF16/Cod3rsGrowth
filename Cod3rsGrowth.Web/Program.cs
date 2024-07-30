using Cod3rsGrowth.Web.Injecao;
using FluentMigrator.Runner;
using Microsoft.Extensions.FileProviders;

var autorizacoesDeOrigens = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: autorizacoesDeOrigens,
        policy =>
        {
            policy.WithOrigins("https://localhost:7200");
        });
});

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

app.UseCors(autorizacoesDeOrigens);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();