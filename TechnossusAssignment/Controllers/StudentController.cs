using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnossusAssignment.Models;

namespace TechnossusAssignment.Controllers
{
    public class StudentController : Controller
    {
        private readonly IConfiguration configuration;
        private StudentCrud crud;
        public StudentController(IConfiguration configuration)
        {
            this.configuration = configuration;
            crud = new StudentCrud(this.configuration);
        }
        // GET: StudentController
        public ActionResult StudentList(string searchString, DateTime? registrationDate)
        {
            return View(crud.GetAllStudents(searchString, registrationDate));
        }        

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View(crud.GetStudentById(id));
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            try
            {
                int result = crud.AddStudent(student);
                if (result == 1)
                    return RedirectToAction(nameof(StudentList));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(crud.GetStudentById(id));
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            try
            {
                int result = crud.UpdateStudent(student);
                if (result == 1)
                    return RedirectToAction(nameof(StudentList));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(crud.GetStudentById(id));
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            try
            {
                int result = crud.DeleteStudent(id);
                if (result == 1)
                    return RedirectToAction(nameof(StudentList));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
