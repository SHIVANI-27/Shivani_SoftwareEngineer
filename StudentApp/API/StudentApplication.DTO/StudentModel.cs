using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApplication.DTO
{
    public class StudentModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Class { get; set; } 
        public List<SubjectDetailsModel> SubjectDetails { get; set; }
    }


}
