using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TM.Api.Data.Entities
{
    public class Class
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public int DepartmentId { get; set; } 

        [ForeignKey(nameof(DepartmentId))]
        public Department Department { get; set; }
    }
}
