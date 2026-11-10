var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Taskflow API Running ");
app.MapGet("/health", () => Results.Ok(new { status = "healthy" }));

app.Run();
