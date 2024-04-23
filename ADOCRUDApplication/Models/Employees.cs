using System.ComponentModel.DataAnnotations;

namespace ADOCRUDApplication.Models
{
    public class Employees
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public int age { get; set; }
        [Required]
        public string designation { get; set; }
        [Required]
        public string city { get; set; }
    }
}
