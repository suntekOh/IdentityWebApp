using Microsoft.AspNetCore.Mvc;

namespace IdentityPortal.Controllers;

[Route("[controller]")]
public class DocumentsController : Controller
{
    [HttpGet("NewsLetters")]
    public IActionResult NewsLetterList()
    {
        
        return View();
    }

    [HttpGet("StandardForms")]
    public IActionResult StandardFormList()
    {

        return View();
    }

}
