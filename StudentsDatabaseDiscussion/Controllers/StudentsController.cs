using StudentsDatabaseDiscussion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentsDatabaseDiscussion.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        public ActionResult Index()
        {
            using (StudentDBEntities entities = new StudentDBEntities())
            {
                var data = entities.TBL_STUDENTS.ToList();

                var studentModel = new StudentsModel()
                {
                    Students = data,
                    Student = new TBL_STUDENTS()
                };

                if (TempData["ErrorMessage"] != null)
                {
                    ViewBag.AddStudentFail = TempData["ErrorMessage"].ToString();
                }

                if (TempData["SuccessMessage"] != null)
                {
                    ViewBag.AddStudentSuccess = TempData["SuccessMessage"].ToString();
                }

                return View(studentModel);
            }
;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(TBL_STUDENTS _STUDENTS)
        {
            using (StudentDBEntities entities = new StudentDBEntities())
            {
                _STUDENTS.STATUS = true;

                entities.TBL_STUDENTS.Add(_STUDENTS);
                
                if(entities.SaveChanges() >= 1)
                {
                    //SUCCESS
                    TempData["SuccessMessage"] = "Successfully added the student to the database.";
                    return RedirectToAction("Index");
                }
                else
                {
                    //FAIL
                    TempData["ErrorMessage"] = "Error in creating student data";
                    return RedirectToAction("Index");

                }

            }
        }
    }
}