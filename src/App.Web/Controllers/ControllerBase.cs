using App.Core.Interfaces;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers;

public class ControllerBase : Controller
{
    protected readonly ILogger<HomeController> Logger;
    protected readonly IMovieClientService MovieClientService;
    protected readonly IMovieLikeRepository MovieLikeRepository;
    protected readonly IAppUserRepository UserRepository;

    public ControllerBase(ILogger<HomeController> logger, IMovieClientService movieClientService,
        IMovieLikeRepository movieLikeRepository,
        IAppUserRepository userRepository)
    {
        Logger = logger;
        MovieClientService = movieClientService;
        MovieLikeRepository = movieLikeRepository;
        UserRepository = userRepository;
    }
}