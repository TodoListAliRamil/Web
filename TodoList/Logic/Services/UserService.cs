using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using TodoList.Logic.Interfaces.Repositories;
using TodoList.Logic.Interfaces.Services;
using TodoList.Models.Entites;

namespace TodoList.Logic.Services;

public sealed class UserService : IUserService, IAuthorizationService
{
    private readonly IUserRepository _userRepository;
    private readonly ICryptoService _cryptoService;
    private readonly HttpContext _httpContext;
    private const string cookies = CookieAuthenticationDefaults.AuthenticationScheme;

    public UserService(IUserRepository userRepository, ICryptoService cryptoService, IHttpContextAccessor httpContextAccessor)
    {
        _userRepository = userRepository;
        _cryptoService = cryptoService;
        _httpContext = httpContextAccessor.HttpContext ?? throw new InvalidOperationException("Пустой HTTP контекст");
    }


    public User Get()
    {
        if (!IsAuthenticated())
        {
            throw new InvalidOperationException("Пользователь не авторизован");
        }
        
        string login = _httpContext.User.Identity?.Name ?? throw new InvalidOperationException("Пользователь не авторизован");
        return _userRepository.Get(login) ?? throw new InvalidOperationException("По такому логину пользователь отсутствует");
    }

    public void Logout()
    {
        _httpContext.SignOutAsync(cookies); //выход из куки
    }

   

    public bool TryLogin(string login, string password)
    {
        if (IsAuthenticated())
        {
            return false;
        }

        if (!IsLoginExist(login))
        {
            return false;
        }

        var hash = _cryptoService.ToHash(password);
        var user = _userRepository.Get(login);
        if (!hash.Equals(user?.Password))
        {
            return false;
        }

        var claims = new List<Claim> { new(ClaimTypes.Name, login) }; //??
        var claimsIdentity = new ClaimsIdentity(claims, cookies);
        _httpContext.SignInAsync(cookies, new ClaimsPrincipal(claimsIdentity));
        return true;
    }

    public bool TryRegister(User user)
    {
        if (IsAuthenticated())
        {
            return false;
        }

        if (IsLoginExist(user.Login))
        {
            return false;
        }

        var hash = _cryptoService.ToHash(user.Password);
        user.Password = hash;
        _userRepository.Add(user);
        return true;

    }

    private bool IsAuthenticated() // проверка авторизация пользователя
    {
        var userIdentity = _httpContext.User.Identity;
        return userIdentity != null && userIdentity.IsAuthenticated;
    }
    
    private bool IsLoginExist(string login) //провека , есть ли такой пользователь в базе
    {
        var user = _userRepository.Get(login);
        return user != null;
    }
}
    

