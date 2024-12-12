using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM.Shared.DTOs
{
    public class ValidateSubjectDto
    {
        public string Subject { get; set; } 
        public int? SubjectId { get; set; } 
        public string AccessCode { get; set; }
    }

}
