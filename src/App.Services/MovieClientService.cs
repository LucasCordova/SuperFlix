using System.Text.Json;
using App.Services.Interfaces;
using App.Services.Models;

namespace App.Services;

public class MovieClientService : IMovieClientService
{
    private const string BaseUrl = "https://api.themoviedb.org/3/movie";

    private const string ApiKey =
        "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJmYjZhMzkwYjdhZjU3N2NiMDIyNmExZDZmYjEzMDRhMyIsInN1YiI6IjVjZWM1YTc5YzNhMzY4MzVhNjFlMWUwNSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.2aaz-CpVyzFvZf8dMgr6GwWCX6WKiM486LUr4NHTkt4";

    private const string AuthString = $"Bearer {ApiKey}";


    public async Task<TmdbMovieResult?> GetMovieById(int id)
    {
        var client = new HttpClient();
        var url = $"{BaseUrl}/{id}";
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(url),
            Headers =
            {
                { "accept", "application/json" },
                { "Authorization", AuthString }
            }
        };

        using var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var jsonString = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<TmdbMovieResult>(jsonString);
    }

    public async Task<TmdbResponse?> GetPopularMovies()
    {
        var client = new HttpClient();
        const string url = $"{BaseUrl}/popular?language=en-US&page=1";
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(url),
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