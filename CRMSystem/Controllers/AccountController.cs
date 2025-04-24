using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using CRMSystem.Models;

public class AccountController : Controller
{
    private ApplicationDbContext db = new ApplicationDbContext();

    public ActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email, FullName = model.Role };

            var result = userManager.Create(user, model.Password);
            if (result.Succeeded)
            {
                userManager.AddToRole(user.Id, model.Role);
                return RedirectToAction("Login");
            }
        }
        return View(model);
    }

    public ActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = userManager.Find(model.Email, model.Password);

            if (user != null)
            {
                var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, identity);

                //if (userManager.IsInRole(user.Id, "Admin")) return RedirectToAction("AIndex", "Admin");
                //if (userManager.IsInRole(user.Id, "Employee")) return RedirectToAction("Index", "Employees");
                if (userManager.IsInRole(user.Id, "Customer")) return RedirectToAction("Index", "Customers");
            }
        }
        ModelState.AddModelError("", "Invalid login attempt.");
        return View(model);
    }

    [Authorize]
    public ActionResult Logout()
    {
        AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        return RedirectToAction("Login");
    }

    private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;
}
