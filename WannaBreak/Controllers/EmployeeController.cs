using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using WannaBreak.Data;
using WannaBreak.Models;

namespace WannaBreak.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly WannaBreakContext context;
        public EmployeeController(WannaBreakContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
           // display navigation to DisplayEmployees and AddEmployee in "Index-View
            return View();
        }

        public async Task<IActionResult> DisplayEmployees()
        {
            return View(await context.Employees.ToListAsync());
        }

        public async Task<IActionResult> AddEmployee()
        {
            return View(await context.Employees.ToListAsync());
        }

        public async Task<IActionResult> AddNewEmployeeToDB(string firstname, string lastname, string phone, string email, string role, string password)
        {
            firstname = firstname.Trim();
            lastname = lastname.Trim(); 
            phone = phone.Trim();
            email = email.Trim();
            role = role.Trim();
            password = password.Trim();

            Employee employee = new Employee()
            {
                FirstName = firstname = char.ToUpper(firstname[0]) + firstname.Substring(1),
                LastName = lastname = char.ToUpper(lastname[0]) + lastname.Substring(1),
                Phone = phone,
                Email = email,
                Role = role,
                Password = password
            };         
                   
                context.Employees.Add(employee);
                context.SaveChanges();
                return View("AddEmployeeResult");            
        }     
    }
}
