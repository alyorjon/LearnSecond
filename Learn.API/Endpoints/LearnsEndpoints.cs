using System;
using Learn.API.DTOs;
namespace Learn.API.Endpoints;

public static  class LearnsEndpoints
{
    private static readonly List<LearnDto> learns = [
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
    public static RouteGroupBuilder MapLearnsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("learns");
        // GET /learns
        group.MapGet("/", () => learns);
        // GET /learns/{id}
        group.MapGet("/{id}", (int id) =>
        {
            LearnDto? learn = learns.Find(learn => learn.Id == id);
            return learn == null ? Results.NotFound() : Results.Ok(learn);

        })
        .WithName("GetLearnById");

        // POST /learns
        group.MapPost("/", (CreateLearnerDto newLearn) =>
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
        group.MapPut("/{id}", (int id, UpdateLearnDto updatedLearn) =>
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
        group.MapDelete("/{id}", (int id) =>
        {
            var existingLearn = learns.FindIndex(learn => learn.Id == id);
            if (existingLearn == -1)
            {

                return Results.NotFound();
            }

            learns.RemoveAt(existingLearn);
            return Results.NoContent();
        });

        return group;
    }
}
