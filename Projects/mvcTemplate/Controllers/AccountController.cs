using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;

public class AccountController : Controller
{
    private readonly SignInManager<Teacher> _signInManager;

    private readonly UserManager<Teacher> _userManager;

    public AccountController(SignInManager<Teacher> signInManager, UserManager<Teacher> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Register(AccountViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = new Teacher
        {
            UserName = model.Email,
            Email = model.Email,
            Firstname = model.Firstname,
            Lastname = model.Lastname,
            PersonalWebSite = model.PersonalWebSite
        };

        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction("Index", "Home");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return View(model);
    }
}