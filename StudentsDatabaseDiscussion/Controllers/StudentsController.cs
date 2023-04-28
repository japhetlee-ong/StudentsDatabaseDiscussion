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

        [HttpPost]
        public ActionResult DeleteStudent(int studentId)
        {
            using (StudentDBEntities entities = new StudentDBEntities())
            {
                var student = entities.TBL_STUDENTS.Where(x => x.ID == studentId).FirstOrDefault();

                if (student == null) {
                    return Json(new { msg = "Student not found." });
                }

                entities.TBL_STUDENTS.Remove(student);

                if(entities.SaveChanges() >= 1)
                {
                    return Json(new { msg = "Student removed from database" });
                }
                else
                {
                    return Json(new { msg = "An error occurred" });
                }

            }
        }

        [HttpPost]
        public ActionResult UpdateStudent(int studentId, string studentName, string studentAddress, string studentIdNumber, int studentYearLevel, string studentContactNumber , bool isActive)
        {
            using (StudentDBEntities entities = new StudentDBEntities())
            {
                var student = entities.TBL_STUDENTS.Where(x => x.ID == studentId).FirstOrDefault();

                if (student == null) {
                    return Json(new { msg = "Student not found" });
                }

                student.STUDENT_NAME = studentName;
                student.STUDENT_ADDRESS = studentAddress;
                student.STUDENT_NUMBER = studentIdNumber;
                student.STATUS = isActive;
                student.STUDENT_YEAR_LEVEL= studentYearLevel;
                student.STUDENT_CONTACT_NUMBER = studentContactNumber;

                
                if(entities.SaveChanges() >= 1)
                {
                    return Json(new { msg = "Modified student details" });
                }
                else
                {
                    return Json(new { msg = "An error occurred" });
                }

            }
        }



    }
}