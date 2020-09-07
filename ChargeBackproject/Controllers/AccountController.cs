using ChargeBackproject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ChargeBackproject.Controllers
{
    public class AccountController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveRegisteration(UserDetails registerUserDetails)
        {
            if (ModelState.IsValid)
            {
                    using (var databaseContext = new UserDetailsContext())
                    {
                        databaseContext.UserDetail.Add(registerUserDetails);
                        databaseContext.SaveChanges();
                    }
                    ModelState.Clear();
                    ViewBag.Message = "New User created successfully";
                    return View("Login");
            }
            else
            {
                return View("Register", registerUserDetails);
            }
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginDetails loginDetails)
        {
            if (ModelState.IsValid)
            {
                var isValidUser = IsValidUser(loginDetails);
                if (isValidUser != null)
                {
                    FormsAuthentication.SetAuthCookie(loginDetails.UserName, false);
                    ViewBag.Message = "User logged in successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Failure", "Username or password is incorrect.");
                    return View();
                }
            }
            else
            {
                return View(loginDetails);
            }
        }

        public UserDetails IsValidUser(LoginDetails loginDetails)
        {
            using (var databaseContext = new UserDetailsContext())
            {
                UserDetails users = databaseContext.UserDetail.Where(i => i.UserId.Equals(loginDetails.UserName) && i.Password.Equals(loginDetails.Password)).SingleOrDefault();
                if (users == null)
                {
                    return null;
                }
                else
                    return users;
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}
