using Employeemanage.Data;
using Employeemanage.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employeemanage.Controllers
{
    public class LoginController : Controller
    {
        private readonly EmployeemanageContext _context;
        private readonly IWebHostEnvironment _env;

        public LoginController(EmployeemanageContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Welcome()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult RegisterUser(Login L)
        {

            var file = Request.Form.Files["profile"];
            Console.WriteLine("==>" + file);
            string uniqueFileName = null;
            if (file != null)
            {
                string uploadsFolder = Path.Combine(_env.WebRootPath, "Images");
                uniqueFileName = Path.GetFileName(file.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }

            L.Role = "User";


            _context.Login.Add(L);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }


        public IActionResult LoginUser(Login login)
        {
            var user = _context.Login.FirstOrDefault(l => l.Email == login.Email);

            if (user != null)
            {
                if (user.Password == login.Password)
                {
                    if (user.Role == "Admin") 
                    {
                        return RedirectToAction("Welcomeadmin" , "Admin");
                    }
                    else if (user.Role == "User" && user.status == 1) 
                    {
                        return RedirectToAction("Welcome");
                    }
                    else
                    {
                        return RedirectToAction("Login");
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Invalid password.";
                    return RedirectToAction("Login");
                }
            }

            TempData["ErrorMessage"] = "User not found.";
            return RedirectToAction("Login");
        }
    }
 }
