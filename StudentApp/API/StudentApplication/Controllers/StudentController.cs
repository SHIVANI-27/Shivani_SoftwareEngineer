using StudentApplication.BL;
using StudentApplication.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace StudentApplication.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StudentController : ApiController
    {
        [HttpPost]
        [Route("api/Student/AddUpdate")]
        public IHttpActionResult AddUpdate(StudentModel studentModel)
        {
            try
            {
                StudentBL student = new StudentBL();
                return Ok(student.AddStudent(studentModel));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("api/Student/Delete")]
        public IHttpActionResult Delete(DeleteModel deleteModel)
        {
            try
            {
                StudentBL student = new StudentBL();
                return Ok(student.Delete(deleteModel));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("api/Student/GetStudentList")]
        public IHttpActionResult GetStudentList()
        {
            try
            {
                StudentBL student = new StudentBL();
                return Ok(student.GetStudents());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("api/Student/GetStudentDetail")]
        public IHttpActionResult GetStudentDetail([FromBody]int studentId)
        {
            try
            {
                StudentBL student = new StudentBL();
                return Ok(student.GetStudent(studentId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
