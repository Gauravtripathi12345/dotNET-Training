using EmployeeManagementLibrary;
using System.Web.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly EmployeeDataAccess employeeDataAccess;

        public EmployeeController()
        {
            employeeDataAccess = new EmployeeDataAccess();
        }

        public ActionResult Index()
        {
            var employees = employeeDataAccess.GetAllEmployees();
            return View(employees);
        }

        public ActionResult InsertNewEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertNewEmployee(string name, string department)
        {
            var newEmployee = new Employee
            {
                Name = name,
                Department = department
            };
            employeeDataAccess.InsertEmployee(newEmployee);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var employee = employeeDataAccess.GetEmployeeById(id);
            if (employee == null)
            {
                return Content("Employee not found");
            }
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee editedEmployee)
        {
            employeeDataAccess.UpdateEmployee(editedEmployee);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var employee = employeeDataAccess.GetEmployeeById(id);
            if (employee == null)
            {
                return Content("Employee not found");
            }
            return View(employee);
        }

        public ActionResult Delete(int id)
        {
            var employee = employeeDataAccess.GetEmployeeById(id);
            if (employee == null)
            {
                return Content("Employee not found");
            }
            return View(employee);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            employeeDataAccess.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

    }

}
