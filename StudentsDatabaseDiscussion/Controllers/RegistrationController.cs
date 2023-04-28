using StudentsDatabaseDiscussion.Helpers;
using StudentsDatabaseDiscussion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentsDatabaseDiscussion.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(RegistrationModel _registration)
        {
            if (ModelState.IsValid)
            {
                using (StudentDBEntities entities = new StudentDBEntities())
                {

                    var adminData = entities.TBL_ADMINS.Where(x => x.USERNAME == _registration.Username).FirstOrDefault();

                    if (adminData != null)
                    {
                        ViewBag.RegistrationError = "Username already taken";
                        return View(_registration);
                    }

                    var ePassword = Encryption.Encrypt(_registration.UserPassword);

                    var nAdmin = new TBL_ADMINS()
                    {
                        USERNAME = _registration.Username,
                        NAME = _registration.Name,
                        EMAIL = _registration.Email,
                        PASSWORD = ePassword,
                        DATE_CREATED = DateTime.Now,
                        IS_ACTIVE = true
                    };

                    entities.TBL_ADMINS.Add(nAdmin);

                    if (entities.SaveChanges() >= 1)
                    {
                        ViewBag.RegistrationSuccess = "Admin has been registered";
                        return View();
                    }


                }
                return View();
            }

            return View(_registration);
        }

    }
}