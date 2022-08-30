using Microsoft.AspNetCore.Mvc;

namespace IdentityPortal.Controllers;

[Route("[controller]")]
public class MessageBoardController : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }
}
