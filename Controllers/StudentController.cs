using Lab4.Models;
using Lab4.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.Controllers
{
    public class StudentController : Controller
    {
        IStudentRepo StudentRepo;
        IDepartmentRepo DepartmentRepo;
        private object Modelstate;

       public StudentController (IDepartmentRepo _departmentRepo, IStudentRepo _studentRepo )
        {
            DepartmentRepo = _departmentRepo;
            StudentRepo = _studentRepo;
        }
        [Authorize]
        public IActionResult Index()
        {
            var model = StudentRepo.GetAll();
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            ViewBag.Departments = DepartmentRepo.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Add(Student student)
        {
            var Department = DepartmentRepo.GetById(student.Id);
           
            
                if (ModelState.IsValid)
                {
                    StudentRepo.Add(student);
                    return RedirectToAction("Index");
                }
                
            else
            {
                ModelState.AddModelError("", "Check");
                ViewBag.Departments = DepartmentRepo.GetAll();
                return View(student);

            }

        }
        
        public IActionResult Details(int id)
        {
            var model = StudentRepo.GetById(id);
            return View(model);
        }
        [Authorize]
        public IActionResult Delete(int? id)
        {
             if (id == null)
            {
                return BadRequest();
            }
            var model = StudentRepo.GetById(id.Value);
            if (model == null)
            {
                return NotFound();
            }
            StudentRepo.Delete(id.Value);
            return RedirectToAction("index");
        }
        [Authorize]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var model = StudentRepo.GetById(id.Value);
            if (model == null)
            {
                return NotFound();
            }
            ViewBag.Department = DepartmentRepo.GetAll();
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            
            StudentRepo.Update(student);
            return RedirectToAction("Index");
        }
    }
}
