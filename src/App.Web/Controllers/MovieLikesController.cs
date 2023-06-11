using App.Core.Interfaces;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers;

public class MovieLikesController : ControllerBase
{
    public MovieLikesController(ILogger<HomeController> logger, IMovieClientService movieClientService,
        IMovieLikeRepository movieLikeRepository,
        IAppUserRepository userRepository) : base(logger, movieClientService, movieLikeRepository, userRepository)
    {
    }

    // GET: MovieLikes
    public async Task<IActionResult> Index()
    {
        var userId = User.Identity?.Name;

        if (userId is null) return Redirect("/Identity/Account/Login");

        var appUser = await UserRepository.GetByIdentityUserId(userId);

        if (appUser is null) return NotFound();

        var movieLikes = (await MovieLikeRepository.FindAll()).Where(m => m.AppUserId == appUser.Id);

        return View(movieLikes);
    }

    public async Task<IActionResult> RemoveLike(int id)
    {
        var userId = User.Identity?.Name;

        if (userId is null) return Redirect("/Identity/Account/Login");

        var appUser = await UserRepository.GetByIdentityUserId(userId);

        if (appUser is null) return NotFound();

        await MovieLikeRepository.Delete(id);

        return RedirectToAction(nameof(Index));
    }
}