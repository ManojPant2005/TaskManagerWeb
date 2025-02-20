﻿using System.ComponentModel.DataAnnotations;

namespace TM.Api.Data.Entities
{
    public class Department
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
