using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApplication.DAL
{
    public class StudentContext : DbContext
    {

        public StudentContext()
            : base("TestDBConn")
        {
            Database.SetInitializer<StudentContext>(new CreateDatabaseIfNotExists<StudentContext>());

        }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<StudentDetails> StudentDetails { get; set; }
    }
}
