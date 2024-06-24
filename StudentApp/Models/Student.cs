using System.ComponentModel.DataAnnotations;

namespace StudentApp.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [StringLength(10)]
        public string StudentCode { get; set; }

        [Required]
        [StringLength(100)]
        public string StudentName { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string MobileNumber { get; set; }

        [Required]
        public DateTime JoinDate { get; set; }
    }
}
