using ApiGateway.Caching;
using ApiGateway.Configurations;
using ApiGateway.Services;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddReverseProxy()
//.LoadFromConfig(builder.Configuration.GetSection("ApiGateway"));
//    .LoadFromMemory(Configuration.GetRoutes(), Configuration.GetClusters());
builder.Services.AddRequestAndResponseTransformation(builder.Configuration);

builder.Services.AddMemoryCache();
builder.Services.AddSingleton<IMemoryCacheService, MemoryCacheService>();
var app = builder.Build();

app.UseRRS();

app.MapReverseProxy();
//app.MapReverseProxy(proxyPipeline =>
//{
//    // Add a custom middleware to the beginning of the pipeline.
//    proxyPipeline.Use(async (context, next) =>
//    {
//        // Retrieve the caching service from the requests service provider.
//        var cacheService = context.RequestServices.GetRequiredService<IMemoryCacheService>();

//        var cacheKey = context.Request.Path.ToString();
//        var cachedResponse = cacheService.GetCache(cacheKey);

//        if (!string.IsNullOrEmpty(cachedResponse))
//        {
//            context.Response.ContentType = "application/json";
//            await context.Response.WriteAsync(cachedResponse);
//        }
//        else
//        {
//            var originalResponseBodyStream = context.Response.Body;

//            using (var responseBodyStream = new MemoryStream())
//            {
//                context.Response.Body = responseBodyStream;

//                await next();

//                context.Response.Body.Seek(0, SeekOrigin.Begin);
//                var responseBodyText = await new StreamReader(context.Response.Body).ReadToEndAsync();
//                context.Response.Body.Seek(0, SeekOrigin.Begin);
//                cacheService.SetCache(cacheKey, responseBodyText, 60);
//                await responseBodyStream.CopyToAsync(originalResponseBodyStream);
//            }
//        }
//    });
//});
app.Run();
