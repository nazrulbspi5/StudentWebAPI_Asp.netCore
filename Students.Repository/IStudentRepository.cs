using Students.Data;
using Students.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Students.Repository
{
    public class IStudentRepository : IStudent
    {
        private readonly StudentDbContext _db;
        public IStudentRepository(StudentDbContext dbContext)
        {
            _db = dbContext;
        }
        public IQueryable<Student> GetStudents => _db.Students;

        public void Delete(int? id)
        {
            Student student = _db.Students.Find(id);
            _db.Remove(student);
            _db.SaveChanges();
        }

        public Student GetStudent(int? id)
        {
            Student student = _db.Students.Find(id);
            return student;
        }
        //Add or Update
        public void Save(Student student)
        {
            if (student.Id==0)
            {
                _db.Add(student);
                _db.SaveChanges();
            }
            else if (student.Id!=0)
            {
                Student _Entity = _db.Students.Find(student.Id);
                _Entity.FirstName = student.FirstName;
                _Entity.LastName = student.LastName;
                _Entity.Gender = student.Gender;
                _Entity.Mobile = student.Mobile;
                _Entity.Address = student.Address;
                _db.SaveChanges();
            }
        }
    }
}
