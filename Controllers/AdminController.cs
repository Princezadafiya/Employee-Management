using Employeemanage.Data;
using Employeemanage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employeemanage.Controllers
{
    public class AdminController : Controller
    {
        private readonly EmployeemanageContext _context;

        public AdminController(EmployeemanageContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Welcomeadmin()
        {
            return View();
        }

        public IActionResult Viewregistration()
        {
            var data = _context.Login.Where(item => item.status == 0).ToList();

            return View(data);
        }

        public IActionResult Empolyee()
        {
            var data = _context.Login.Where(u => u.status == 1).ToList();

            return View(data);

        }

        public IActionResult Adddata(int id)
        {
            var user = _context.Login.FirstOrDefault(u => u.EmployeeId == id);
            if (user == null)
            {
                return NotFound(); 
            }
            return View(user);

        }


        [HttpPost]
        public IActionResult SaveUser(Admin a)
        {
            Console.WriteLine($"Received EmployeeId from form: {a.EmployeeId}");
                      
            var user = _context.Admin.FirstOrDefault(u => u.EmployeeId == a.EmployeeId);

            if (user == null)
            {
                user = new Admin
                {
                    EmployeeId = a.EmployeeId,
                    Salary = a.Salary,
                    Department = a.Department
                };

                _context.Admin.Add(user);
            }
            else
            {
                user.Salary = a.Salary;
                user.Department = a.Department;
                _context.Entry(user).State = EntityState.Modified; 
            }

            _context.SaveChanges();
            Console.WriteLine($"Data saved successfully for EmployeeId: {a.EmployeeId}");

            return RedirectToAction("Empolyee");
        }


        public IActionResult Report()
        {
            var employees = _context.Admin
                .Include(e => e.Login) 
                .Select(e => new
                {
                    e.Id,
                    e.EmployeeId,
                    e.Salary,
                    e.Department,
                    e.Login.FirstName,
                    e.Login.LastName,
                    e.Login.Email,
                    e.Login.PhoneNumber,
                })
                .ToList();

            return View(employees);
        }

        [HttpPost]
        public IActionResult Acceptreg(int id)
        {
            var user = _context.Login.FirstOrDefault(u => u.EmployeeId == id);
            if (user != null)
            {
                user.status = 1; 
                _context.SaveChanges();
            }

            return RedirectToAction("Viewregistration");
        }
    }
}
