using ChargeBackproject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Scrypt;
using static System.String;

namespace ChargeBackproject.Controllers
{
    public class AccountController : Controller
    {
        // GET: Register
        public static string RoleSelectionFromUser;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RoleChoice()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RoleChoice(string roleName)
        {
            Role selectedRole = new Role();
            if (roleName != null)
            {
                selectedRole.RoleName = roleName;
                RoleSelectionFromUser = roleName;
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.Message = "Please select a Role to Continue";
                return View();
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserDetails registerUserDetails)
        {
            ScryptEncoder encoder = new ScryptEncoder();
            if (ModelState.IsValid)
            {
                    
                    using (var databaseContext = new UserDetailsContext())
                    {
                        var isUserExists = databaseContext.UserDetail.FirstOrDefault(i => i.UserId == registerUserDetails.UserId);
                        if (isUserExists == null)
                        {
                            LoginDetails userCredentials = new LoginDetails();
                            var originalPassword = registerUserDetails.Password;
                            registerUserDetails.UserCategory = RoleSelectionFromUser;
                            registerUserDetails.Password = encoder.Encode(originalPassword);
                            registerUserDetails.ConfirmPassword = registerUserDetails.Password;
                            databaseContext.UserDetail.Add(registerUserDetails);
                            databaseContext.SaveChanges();
                            userCredentials.RoleOfUser = RoleSelectionFromUser;
                            userCredentials.UserName = registerUserDetails.UserId;
                            userCredentials.Password = encoder.Encode(originalPassword);
                            databaseContext.LoginDetail.Add(userCredentials);
                            databaseContext.SaveChanges();
                        }
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
                    ViewBag.Message = "Username or password is incorrect";
                    return View();
                }
            }
            else
            {
                return View(loginDetails);
            }
        }

        public LoginDetails IsValidUser(LoginDetails loginDetails)
        {
            ScryptEncoder encoder = new ScryptEncoder();
            using (var databaseContext = new UserDetailsContext())
            {
                var users = (from i in databaseContext.LoginDetail
                    where i.UserName.Equals(loginDetails.UserName)
                    select i).SingleOrDefault();
                var a = RoleSelectionFromUser;
                if (users == null)
                {
                    return null;
                }
                bool passwordMatching = encoder.Compare(loginDetails.Password, users.Password);
                bool isSelectedRoleValid = String.Compare(users.RoleOfUser, RoleSelectionFromUser) == 0;
                if (passwordMatching && isSelectedRoleValid)
                    return users;
                return null;
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            this.Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            this.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            this.Response.Cache.SetNoStore();
            return RedirectToAction("Login");
        }
    }
}
