using Microsoft.AspNetCore.Mvc;
using Nebula.Domain.Abstractions.Services;

namespace Nebula.Controllers;

[Controller]
[Route("/auth")]
public class AuthController : Controller
{
    private IAuthorizationService _service;

    public AuthController(IAuthorizationService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {  
        return View();
    }

    [Route("/auth/discord")]
    public async Task<IActionResult> Discord(string code)
    {
        await _service.AuthorizeThroughDiscord(code);
        return RedirectToAction("Index", "Dashboard");
    }

    [Route("/auth/signout")]
    public async Task<IActionResult> LogOut()
    {
        await _service.SignOut();
        return RedirectToAction("Index", "Auth");
    }
}