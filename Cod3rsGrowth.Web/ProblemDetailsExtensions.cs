using FluentValidation;
using LinqToDB.SqlQuery;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

public static class ProblemDetailsExtensions
{
    public static void UseProblemDetailsExceptionHandler(this IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.UseExceptionHandler(builder =>
        {
            builder.Run(async context =>
            {
                var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (exceptionHandlerFeature != null)
                {
                    var exception = exceptionHandlerFeature.Error;
                    var problemDetails = new ProblemDetails
                    {
                        Instance = context.Request.HttpContext.Request.Path
                    };

                    if (exception is ValidationException validationException)
                    {
                        problemDetails.Title = "Erro de validação";
                        problemDetails.Status = StatusCodes.Status400BadRequest;
                        problemDetails.Detail = validationException.StackTrace;
                        problemDetails.Extensions["Erros de validação"] = validationException.Errors
                        .GroupBy(nomePropriedade => nomePropriedade.PropertyName, mensagemErro => mensagemErro.ErrorMessage)
                        .ToDictionary(x => x.Key, x => x.ToList());
                    }
                    else if (exception is SqlException sqlException)
                    {
                        problemDetails.Title = "Erro no banco de dados";
                        problemDetails.Status = StatusCodes.Status500InternalServerError;
                        problemDetails.Detail = sqlException.StackTrace;
                        problemDetails.Extensions["Erro no banco de dados"] = sqlException.Message;
                    }
                    else
                    {
                        var logger = loggerFactory.CreateLogger("GlobalExceptionHandler");
                        logger.LogError($"Erro inesperado: {exceptionHandlerFeature.Error}");
                        problemDetails.Title = exception.Message;
                        problemDetails.Status = StatusCodes.Status500InternalServerError;
                        problemDetails.Detail = exception.Demystify().ToString();
                    }
                    context.Response.StatusCode = problemDetails.Status.Value;
                    context.Response.ContentType = "application/problem+json";
                    var json = JsonConvert.SerializeObject(problemDetails);
                    await context.Response.WriteAsync(json);
                }
            });
        });
    }
}