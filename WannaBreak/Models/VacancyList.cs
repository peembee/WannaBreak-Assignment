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


        [Display(Name = "Break Type!")]
        [ForeignKey(name: "VacancyTypes")]
        public int FK_VacancyTypeID { get; set; }
        public virtual VacancyType VacancyTypes { get; set; }

        

        public DateTime Start { get; set; }

        public DateTime Stop { get; set; }

        public DateTime RegisteredDate { get; set; }

        public string EmployeeFullName { get; set; } // saves name from employee due to mathcing of keys
        public string VacancyNameTitel { get; set; } // saves name from employee due to mathcing of keys

    }
}
