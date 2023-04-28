using StudentsDatabaseDiscussion.Helpers;
using StudentsDatabaseDiscussion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace StudentsDatabaseDiscussion.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel loginModel)
        {
            using (StudentDBEntities entities = new StudentDBEntities())
            {
                var ePassword = Encryption.Encrypt(loginModel.Password);

                var userData = entities.TBL_ADMINS.Where(x=> x.USERNAME.Equals(loginModel.Username) && x.PASSWORD == ePassword).FirstOrDefault();

                if(userData == null) 
                {
                    ViewBag.ErrorMessage = "Invalid username/password.";
                    return View();
                }

                ViewBag.SuccessLogin = "Welcome user: " + userData.NAME;
                return View();

            }
        }

    }
}