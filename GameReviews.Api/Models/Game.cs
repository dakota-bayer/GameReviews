namespace GameReviews.Api.Models;

public class Game
{
    public required string GameId { get; set; }

    public required string Name { get; set; }

    public required string Description { get; set; }

    public DateTime ReleaseDate { get; set; }
}

