using AsistLabProject.Models;
using AsistLabProject.Models.Data;
using AsistLabProject.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AsistLabProject.Controllers
{
    public class AccountController : Controller
    {

        private readonly IUser user;

        public AccountController(IUser user)
        {
            this.user = user;
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(UserRegister userModel)
        {
            if (ModelState.IsValid)
            {
                var userRegister = user.GetUsers().FirstOrDefault(u => u.Name == userModel.Name && u.Name == userModel.Password);
                if(userRegister == null)
                {
                    userRegister = new User
                    {
                        Email = userModel.Email,
                        Name = userModel.Name,
                        Password = userModel.Password
                    };
                    user.Insert(userRegister);
                    user.Save();
                    await Authenticate(userRegister);
                    return RedirectToAction("Posts", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "The data is probably filled incorrectly!");
                }
            }
            return View(userModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLogin userModel)
        {
            if (ModelState.IsValid)
            {
                var userLogin = user.GetUsers().FirstOrDefault(u => u.Name == userModel.Name && u.Name == userModel.Password);
                if(userLogin != null)
                {
                    userLogin = new User()
                    {
                        Name = userModel.Name,
                        Password = userModel.Password
                    };
                    await Authenticate(userLogin);
                    return RedirectToAction("Posts", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Probably your login or password is invalid!");
                }
            }
            return View(userModel);
        }

        //public IActionResult Crypt(string password)
        //{
        //    Encoding.
        //    return View();
        //}

        //public IActionResult Decrypt(string password)
        //{
        //    return View();
        //}

        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
