var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Hello from the first middleware!\n");
    await next();
    await context.Response.WriteAsync("Hello from the first middleware after next!\n");
});

app.Map("/xyz", xyz =>
{
    xyz.Use(async (context,next) =>
    {
        await context.Response.WriteAsync("Hello from the Gautam middleware!\n");
        await next();
    });
    xyz.Run(async c => await c.Response.WriteAsync("Last Run"));
});

app.Run(async (context) =>
{
    await context.Response.WriteAsync("Hello from the second middleware!\n");
});

app.Run();

