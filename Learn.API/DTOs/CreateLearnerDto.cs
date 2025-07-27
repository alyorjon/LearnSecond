using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learn.API.DTOs
{
    public record class CreateLearnerDto
    (
        string Name,
        string Genre,
        decimal Price,
        DateOnly ReleaseDate
    );
};
