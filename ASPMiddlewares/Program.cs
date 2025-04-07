var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Hello from the first middleware!\n");
    await next();
    await context.Response.WriteAsync("Hello from the first middleware after next!\n");
});

app.Map("/", async (context) =>
{
    await context.Response.WriteAsync("Hello from the Gautam middleware!\n");
});

app.Run(async (context) =>
{
    await context.Response.WriteAsync("Hello from the second middleware!\n");
});

app.Run();

