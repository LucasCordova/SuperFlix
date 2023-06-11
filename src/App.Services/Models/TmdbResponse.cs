using System.Text.Json.Serialization;

namespace App.Services.Models;

public class TmdbResponse
{
    [JsonPropertyName("page")] public int Page { get; set; }

    [JsonPropertyName("results")] public List<TmdbMovieResult>? TmdbMovieResults { get; set; }
    [JsonPropertyName("total_pages")] public int TotalPages { get; set; }

    [JsonPropertyName("total_results")] public int TotalResults { get; set; }
}