using StateManagementHandling.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace StateManagementHandling.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public static List<EmpModel> empList;
        public EmployeeController()
        {
             empList = new List<EmpModel>() {
            new EmpModel() { Empid = 1, EmpName = "Sunita", Salary = 10000 },
            new EmpModel() { Empid = 2, EmpName = "Parag", Salary = 30000 },
            new EmpModel() { Empid = 3, EmpName = "Paresh", Salary = 20000 },
        };
        }

        public ActionResult Index()
        {
            return View(empList);
        }

        public ActionResult Select(int id)
        {
            EmpModel emp = empList.Find(eselect => eselect.Empid == id);
            if (emp != null)
            {
                Session["empid"] = emp.Empid;
                Session["empname"] = emp.EmpName;
                Session["empSalary"] = emp.Salary;
                return RedirectToAction("ShowEmpDetails");
            }
            return View("Error");
        }

        public ActionResult ShowEmpDetails()
        {
            ViewBag.empid = Session["empid"];
            ViewBag.empname = Session["empname"];
            ViewBag.sal = Session["empSalary"];

            return View();
        }

        public ActionResult ShowEmpList()
        {
            return View(empList);
        }
       

        public ActionResult ShowSelectedEmployee(int id)
        {
            EmpModel foundEmployeeWithID = empList.Find(emplist => emplist.Empid == id);
            return View(foundEmployeeWithID);
        }

    }
}