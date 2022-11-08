using Common.Entities.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityPortal.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly SignInManager<User> _signInManager;


    public IndexModel(ILogger<IndexModel> logger, SignInManager<User> signInManager)
    {
        _logger = logger;
        _signInManager = signInManager;
    }

    public IActionResult OnGet()
    {
        if (_signInManager.IsSignedIn(User))
        {
            return Page();
        }
        else
        {
            var returnUrl = Url.Page("/Account/Login", null, new { Area = "Identity" });
            return LocalRedirect(returnUrl);

        }
    }
}
