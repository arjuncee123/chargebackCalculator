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
        Random _random = new Random();
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
            ViewBag.userrole = RoleSelectionFromUser;
            return View();
        }
        public int RandomIdGenerator(int min,int max)
        {
            return _random.Next(min, max);
        }

        public string RandomStringGenerator(int c,string s)
        {
            string random = "";
            for(int i=0; i<c;i++)
            {
                int a = _random.Next(26);
                random = random + s.ElementAt(a);
            }
            return random;
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
                            CustomerDetail customerDetails = new CustomerDetail();
                            var originalPassword = registerUserDetails.Password;
                            registerUserDetails.Password = encoder.Encode(originalPassword);
                            registerUserDetails.ConfirmPassword = registerUserDetails.Password;
                            if (registerUserDetails.UserCategory == "Customer")
                            {
                                customerDetails.FirstName = registerUserDetails.FirstName;
                                customerDetails.LastName = registerUserDetails.LastName;
                                customerDetails.DateOfBirth = registerUserDetails.DateOfBirth;
                                customerDetails.Gender = registerUserDetails.Gender;
                                customerDetails.ContactNumber = registerUserDetails.ContactNumber;
                                customerDetails.Address = registerUserDetails.Address;
                                customerDetails.City = registerUserDetails.City;
                                customerDetails.State = registerUserDetails.State;
                                customerDetails.ZipCode = registerUserDetails.ZipCode;
                                customerDetails.UserId = registerUserDetails.UserId;
                                customerDetails.Password = registerUserDetails.Password;
                                customerDetails.CustomerId = RandomIdGenerator(1000, 2000);                             //generating a number between 1000 & 2000
                                customerDetails.BankAccountNumber = RandomIdGenerator(1000000000, 1999999999);          //generating a number between 1000000000 && 1999999999 for account number
                                customerDetails.BankAddress = RandomStringGenerator(10, "abcdefghijklmnopqrstuvwxyz");  //generating a string of length 10 for Bank address
                                customerDetails.AvailableBalance = RandomIdGenerator(10000, 50000);                     //generating a number between 10000 & 50000 for Account balance
                                customerDetails.BranchName = RandomStringGenerator(5, "abcdefghijklmnopqrstuvwxyz");    //generating a string of length 5 for Branch name
                                databaseContext.CustomerDetails.Add(customerDetails);
                                databaseContext.SaveChanges();
                            }
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
                    
                    switch (RoleSelectionFromUser)
                    {
                        case "Customer":
                            ViewBag.Message = "Customer user logged in successfully";
                            return RedirectToAction("Index", "Customer");
                        case "Employee":
                            ViewBag.Message = "Employee user logged in successfully";
                            return RedirectToAction("Index", "Employee");
                        case "Admin":
                            ViewBag.Message = "Admin user logged in successfully";
                            return RedirectToAction("Index", "Admin");
                    }

                    return View();
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
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
            return RedirectToAction("Login");
        }
    }
}
