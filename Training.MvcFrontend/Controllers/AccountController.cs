using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Training.MvcFrontend.Models;

namespace Training.MvcFrontend.Controllers
{
    public class AccountController : AsyncController
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser, string> singInManager; // Microsoft.Aspnet.Identity.Owin nugetpcg a SignInManagerhez
        public AccountController(UserManager<IdentityUser> userManager,
                                SignInManager<IdentityUser, string> singInManager)
        {
            this.userManager = userManager;
            this.singInManager = singInManager;
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterUserViewModel registerUserViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerUserViewModel);
            }
            IdentityUser user = new IdentityUser
            {
                Email = registerUserViewModel.Email,
                UserName = registerUserViewModel.UserName,
                EmailConfirmed = true
            };
            var result = userManager.Create(user, registerUserViewModel.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
                return View(registerUserViewModel);

            }
            return RedirectToAction("Login");
        }


        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            var user = userManager.Find(loginViewModel.UserName, loginViewModel.Password);
            if (user ==null)
            {
                ModelState.AddModelError("", "Invalid username or passowrd");
                return View(loginViewModel);
            }
            var result =
                singInManager.PasswordSignIn(loginViewModel.UserName, loginViewModel.Password, false, false);

            if (result == SignInStatus.Success)
            {
                if (!string.IsNullOrWhiteSpace(returnUrl))
                    return Redirect(returnUrl);
                else
                    return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt");
                ViewBag.ReturnUrl = returnUrl;
                return View(loginViewModel);
            }
            #region swithcaseSolution
            //switch (result)
            //{
            //    case SignInStatus.Success:
            //        if (!string.IsNullOrWhiteSpace(returnUrl))
            //        {
            //            Redirect(returnUrl);
            //        }
            //        else
            //            return RedirectToAction("Index", "Home");
            //        break;
            //    case SignInStatus.LockedOut:
            //        break;
            //    case SignInStatus.RequiresVerification:
            //        break;
            //    case SignInStatus.Failure:
            //        break;
            //    default:
            //        ModelState.AddModelError("", "Invalid login attempt");
            //        ViewBag.ReturnUrl = returnUrl;
            //        return View(loginViewModel);
            //        break;
            //}
            #endregion
        }

        [Authorize]
        public ActionResult Logout()
        {
            HttpContext.GetOwinContext().Authentication
                       .SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction(nameof(Login));
        }
    }
}