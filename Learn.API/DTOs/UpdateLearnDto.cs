namespace Learn.API.DTOs;

public record class UpdateLearnDto
(
    string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate
);
