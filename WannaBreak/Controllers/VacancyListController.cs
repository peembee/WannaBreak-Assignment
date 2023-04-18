using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Controller;
using WannaBreak.Data;
using Microsoft.Extensions.Logging;
using WannaBreak.Models;
using System.Data;
using Microsoft.CodeAnalysis.Elfie.Extensions;

namespace WannaBreak.Controllers
{
    public class VacancyListController : Controller
    {
        private readonly WannaBreakContext context;

        public VacancyListController(WannaBreakContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            var newVacancyList = await context.VacancyLists.ToListAsync();
                                

            foreach (var vacancyList in newVacancyList)    // creates list, changing foreign and primary keys to their name insted of key-number
            {
                var employee = await context.Employees
                    .FirstOrDefaultAsync(e => e.EmployeeID == vacancyList.FK_EmployeeID);
                if(employee != null)
                {
                    vacancyList.EmployeeFullName = employee.FirstName + " " + employee.LastName;
                    
                }

                var types = await context.VacancyTypes
                    .FirstOrDefaultAsync(t => t.VacancyTypeID == vacancyList.FK_VacancyTypeID);

                if (types != null)
                {
                    vacancyList.VacancyNameTitel = types.VacancyTitel;

                }
            }                 
            return View(newVacancyList);
        }

        // Navigation in VacancyListStartPage
        public async Task<IActionResult> SearchName()
        {
            return View();
        }

        public async Task<IActionResult> GetSearchNameInput(string employeeFirstname, string employeeLastname)
        {
            bool nameFound = false;
            int getId = 0;

            employeeFirstname = employeeFirstname.Trim();
            employeeLastname = employeeLastname.Trim();

            var newEmployeeList = await context.Employees.ToListAsync();

            foreach (var employee in newEmployeeList)
            {
                if (employeeFirstname.ToLower() == employee.FirstName.ToLower() && employeeLastname.ToLower() == employee.LastName.ToLower())
                {
                        getId = employee.EmployeeID;
                        nameFound = true;
                        break;
                }
            }

            if (nameFound) // changing fk-int key to matching vacancytypes-names
            {
                var newVacancyList = await context.VacancyLists.ToListAsync();

                foreach (var vacancyList in newVacancyList)
                {
                    var vacancyTypes = await context.VacancyTypes
                        .FirstOrDefaultAsync(v => v.VacancyTypeID == vacancyList.FK_VacancyTypeID);

                    if(vacancyTypes != null)
                    {
                        vacancyList.VacancyNameTitel = vacancyTypes.VacancyTitel;
                    }
                }

                return View("searchNameResult", newVacancyList);
            }
            else
            {
                return View("NoMatch");
            }
        }

        // Navigation in VacancyListStartPage - Index
        public async Task<IActionResult> DateSearch()
        {
            return View();
        }

        //GetSearchDateInput
        public async Task<IActionResult> GetSearchDateInput(DateTime startDate, DateTime stopDate)
        {
            var newVacancyList = await context.VacancyLists.ToListAsync();


            foreach (var vacancyList in newVacancyList)
            {
                var vacancyTypes = await context.VacancyTypes
                    .FirstOrDefaultAsync(v => v.VacancyTypeID == vacancyList.FK_VacancyTypeID);        

                if (vacancyTypes != null )
                {
                    vacancyList.VacancyNameTitel = vacancyTypes.VacancyTitel;
                }

                
                var employee = await context.Employees
                    
                    .FirstOrDefaultAsync(e => e.EmployeeID == vacancyList.FK_EmployeeID);
                if (employee != null)
                {
                    vacancyList.EmployeeFullName = employee.FirstName + " " + employee.LastName;
                }
            }

            return View("searchDateResult", newVacancyList);
        }

        public async Task<IActionResult> AddVacancy()
        {
                return View();
        }

        //POST
        public async Task<IActionResult> AddVacancyListToDB(int fkEmployeeId, string fkVacancyType, DateTime start, DateTime stop)
        {
            int vacancyType = 1;

            foreach (var item in context.VacancyTypes)
            {
                if(item.VacancyTitel.ToLower() == fkVacancyType.ToLower())
                {
                    vacancyType = item.VacancyTypeID;
                    break;
                }
            }

            VacancyList vacancyList = new VacancyList()
            {
                FK_EmployeeID = fkEmployeeId,
                FK_VacancyTypeID = vacancyType,
                Start = start,
                Stop = stop,
                RegisteredDate = DateTime.Now
            };
            context.VacancyLists.Add(vacancyList);
            context.SaveChanges();

            return View();
        }
    }
}