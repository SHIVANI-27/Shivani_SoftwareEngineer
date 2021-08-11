using StudentApplication.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApplication.DAL
{
    public class StudentTransation
    {
        readonly StudentContext dbContext = null;
        public StudentTransation()
        {
            dbContext = new StudentContext();
        }

        public List<StudentModel> GetStudentList()
        {
            try
            {
                var studentList = (from s in dbContext.Students
                                   let subjects = (from a in dbContext.StudentDetails
                                                   where a.StudentID == s.StudentID select new SubjectDetailsModel
                                                   {
                                                       Id = a.ID,
                                                       Subject = a.Subject,
                                                       Marks = a.Marks
                                                   }).ToList()
                                   select new StudentModel
                                   {
                                       ID = s.StudentID,
                                       FirstName = s.FirstName,
                                       LastName = s.LastName,
                                       Class = s.Class,
                                       SubjectDetails = subjects
                                   }
                                   ).ToList();
                return studentList.OrderBy(x=>x.FirstName).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public StudentModel GetStudent(int studentId)
        {
            try
            {
                var student = (from s in dbContext.Students
                                   let subjects = (from a in dbContext.StudentDetails
                                                   where a.StudentID == s.StudentID
                                                   select new SubjectDetailsModel
                                                   {
                                                       Id = a.ID,
                                                       Subject = a.Subject,
                                                       Marks = a.Marks
                                                   }).ToList()
                                   where s.StudentID == studentId
                                   select new StudentModel
                                   {
                                       ID = s.StudentID,
                                       FirstName = s.FirstName,
                                       LastName = s.LastName,
                                       Class = s.Class,
                                       SubjectDetails = subjects
                                   }
                                   ).FirstOrDefault();
                return student;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddStudent(StudentModel studentModel)
        {
            try
            {
                bool isSaved = false;
                        if (studentModel != null)
                        {
                            Students students = new Students();
                            if(studentModel.ID > 0 && dbContext.Students.Any(x=>x.StudentID == studentModel.ID))
                            {
                                students = dbContext.Students.Where(x => x.StudentID == studentModel.ID).FirstOrDefault();
                            }
                            else
                            {
                                dbContext.Students.Add(students);
                            }
                            students.FirstName = studentModel.FirstName;
                            students.LastName = studentModel.LastName;
                            students.Class = studentModel.Class;
                            isSaved = dbContext.SaveChanges() > 0;
                            if (studentModel.SubjectDetails != null && studentModel.SubjectDetails.Count > 0)
                            {
                                foreach (var x in studentModel.SubjectDetails)
                                {
                                    SaveUpdateStudentDetails(students.StudentID, x);  
                                }
                        isSaved = true;
                            }
                        }
                 
                return isSaved;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SaveUpdateStudentDetails(int studentId, SubjectDetailsModel subjectDetails)
        {
            try
            {
                StudentDetails studentDetails = new StudentDetails();
                if(subjectDetails.Id > 0 && dbContext.StudentDetails.Any(x=>x.ID == subjectDetails.Id))
                {
                    studentDetails = dbContext.StudentDetails.Where(x => x.ID == subjectDetails.Id).FirstOrDefault();
                }
                else
                {
                    dbContext.StudentDetails.Add(studentDetails);
                }
                studentDetails.Subject = subjectDetails.Subject;
                studentDetails.Marks = subjectDetails.Marks;
                studentDetails.StudentID = studentId;
                var res=  dbContext.SaveChanges() > 0;
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteStudentDetails(DeleteModel deleteModel)
        {
            try
            {
                if(deleteModel.StudentId > 0  && dbContext.Students.Any(x=>x.StudentID == deleteModel.StudentId))
                {
                    if(dbContext.StudentDetails.Any(y=>y.StudentID == deleteModel.StudentId))
                    {
                        dbContext.StudentDetails.RemoveRange(dbContext.StudentDetails.Where(a => a.StudentID == deleteModel.StudentId));
                    }
                   var deleteItem =  dbContext.Students.Find(deleteModel.StudentId);
                   dbContext.Students.Remove(deleteItem);
                    
                }
                else if(deleteModel.StudentDetailId > 0 && dbContext.StudentDetails.Any(y => y.ID == deleteModel.StudentDetailId))
                {
                    var deleteItem = dbContext.StudentDetails.Find(deleteModel.StudentDetailId);
                    dbContext.StudentDetails.Remove(deleteItem);
                }
                return dbContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
