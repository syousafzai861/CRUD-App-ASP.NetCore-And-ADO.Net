using ADOCRUDApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ADOCRUDApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmployeeDataAccessLayer employee;

        public HomeController()
        {
            employee = new EmployeeDataAccessLayer();
        }

        public IActionResult Index()
        {
            List<Employees> emplist = employee.GetAllEmployess();
            return View(emplist);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employees employees)
        {
            try
            {
                employee.AddEmployee(employees);
                return RedirectToAction("Index");
            }
            catch (Exception ex) {

                return View();

            }
        }

        public IActionResult Edit(int id)
        {
            Employees emp = employee.GetEmployeeByID(id);
            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employees employees)
        {
            try
            {
                employee.UpdateEmployee(employees);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return View();

            }
        }

        public IActionResult Details(int id)
        {
            Employees emp = employee.GetEmployeeByID(id);
            return View(emp);
        }

        public IActionResult Delete(int id)
        {
            Employees emp = employee.GetEmployeeByID(id);
            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Employees employees)
        {
            try
            {
                employee.DeleteEmployee(employees.Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return View();

            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}