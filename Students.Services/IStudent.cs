using System;
using System.Collections.Generic;
using System.Text;
using Students.Data;
using System.Linq;
namespace Students.Services
{
    public interface IStudent
    {
        Student GetStudent(int? id);
        IQueryable<Student> GetStudents { get; }
       void Save(Student student);
        void Delete(int? id);
    }
}
