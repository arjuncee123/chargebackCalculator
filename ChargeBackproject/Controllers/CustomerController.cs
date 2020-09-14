using ChargeBackproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace ChargeBackproject.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        public static int custId;
        private UserDetailsContext databaseContext = new UserDetailsContext();
        // GET: Customer
        public ActionResult Index()
        {
            var customerDetails = databaseContext.CustomerDetails.Where(i => i.UserId == User.Identity.Name).FirstOrDefault();
            custId = customerDetails.CustomerId;
            var listOfTransactions = databaseContext.TransactionDetails.Where(i => i.CustomerId == customerDetails.CustomerId).ToList();
            return View(listOfTransactions);
        }

        public ActionResult RegisterComplaint()
        {
            ViewBag.custId = custId;
            return View();
        }

        [HttpPost]
        public ActionResult RegisterComplaint(ComplaintDetail complaintDetail)
        {
            if(ModelState.IsValid)
            {
                databaseContext.ComplaintDetails.Add(complaintDetail);
                databaseContext.SaveChanges();
                ModelState.Clear();
                ViewBag.Message = "Complaint lodged successfully";
                return View("RegisterComplaint");
            }
            else
            {
                return View("RegisterComplaint", complaintDetail);
            }
        }
    }
}