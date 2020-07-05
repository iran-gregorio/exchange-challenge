using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ExchangeChallenge.Infra.Extensions
{
    public static class ExceptionHandlerExtension
	{
		public static void UseGlobalExceptionHandler(this IApplicationBuilder app, ILoggerFactory loggerFactory)
		{
			app.UseExceptionHandler(builder =>
			{
				builder.Run(async context =>
				{
					var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

					if (exceptionHandlerFeature != null)
					{
						var logger = loggerFactory.CreateLogger("GlobalExceptionHandler");
						logger.LogError($"Unexpected error: {exceptionHandlerFeature.Error}");

						context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
						context.Response.ContentType = "application/json";

						var json = new
						{
							context.Response.StatusCode,
							Message = "An error occurred whilst processing your request",
							Detailed = exceptionHandlerFeature.Error.Message
						};

						await context.Response.WriteAsync(JsonSerializer.Serialize(json));
					}
				});
			});
		}
	}
}
