using Microsoft.AspNetCore.Mvc;
using MVCDemoCore.Models;

namespace MVCDemoCore.Controllers
{
    public class EmployeeController : Controller
    {
        // POST: Guest/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            Employee? deleteEmploy = null;
            try
            {
                deleteEmploy = new Employee();
                deleteEmploy.Name = collection["Name"];
                deleteEmploy.Basic = Convert.ToInt32(collection["Basic"]);

                var service = new EmployeeService();
                service.DeleteEmploy(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(deleteEmploy);
            }
        }

        [HttpPost]
        public ActionResult Create(Employee newEmploy)
        {
            if (ModelState.IsValid)
            {
                var employService = new EmployeeService();
                employService.AddEmploy(newEmploy);

                return RedirectToAction("Index");
            }
            else
            {
                return View(newEmploy);
            }
        }

        // POST: Guest/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            Employee? updateEmploy = null;
            try
            {
                updateEmploy = new Employee();
                updateEmploy.Empno = id;
                updateEmploy.Name = collection["Name"];
                updateEmploy.Basic = Convert.ToInt32(collection["Basic"]);
                var employService = new EmployeeService();
                employService.UpdateEmploy(updateEmploy);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(updateEmploy);
            }
        }
        public IActionResult Create()
        {
            return View(new Employee());
        }

        public IActionResult Edit(int id)
        {
            var service = new EmployeeService();
            Employee employ = service.ShowEmploy(id);
            return View(employ);

        }
        public IActionResult Delete(int id)
        {
            var service = new EmployeeService();
            Employee employ = service.ShowEmploy(id);
            return View(employ);
        }
        public IActionResult Search(int id)
        {
            var employService = new EmployeeService();
            Employee employ = employService.ShowEmploy(id);
            return View(employ);
        }
        public IActionResult Index()
        {
            var employService = new EmployeeService();
            List<Employee> employs = employService.GetAllEmploys();
            ViewData["employs"] = employs;
            ViewBag.employs = employs;
            return View(employs);
        }
    }
}