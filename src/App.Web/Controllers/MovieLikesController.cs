using App.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers;

public class MovieLikesController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMovieLikeRepository _movieRepository;
    private readonly IAppUserRepository _userRepository;

    public MovieLikesController(ILogger<HomeController> logger, IMovieLikeRepository movieRepository,
        IAppUserRepository userRepository)
    {
        _logger = logger;
        _movieRepository = movieRepository;
        _userRepository = userRepository;
    }

    // GET: MovieLikes
    public async Task<IActionResult> Index()
    {
        var userId = User.Identity?.Name;

        if (userId is null) return Redirect("/Identity/Account/Login");

        var appUser = await _userRepository.GetByIdentityUserId(userId);

        if (appUser is null) return NotFound();

        var movieLikes = (await _movieRepository.FindAll()).Where(m => m.AppUserId == appUser.Id);

        return View(movieLikes);
    }

    public async Task<IActionResult> RemoveLike(int id)
    {
        var userId = User.Identity?.Name;

        if (userId is null) return Redirect("/Identity/Account/Login");

        var appUser = await _userRepository.GetByIdentityUserId(userId);

        if (appUser is null) return NotFound();

        await _movieRepository.Delete(id);

        return RedirectToAction(nameof(Index));
    }
}