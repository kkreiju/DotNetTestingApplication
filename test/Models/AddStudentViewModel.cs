using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class AddStudentViewModel
    {
        [Key]
        public Guid StudID { get; set; }

        public string StudName { get; set; }

        public string StudEmail { get; set; }

        public string StudPhone { get; set; }
    }
}
