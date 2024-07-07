using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nebula.Domain.Abstractions;
using Nebula.Models;

namespace Nebula.Controllers;

[Controller]
[Authorize]
[Route("/dashboard")]
public class DashboardController : Controller
{
    private readonly IPasswordService _service;
    private readonly IHttpContextAccessor _accessor;

    public DashboardController(IPasswordService service, IHttpContextAccessor accessor)
    {
        _service = service;
        _accessor = accessor;
    }

    public IActionResult Index()
    {
        string ownerId = _accessor.HttpContext!.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value;
        var passwords = _service.GetAccountRelatedPasswords(ownerId);
        return View(passwords);
    }

    [HttpGet]
    [Route("/[controller]/create")]
    public IActionResult Create() => View();

    [HttpPost]
    [Route("/[controller]/create")]
    public IActionResult Create(CreatePasswordModel createPasswordModel)
    {
        _service.CreatePassword(createPasswordModel);
        return RedirectToAction("Index", "Dashboard");
    }
}