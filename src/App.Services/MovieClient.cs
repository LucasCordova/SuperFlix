using System.Text.Json;
using App.Services.Models;

namespace App.Services;

public static class MovieClient
{
    private const string Url = "https://api.themoviedb.org/3/movie/popular?language=en-US&page=1";
    private const string ApiKey = "YOUR_API_KEY";
    private const string AuthString = $"Bearer {ApiKey}";


    public static async Task<TmdbResponse?> GetPopularMovies()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(Url),
            Headers =
            {
                { "accept", "application/json" },
                { "Authorization", AuthString }
            }
        };

        using var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var jsonString = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<TmdbResponse>(jsonString);
    }
}