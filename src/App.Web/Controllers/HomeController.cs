using System.Diagnostics;
using App.Core.Entities;
using App.Core.Interfaces;
using App.Services.Interfaces;
using App.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers;

public class HomeController : ControllerBase
{
    public HomeController(ILogger<HomeController> logger, IMovieClientService movieClientService,
        IMovieLikeRepository movieRepository, IAppUserRepository userRepository)
        : base(logger, movieClientService, movieRepository, userRepository)
    {
    }

    public async Task<IActionResult> Index(int? id)
    {
        // User has liked a movie with this id. Add it to the user's liked movies in the database.
        if (id is not null)
        {
            var userId = User.Identity?.Name;

            if (userId is null) return Redirect("/Identity/Account/Login");

            var appUser = await UserRepository.GetByIdentityUserId(userId);

            if (appUser is { }) // same as app != null, app is not null
            {
                var movie = await MovieClientService.GetMovieById(id.Value);

                await MovieLikeRepository.Add(
                    new MovieLike
                    {
                        AppUserId = appUser.Id,
                        MovieId = id.Value,
                        OriginalLanguage = movie?.OriginalLanguage,
                        Overview = movie?.Overview,
                        PosterPath = movie?.PosterPath,
                        ReleaseDate = movie?.ReleaseDate,
                        Title = movie?.Title,
                        VoteAverage = movie?.VoteAverage ?? 0
                    });
            }
        }

        // Filter out the movies already liked
        var likedMovieIds = (await MovieLikeRepository.FindAll()).Select(m => m.MovieId);
        var popularMovies =
            (await MovieClientService.GetPopularMovies())?
            .TmdbMovieResults?.Where(
                movie => !likedMovieIds.Contains(movie.Id));

        return View(popularMovies);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}