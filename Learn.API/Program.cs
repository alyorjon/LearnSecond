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
app.MapGet("/learns/{id}", (int id) =>
{
    LearnDto? learn = learns.Find(learn => learn.Id == id);
    return learn==null?Results.NotFound():Results.Ok(learn);

})
.WithName("GetLearnById");

// POST /learns
app.MapPost("/learns", (CreateLearnerDto newLearn) =>
    {
        LearnDto dto = new(
            learns.Count + 1,
            newLearn.Name,
            newLearn.Genre,
            newLearn.Price,
            newLearn.ReleaseDate
        );
        learns.Add(dto);
        // return Results.Created($"/learns/{dto.Id}", dto);
        return Results.CreatedAtRoute("GetLearnById", new { id = dto.Id }, dto);
    }
);



// PUT /learns/{id}
app.MapPut("/learns/{id}", (int id, UpdateLearnDto updatedLearn) =>
{
    var existingLearn = learns.FindIndex(learn => learn.Id == id);
    if (existingLearn == -1)
    {
        return Results.NotFound();
    }
    learns[existingLearn] = new LearnDto(
        id,
        updatedLearn.Name,
        updatedLearn.Genre,
        updatedLearn.Price,
        updatedLearn.ReleaseDate
    );
    // return Results.NoContent();
    return Results.Ok(learns[existingLearn]);
});

// Delete /learns/{id}
app.MapDelete("/learns/{id}", (int id) =>
{
    var existingLearn = learns.FindIndex(learn => learn.Id == id);
    if (existingLearn == -1)
    {
        Console.WriteLine("Not found");
        return Results.NotFound();
    }
    
    learns.RemoveAt(existingLearn);
    return Results.NoContent();
});
app.Run();
    