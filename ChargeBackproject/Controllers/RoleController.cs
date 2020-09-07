using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChargeBackproject.Models;

namespace ChargeBackproject.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SelectRole(UserRoles role)
        {
            return View();
        }
    } 
}