using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChargeBackproject.Models;

namespace ChargeBackproject.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        // GET: Employee
        private UserDetailsContext databaseContext = new UserDetailsContext();
        public ActionResult Index()
        {
            var listOfUsers = databaseContext.CustomerDetails.ToList();  
            return View(listOfUsers);
        }

        [HttpPost]
        public ActionResult Index(string searchText)
        {
            var users = databaseContext.CustomerDetails.ToList();
            if (searchText != null)
            {
                users = databaseContext.CustomerDetails.Where(x => x.CustomerId.ToString().Contains(searchText)).ToList();
            }
            return View(users);
        }

        public ActionResult AllChargeback()
        {
            var allChargebackDetails = databaseContext.ComplaintDetails.ToList();
            return View(allChargebackDetails);
        }
        public ActionResult Detail(int id)
        {
            var users = databaseContext.CustomerDetails.Where(i => i.CustomerId == id).First();
            return View(users);
        }

        public ActionResult Transactions(int id)
        {
            var users = databaseContext.TransactionDetails.Where(i => i.CustomerId == id).ToList();
            return View(users);
        }

        public ActionResult ChargeBack(int id)
        {
            var chargeBackDetails = databaseContext.ComplaintDetails.Where(i => i.CustomerId == id).ToList();
                return View(chargeBackDetails);
        }
    }
}