using FluentValidation;
using LinqToDB.SqlQuery;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

public static class ExtensaoDosDetalhesDeErro
{
    public static void UsarManipuladorDeExcecoes(this IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.UseExceptionHandler(builder =>
        {
            builder.Run(async context =>
            {
                var manipuladorDeExcecoes = context.Features.Get<IExceptionHandlerFeature>();
                if (manipuladorDeExcecoes != null)
                {
                    var erroDoManipuladorDaExcecao = manipuladorDeExcecoes.Error;
                    var detalhesDeErro = new ProblemDetails
                    {
                        Instance = context.Request.HttpContext.Request.Path
                    };

                    if (erroDoManipuladorDaExcecao is ValidationException validationException)
                    {
                        detalhesDeErro.Title = "Erro de validação";
                        detalhesDeErro.Status = StatusCodes.Status400BadRequest;
                        detalhesDeErro.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";
                        detalhesDeErro.Detail = validationException.StackTrace;
                        detalhesDeErro.Extensions["Erros de validação"] = validationException.Errors
                        .GroupBy(nomePropriedade => nomePropriedade.PropertyName, mensagemErro => mensagemErro.ErrorMessage)
                        .ToDictionary(x => x.Key, x => x.ToList());
                    }
                    else if (erroDoManipuladorDaExcecao is SqlException sqlException)
                    {
                        detalhesDeErro.Title = "Erro no banco de dados";
                        detalhesDeErro.Status = StatusCodes.Status500InternalServerError;
                        detalhesDeErro.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1";
                        detalhesDeErro.Detail = sqlException.StackTrace;
                        detalhesDeErro.Extensions["Erro no banco de dados"] = sqlException.Message;
                    }
                    else
                    {
                        var logger = loggerFactory.CreateLogger("GlobalExceptionHandler");
                        logger.LogError($"Erro inesperado: {manipuladorDeExcecoes.Error}");
                        detalhesDeErro.Title = $"{manipuladorDeExcecoes.Error.Message}";
                        detalhesDeErro.Status = StatusCodes.Status500InternalServerError;
                        detalhesDeErro.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1";
                        detalhesDeErro.Detail = erroDoManipuladorDaExcecao.Demystify().ToString();
                        detalhesDeErro.Extensions["Erro inesperado"] = erroDoManipuladorDaExcecao.Message;
                    }
                    context.Response.StatusCode = detalhesDeErro.Status.Value;
                    context.Response.ContentType = "application/problem+json";
                    var json = JsonConvert.SerializeObject(detalhesDeErro);
                    await context.Response.WriteAsync(json);
                }
            });
        });
    }
}