using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using MyBank.Models;
using MyBank.Services;

namespace MyBank.Pages
{
    class SignupModel(IMemoryCache memoryCache) : PageModel
    {
        [BindProperty]
        public User? Input { get; set; }

        public IActionResult OnPost()
        {
            if (Input != null)
            {
                UserService.CreateUser(Input, memoryCache);
                UserService.SetSession(Input, HttpContext.Session, memoryCache);
                return Redirect("/");
            }

            return Redirect("/Signup");
        }

    }
}
