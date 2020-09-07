using ChargeBackproject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Scrypt;

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
                            registerUserDetails.Password = encoder.Encode(registerUserDetails.Password);
                            databaseContext.UserDetail.Add(registerUserDetails);
                            databaseContext.SaveChanges();
                            userCredentials.UserName = registerUserDetails.UserId;
                            userCredentials.Password = encoder.Encode(registerUserDetails.Password); // encrpyting the password
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
                if (users == null)
                {
                    return null;
                }
                bool passwordMatching = encoder.Compare(loginDetails.Password, users.Password);
                if (passwordMatching)
                    return users;
                return null;
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
