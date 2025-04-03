using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebMVCDao.Dao;
using WebMVCDao.Models;

namespace WebMVCDao.Controllers
{
    public class StudentController : Controller
    {
        private IStudentDao studentDao;

        public StudentController(IStudentDao studentDao)
        {
            this.studentDao = studentDao;
        }
        // GET: StudentController
        public ActionResult Index()
        {
            return View(studentDao.GetStudents());
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View(studentDao.GetStudentById(id));
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            ViewBag.SaveOp = "Create";
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            ViewBag.SaveOp = "Create";
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Модель данных не валидна!");
                }
                studentDao.Add(student);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(student);
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.SaveOp = "Edit";
            return View("Create",studentDao.GetStudentById(id));
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student student)
        {
            ViewBag.SaveOp = "Edit";
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Модель данных не валидна!");
                }
                student.Id = id;
                studentDao.Update(student);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        [ActionName("Delete")]
        public ActionResult ShowDelete(int id)
        {
            return View(studentDao.GetStudentById(id));
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                studentDao.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(studentDao.GetStudentById(id));
            }
        }
    }
}
