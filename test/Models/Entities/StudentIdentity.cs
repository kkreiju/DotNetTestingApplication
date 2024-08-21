using System.ComponentModel.DataAnnotations;

namespace test.Models.Entities
{
    public class StudentIdentity
    {
        [Key]
        public Guid StudID { get; set; }

        public string StudName { get; set; }

        public string StudEmail { get; set; }

        public string StudPhone { get; set; }
    }
}
