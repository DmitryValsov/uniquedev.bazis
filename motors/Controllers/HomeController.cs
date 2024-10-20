using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using motors.Areas.Identity.Data;
using motors.Models;

namespace motors.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<motorsUser> _userManager;

    public HomeController(ILogger<HomeController> logger, UserManager<motorsUser> userManager)
    {
        _logger = logger;
        this._userManager = userManager;
    }

  
    public IActionResult Index()
    {
        ViewData["UserID"] = _userManager.GetUserId(this.User);
        //ViewData["UserName"] = _userManager.Get(this.User);
        return View();
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
