using Lab4.Models;
using Lab4.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Lab4.Controllers
{
    
    public class DepartmentController : Controller
    {
       // StudentRepo StudentRepo = new StudentRepo();
        IDepartmentRepo DepartmentRepo ;

        public DepartmentController(IDepartmentRepo _departmentRepo)
        {
            DepartmentRepo = _departmentRepo;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var model = DepartmentRepo.GetAll();
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Department department)
        {
            DepartmentRepo.Add(department);
            return RedirectToAction("Index");
            
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var model = DepartmentRepo.GetById(id.Value);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Department department)
        {
            var oldDept = DepartmentRepo.GetById(department.Id);    
            if (oldDept == null)
            {
                return NotFound();
            }

            DepartmentRepo.Update(department);
            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var model = DepartmentRepo.GetById(id.Value);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }
        [Authorize]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var model = DepartmentRepo.GetById(id.Value);
            if (model == null)
            {
                return NotFound();
            }
            DepartmentRepo.Delete(id.Value);
            return RedirectToAction("Index");
        }
    }
}
