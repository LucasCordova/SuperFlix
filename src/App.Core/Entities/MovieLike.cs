using App.Core.Interfaces;

namespace App.Core.Entities;

public class MovieLike : EntityBase, IAggregateRoot
{
    public int MovieId { get; set; }
    public int AppUserId { get; set; }
    public string? OriginalLanguage { get; set; }
    public string? Overview { get; set; }
    public string? PosterPath { get; set; }
    public string? ReleaseDate { get; set; }
    public string? Title { get; set; }
    public double VoteAverage { get; set; }
}