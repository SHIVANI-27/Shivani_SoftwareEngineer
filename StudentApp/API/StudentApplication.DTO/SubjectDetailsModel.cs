using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApplication.DTO
{
    public class SubjectDetailsModel
    {
        public int Id { get; set; }
        public int StudentID { get; set; }
        public string Subject { get; set; }
        public int Marks { get; set; }
    }
}
