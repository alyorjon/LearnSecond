namespace Learn.API.DTOs;

public record class LearnDto(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate);
// This DTO is used to transfer data between the API and the client.