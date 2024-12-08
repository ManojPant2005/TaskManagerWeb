using System.ComponentModel.DataAnnotations;

namespace TM.Shared.DTOs
{
    public class DepartmentDto
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Subject { get; set; }

        [MaxLength(10)]
        public string AccessCode { get; set; }

    }
}
