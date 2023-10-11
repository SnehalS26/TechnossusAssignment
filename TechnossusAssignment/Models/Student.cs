using System.ComponentModel.DataAnnotations;

namespace TechnossusAssignment.Models
{
    public class Student
    {
        [Key]
        [ScaffoldColumn(false)]
        public int id { get; set; }
        [Required]
        public string? StudName { get; set; }
        [Required]
        public string? FatherName { get; set; }
        [Required]
        public string? MotherName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public DateTime Registration_Date { get; set; }
        [ScaffoldColumn(false)]
        public int isActive { get; set; }
    }
}
