using System.Diagnostics;
using Caroline.Extensions;
using Microsoft.AspNetCore.Mvc;
using Caroline.Models;

namespace Caroline.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Random()
    {
        var symbolViewModel = TempData.Get<SymbolViewModel>("symbolViewModel");
        return symbolViewModel is null 
            ? RedirectToAction(nameof(Index)) 
            : View(symbolViewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}