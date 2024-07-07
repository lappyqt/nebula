using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Nebula.Controllers;

[Controller]
[AllowAnonymous]
[Route("/")]
public class HomeController : Controller
{
    public IActionResult Index() => View();
}