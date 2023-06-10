using System.Diagnostics;
using App.Core.Entities;
using App.Core.Interfaces;
using App.Services;
using App.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMovieLikeRepository _movieRepository;
    private readonly IAppUserRepository _userRepository;

    public HomeController(ILogger<HomeController> logger, IMovieLikeRepository movieRepository,
        IAppUserRepository userRepository)
    {
        _logger = logger;
        _movieRepository = movieRepository;
        _userRepository = userRepository;
    }

    public async Task<IActionResult> Index(int? likedMovieId)
    {
        if (likedMovieId is not null)
        {
            var userId = User.Identity?.Name;

            if (userId is null) return Redirect("/Identity/Account/Login");

            var appUser = _userRepository.GetByIdentityUserId(userId);
            if (appUser is not null)
                _movieRepository.Add(new MovieLike { AppUserId = appUser.Id, MovieId = likedMovieId.Value });
        }

        var movies = await MovieClient.GetPopularMovies();

        // Filter out the movies already liked
        var likedMovieIds = _movieRepository.FindAll().Select(m => m.MovieId);
        var filteredMovies = movies?.results.Where(m => !likedMovieIds.Contains(m.id));

        return View(filteredMovies);
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