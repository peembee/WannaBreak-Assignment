namespace WannaBreak.Models
{
    public class VacancyWithEmployeeViewModel
    {
        public int VacancyListID { get; set; }
        public string VacancyTypeName { get; set; }
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
        public DateTime? RegisteredDate { get; set; }
        public string? EmployeeName { get; set; }
    }
}
