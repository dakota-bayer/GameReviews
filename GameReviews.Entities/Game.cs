namespace GameReviews.Entities;

public class Game
{
    public Guid GameId { get; set; }

    public required string Name { get; set; }

    public required string Description { get; set; }

    public DateTime ReleaseDate { get; set; }
}
