using Microsoft.EntityFrameworkCore;
using WannaBreak.Models;

namespace WannaBreak.Data
{
    public class WannaBreakContext : DbContext
    {
        public WannaBreakContext(DbContextOptions<WannaBreakContext> options)
            : base(options) 
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
        
        public DbSet<VacancyType> VacancyTypes { get; set;}

        public DbSet<VacancyList> VacancyLists { get; set;}
            
        
    }
}
