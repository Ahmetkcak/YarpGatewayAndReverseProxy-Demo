using ApiGateway.Configurations;
using Yarp.ReverseProxy.Transforms;

namespace ApiGateway.Services;

public static class RequestAndResponseTransformationService
{
    public static IServiceCollection AddRequestAndResponseTransformation(this IServiceCollection services,IConfiguration config)
    {
        services.AddReverseProxy()
            .LoadFromConfig(config.GetSection("ApiGateway"))
            .AddTransforms(builder =>
            {
                builder.AddRequestTransform(transform =>
                {
                    transform.HttpContext.Request.Headers["X-Custom-Header"] = "Custom Request Header";
                    transform.ProxyRequest.Headers.Add("X-Forwarded-Header", "/new-path");
                    transform.HttpContext.Request.Path = "/new-path";

                    var request = transform.HttpContext.Request;
                    Console.WriteLine($"Request path {request.Path}");
                    return ValueTask.CompletedTask;
                });

                builder.AddResponseTransform(transform =>
                {
                    transform.HttpContext.Response.Headers["X-Custom-Response-Header"] = "Custom Response Header";
                  

                    Console.WriteLine("Response is modified");
                    return ValueTask.CompletedTask;
                });
            });


        return services;
    }


    public static IApplicationBuilder UseRRS(this IApplicationBuilder app)
    {
        app.UseMiddleware<Interceptor>();
        return app;
    }
}
