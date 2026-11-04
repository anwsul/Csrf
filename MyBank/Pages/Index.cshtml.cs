using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;

public class IndexModel : PageModel
{
    public IActionResult OnPost()
    {
        HttpContext.Session.Remove("auth");
        return Redirect("/Login");
    }
}
