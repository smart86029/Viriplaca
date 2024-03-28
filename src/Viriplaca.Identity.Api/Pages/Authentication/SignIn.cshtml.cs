using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Viriplaca.Identity.App.Authentication.SignIn;

namespace Viriplaca.Identity.Api.Pages.Authentication;

public class SignInModel(ISender sender)
    : PageModel
{
    private readonly ISender _sender = sender;

    [Required]
    [BindProperty]
    public string UserName { get; set; } = string.Empty;

    [Required]
    [BindProperty]
    public string Password { get; set; } = string.Empty;

    [BindProperty]
    public string ReturnUrl { get; set; } = string.Empty;

    public async Task<IActionResult> OnGetAsync(string returnUrl)
    {
        await Task.CompletedTask;
        UserName = string.Empty;
        ReturnUrl = returnUrl;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var command = new SignInCommand(UserName, Password);
        var token = await _sender.Send(command);
        //var user = await _accountApp.GetUserAsync(UserName, Password);
        //if (user is null)
        //{
        //    ModelState.AddModelError(string.Empty, "Invalid username or password");
        //    return Page();
        //}

        var claims = new List<Claim>
        {
            new(ClaimTypes.Sid, token.SubjectId),
        };
        var user = new ClaimsPrincipal(new ClaimsIdentity(claims));
        var properties = new AuthenticationProperties
        {
            IsPersistent = true,
            ExpiresUtc = DateTimeOffset.UtcNow.Add(TimeSpan.FromDays(30)),
        };
        await HttpContext.SignInAsync(user, properties);

        if (Url.IsLocalUrl(ReturnUrl))
        {
            return Redirect(ReturnUrl);
        }

        if (ReturnUrl.IsNullOrWhiteSpace())
        {
            return Redirect("~/");
        }

        throw new Exception("Invalid return URL");
    }
}
