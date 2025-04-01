namespace GameReviews.Contracts.Models;

public class GameCreateRequest
{
    public required string Name { get; set; }

    public required string Description { get; set; }

    public DateTime ReleaseDate { get; set; }
}
