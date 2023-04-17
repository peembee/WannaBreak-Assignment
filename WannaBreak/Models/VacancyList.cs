using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WannaBreak.Models
{
    public class VacancyList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Vacancy ID")]
        public int VacancyListID { get; set; }


        [ForeignKey(name: "Employees")]
        [Display(Name = "Employee ID")]
        public int FK_EmployeeID { get; set; }
        public virtual Employee Employees { get; set; }


        [Display(Name = "Type ID")]
        [ForeignKey(name: "VacancyTypes")]
        public int FK_VacancyTypeID { get; set; }
        public virtual VacancyType VacancyTypes { get; set; }

        

        public DateTime Start { get; set; }

        public DateTime Stop { get; set; }

        public DateTime RegisteredDate { get; set; }
        
    }
}
