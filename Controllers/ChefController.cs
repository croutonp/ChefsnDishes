using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsnDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsnDishes.Controllers;

public class ChefController : Controller
{
    private readonly ILogger<ChefController> _logger;

    private MyContext _context;

    public ChefController(ILogger<ChefController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }



    //route for viewing all chefs
    [HttpGet("")]
    public IActionResult Chefs()
    {
        List<Chef> Chefs = _context.Chefs.Include(d => d.Dishes).ToList();
        return View(Chefs); //do not have to indicate all chefs since its the same, but passing in our chefs model
    }



    //route for creating a new chef
    [HttpGet("chefs/new")]
    public ViewResult NewChef()
    {
        return View(); //View Results because this will only render the empty form
    }



    //route that will post/create new chef into our DB
    [HttpPost("chefs/create")]
    public IActionResult CreateChef(Chef newChef)
    {
        if (!ModelState.IsValid) //confirming this passes our validations
        {
            return View("NewChef");
        }
        _context.Add(newChef);
        _context.SaveChanges();
        return RedirectToAction("Chefs");
    }





    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}