using StudentApplication.DAL;
using StudentApplication.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApplication.BL
{
    public class StudentBL
    {
        readonly StudentTransation studentTransation = null;
        public StudentBL()
        {
            studentTransation = new StudentTransation();
        }

        public ResponseModel<bool> AddStudent(StudentModel studentModel)
        {
            ResponseModel<bool> response = new ResponseModel<bool>();
            try
            {
                response.Data = studentTransation.AddStudent(studentModel);
                response.Success = response.Data == true ? true : false;
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ResponseModel<bool> Delete(DeleteModel deleteModel)
        {
            ResponseModel<bool> response = new ResponseModel<bool>();
            try
            {
                response.Data = studentTransation.DeleteStudentDetails(deleteModel);
                response.Success = response.Data == true ? true : false;
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ResponseModel<List<StudentModel>> GetStudents()
        {
            ResponseModel<List<StudentModel>> response = new ResponseModel<List<StudentModel>>();
            try
            {
                response.Data = studentTransation.GetStudentList();
                response.Success = response.Data.Count > 0 ? true : false;
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public ResponseModel<StudentModel> GetStudent(int studentId)
        {
            ResponseModel<StudentModel> response = new ResponseModel<StudentModel>();
            try
            {
                response.Data = studentTransation.GetStudent(studentId);
                response.Success = response.Data != null ? true : false;
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
