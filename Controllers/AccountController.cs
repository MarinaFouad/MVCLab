using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Lab4.Controllers
{
    public class AccountController : Controller
    {
          public async Task<IActionResult> Logout()
             {
             await HttpContext.SignOutAsync();
             return RedirectToAction("Index", "Home");
           }
           public IActionResult Login()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Login(string username, int roleType)
            {
                if (username == null || username.Length < 5)
                {
                    return View();
                }

                Claim claim1 = new Claim(ClaimTypes.Name, username);
                Claim claim2 = new Claim(ClaimTypes.Email, username + "@iti.com");
                Claim roleAdmin = new Claim(ClaimTypes.Role, "Admin");
                // Claim roleStudent = new Claim(ClaimTypes.Role, "student");
                 //Claim roleInstructor = new Claim(ClaimTypes.Role, "Instructor");
            ClaimsIdentity CI= new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                 CI.AddClaim(claim1);
               CI.AddClaim(claim2);

                if (roleType == 3)
                CI.AddClaim(roleAdmin);

                ClaimsPrincipal cP = new ClaimsPrincipal(CI);

                await HttpContext.SignInAsync(cP);

                return RedirectToAction("Index", "Home");
            }
           

     }
    

}

