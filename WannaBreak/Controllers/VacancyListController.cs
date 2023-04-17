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
            return View(await context.VacancyLists.ToListAsync());
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

            foreach (var employee in context.Employees)
            {
                if (employeeFirstname.ToLower() == employee.FirstName.ToLower() && employeeLastname.ToLower() == employee.LastName.ToLower())
                {
                        getId = employee.EmployeeID;
                        nameFound = true;
                        break;
                }
            }

            if (nameFound)
            {
                var vacancies = await context.VacancyLists
                                .Where(v => v.FK_EmployeeID == getId).ToListAsync();
                return View("searchNameResult", vacancies);
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
            var vacancies = await context.VacancyLists
                .Where(v => v.Start >= startDate && v.Stop <= stopDate).ToListAsync();

            return View("searchDateResult", vacancies);
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