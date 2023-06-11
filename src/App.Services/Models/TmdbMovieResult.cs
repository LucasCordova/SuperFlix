using System.Text.Json.Serialization;

namespace App.Services.Models;

public class TmdbMovieResult
{
    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("original_language")]
    public string? OriginalLanguage { get; set; }

    [JsonPropertyName("overview")] public string? Overview { get; set; }

    [JsonPropertyName("poster_path")] public string? PosterPath { get; set; }

    [JsonPropertyName("release_date")] public string? ReleaseDate { get; set; }

    [JsonPropertyName("title")] public string? Title { get; set; }

    [JsonPropertyName("vote_average")] public double VoteAverage { get; set; }
}