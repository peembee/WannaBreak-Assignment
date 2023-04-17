using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WannaBreak.Models
{
    public class VacancyType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VacancyTypeID { get; set; }

        [StringLength(50)]
        public string VacancyTitel { get; set; } = string.Empty;

        public virtual ICollection<VacancyList> VacancyLists { get; set;}
    }
}
