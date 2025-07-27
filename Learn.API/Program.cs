using Learn.API.Endpoints;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World Alyor!");
app.MapLearnsEndpoints();
app.Run();
