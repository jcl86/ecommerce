using Ecommerce.Core.Domain;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Microsoft.Extensions.DependencyInjection
{
    public static partial class ProblemDetailsExtensions
    {
        public static IServiceCollection ConfigureProblemDetails(this IServiceCollection services, IWebHostEnvironment environment)
        {
            return services.AddProblemDetails(configure =>
            {
                configure.Map<NotFoundException>(exception => exception.ToProblemDetails(StatusCodes.Status404NotFound, environment));
                configure.Map<ArgumentException>(exception => exception.ToProblemDetails(StatusCodes.Status400BadRequest, environment));
                configure.Map<Exception>(exception =>
                {
                    Serilog.Log.Logger.Error(exception.Message);
                    return exception.ToProblemDetails(StatusCodes.Status500InternalServerError, environment);
                });
            });
        }

        private static ProblemDetails ToProblemDetails(this Exception exception, int statusCode, IWebHostEnvironment environment)
        {
            string detail = environment.IsDevelopment() ? exception.StackTrace : "";
            return new ProblemDetails()
            {
                Title = exception.Message,
                Detail = detail,
                Status = statusCode,
                Type = $"https://httpstatuses.com/{statusCode}"
            };
        }
    }
}