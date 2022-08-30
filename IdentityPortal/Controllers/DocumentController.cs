using Microsoft.AspNetCore.Mvc;

namespace IdentityPortal.Controllers;

[Route("[controller]")]
public class DocumentController : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {
        
        return View();
    }
}
