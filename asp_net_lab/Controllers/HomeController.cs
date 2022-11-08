using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lab1.Models;

namespace Lab1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public String Hello()
    {
        String name = Request.Query["name"];
        String ageStr = Request.Query["age"];
        int year = DateTime.Now.Year;

        if (int.TryParse(ageStr, out var age))
        {
            return $"Hello {name} You were born in {(year - age)}";
        }

        Response.StatusCode = 400;
        return "";
    }

    public IActionResult Birth(BirthModel birthModel)
    {
        if (birthModel.Name == null)
        {
            Response.StatusCode = 400;
            ViewBag.Message = "Fail";
            return View();
        }

        ViewBag.Message = $"Hello {birthModel.Name}, your birth year is {DateTime.Now.Year - birthModel.Age}";
        return View();
    }

    public IActionResult BirthForm()
    {
        return View();
    }

    public IActionResult Calc(CalculatorModel calculatorModel)
    {
        double result;
        
        switch (calculatorModel.Operation)
        {
            case "add":
                result = calculatorModel.Number1 + calculatorModel.Number2;
                break;
            case "subtract":
                result = calculatorModel.Number1 - calculatorModel.Number2;
                break;
            case "multiply":
                result = calculatorModel.Number1 * calculatorModel.Number2;;
                break;
            case "divide":
                if (calculatorModel.Number2 == 0)
                {
                    Response.StatusCode = 400;
                    ViewBag.Result = "You can't divide by zero!";
                    return View();
                }
                
                result = calculatorModel.Number1 / calculatorModel.Number2;
                break;
            default:
                Response.StatusCode = 400;
                return View();
        }

        ViewBag.Result = $"Result: {result}";
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
