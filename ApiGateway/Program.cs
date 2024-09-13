using ApiGateway.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy()
    //.LoadFromConfig(builder.Configuration.GetSection("ApiGateway"));
    .LoadFromMemory(Configuration.GetRoutes(), Configuration.GetClusters()); 

var app = builder.Build();

app.MapReverseProxy();
app.Run();
