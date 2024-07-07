namespace Nebula.Models;

public record CreatePasswordModel(
    string Title,
    string OwnerId, 
    string UnprotectedValue, 
    string? ServiceURI
);