using Microsoft.AspNetCore.Mvc;
using WannaBreak.Data;

namespace WannaBreak.Controllers
{
    public class AdminController : Controller
    {
        private readonly WannaBreakContext context;
        public AdminController(WannaBreakContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public IActionResult loggedIn(string employeeId, string employeePassword)
        {           
                bool admin = false;
                foreach (var employee in context.Employees)
                {
                    if(employee.EmployeeID.ToString() == employeeId && employee.Password == employeePassword)
                    {
                        if(employee.Role == "Admin" || employee.Role == "Chef")
                        admin = true;
                    }
                }
                if(admin)
                {
                    return View();
                }
                else
                {
                    return View("AccessDenied");
                }            
        }        
    }
}
