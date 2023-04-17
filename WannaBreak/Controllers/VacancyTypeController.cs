using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WannaBreak.Data;

namespace WannaBreak.Controllers
{    
    public class VacancyTypeController : Controller
    {
        private readonly WannaBreakContext context;
        public VacancyTypeController(WannaBreakContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await context.VacancyTypes.ToListAsync());         
        }
    }
}
