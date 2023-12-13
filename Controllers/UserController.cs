using Authenecation_and_authoraization.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Authenecation_and_authoraization.Controllers
{
    public class UserController : Controller
    {
        // GET: User

        db dataContext = new db();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserRegistartion model)
        {
            try
            {
                UserRegistartion userRegist = new UserRegistartion();
                userRegist.Email = model.Email;
                userRegist.Name = model.Name;
                userRegist.Password = model.Password;
                userRegist.ConFirmPassword = model.ConFirmPassword;
                dataContext.RegistrationDetails.Add(userRegist);
                dataContext.SaveChanges();
                return RedirectToAction("Login");


            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationError in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationError.ValidationErrors)
                    {
                        // Log or handle the validation error
                        Console.WriteLine($"Entity: {entityValidationError.Entry.Entity.GetType().Name}, Property: {validationError.PropertyName}, Error: {validationError.ErrorMessage}");
                    }
                }
                // Optionally, rethrow the exception or handle it accordingly
                throw;
            }
           

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserRegistartion model)
        {
          
            UserRegistartion User = dataContext.RegistrationDetails.Where(a => (a.Email.Equals(model.Email) && a.Password.Equals(model.Password))).SingleOrDefault();
            //Response.Cookies["Email"].Value = model.Email.ToString();

            //HttpCookie hc1 = new HttpCookie("Email" , model.Email.ToString());
            //hc1.Expires = DateTime.Now.AddSeconds(10);


            Session["UserEmail"] = model.Email.ToString();

            if (User != null)
            {
                return RedirectToAction("UserDashboard");

            }
            else
            {
                ViewBag.title = "Login failed";
            }
            return View();
        }


        public ActionResult UserDashboard()
        {
            return View();
        }


        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}