using System.ComponentModel.DataAnnotations;

namespace TM.Shared.DTOs
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }

    }
}
