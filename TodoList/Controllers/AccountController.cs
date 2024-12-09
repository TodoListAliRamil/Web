using Microsoft.AspNetCore.Mvc;
using TodoList.Logic.Interfaces.Services;
using TodoList.Models.Entites;

namespace TodoList.Controllers;

public sealed class AccountController : Controller
{
    private readonly IAuthorizationService _authorizationService;

    public AccountController(IAuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
    }

    [HttpGet]
    public IActionResult Login()
    {
       return View();
    }

    [HttpPost]//получить данные со страницы
    public IActionResult Login(string login, string password)
    {
        if (_authorizationService.TryLogin(login, password)) 
        {
            return RedirectToAction("Index", "Home");
        } 

        return View();
    }

    [HttpGet] //для открытия страницы
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]//регистрация 
    public IActionResult Register(User user)
    {
        if (_authorizationService.TryRegister(user))
        {
           return RedirectToAction(nameof(Login));
        }

        return View();
    }

    public IActionResult Logout()
    {
        _authorizationService.Logout();
        return RedirectToAction(nameof(Login));
    }




}
