using System.Diagnostics;
using App.Core.Interfaces;
using App.Services;
using App.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMovieLikeRepository _repo;

    public HomeController(ILogger<HomeController> logger, IMovieLikeRepository repo)
    {
        _logger = logger;
        _repo = repo;
    }

    public async Task<IActionResult> Index(int? id)
    {
        var response = await MovieClient.GetPopularMovies();


        return View(response);
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