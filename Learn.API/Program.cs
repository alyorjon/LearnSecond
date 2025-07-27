using Learn.API.DTOs;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
List<LearnDto> learns = [
    new LearnDto(
        1,
        "Alyorjon",
        "Coder",
        1111.11M,
        new DateOnly(2023,1,1)),
    new LearnDto(
        2,
        "Donyorjon",
        "AI coder",
        2222.22M,
        new DateOnly(2023,2,2)),
    new LearnDto(
        3,
        "Aisha",
        "AI coder",
        3333.33M,
        new DateOnly(2023,3,3))];
app.MapGet("/", () => "Hello World Alyor!");
// GET /learns
app.MapGet("/learns", () => learns);
// GET /learns/{id}
app.MapGet("/learns/{id}",(int id)=> learns.Find(learn => learn.Id == id));

app.Run();
    