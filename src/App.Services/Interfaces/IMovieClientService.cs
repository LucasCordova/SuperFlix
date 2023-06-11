using App.Services.Models;

namespace App.Services.Interfaces;

public interface IMovieClientService
{
    Task<TmdbMovieResult?> GetMovieById(int id);
    Task<TmdbResponse?> GetPopularMovies();
}