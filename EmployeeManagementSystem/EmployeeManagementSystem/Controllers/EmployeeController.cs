using EmployeeManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private static List<EmployeeModel> empList;

        static EmployeeController()
        {
            // Initialize empList with default values
            empList = new List<EmployeeModel>();

            empList.Add(new EmployeeModel() { Id = 1, Name = "Sunita", Department = "Accounts" });
            empList.Add(new EmployeeModel() { Id = 2, Name = "Parag", Department = "HR" });
            empList.Add(new EmployeeModel() { Id = 2, Name = "Paresh", Department = "Sales" });

        }

        // GET: Employee
        public ActionResult Index()
        {
            // Retrieve empList from session
            List<EmployeeModel> empListFromSession = Session["empList"] as List<EmployeeModel>;
            if (empListFromSession != null)
            {
                empList = empListFromSession;
            }

            return View(empList);
        }

        public ActionResult InsertNewEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertNewEmployee(string name, string department)
        {
            // Create a new employee
            EmployeeModel newEmployee = new EmployeeModel
            {
                Id = empList.Count + 1,
                Name = name,
                Department = department
            };

            empList.Add(newEmployee);

            Session["empList"] = empList;

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            EmployeeModel employeeToEdit = empList.Find(emp => emp.Id == id);
            if (employeeToEdit == null)
            {
                return Content("Employee not found");
            }

            return View(employeeToEdit);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeModel editedEmployee)
        {
            EmployeeModel employeeToEdit = empList.Find(emp => emp.Id == editedEmployee.Id);

            if (employeeToEdit != null)
            {
                employeeToEdit.Name = editedEmployee.Name;
                employeeToEdit.Department = editedEmployee.Department;

                Session["empList"] = empList;
            }

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            EmployeeModel employeeDetailsToDisplay = empList.Find(emp => emp.Id == id);

            if (employeeDetailsToDisplay == null)
            {
                return Content("Employee details not found");
            }

            return View(employeeDetailsToDisplay);
        }

        public ActionResult Delete(int id)
        {
            EmployeeModel employeeToDelete = empList.Find(emp => emp.Id == id);

            if (employeeToDelete == null)
            {
                return Content("No employee found");
            }

            return View(employeeToDelete);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeModel employeeToDelete = empList.Find(e => e.Id == id);
            if (employeeToDelete != null)
            {
                empList.Remove(employeeToDelete);

                // Updating ID of existing employees
                for (int i = 0; i < empList.Count; i++)
                {
                    empList[i].Id = i + 1;
                }

                Session["empList"] = empList;
            }

            return RedirectToAction("Index");
        }

    }

}
