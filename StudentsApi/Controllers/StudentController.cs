using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.Data;
using Students.Services;
using System.Linq;
namespace StudentsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _student;
        public StudentController(IStudent student)
        {
            _student = student;
        }
        [HttpPost]
        public IActionResult Save([FromBody] Student data)
        {
            if (data == null)
            {
                return BadRequest();
            }
            _student.Save(data);
            return Ok(data);
        }
        [HttpGet("{Id}")]
        public IActionResult GetStudent(int? id)
        {
            Student data = _student.GetStudent(id);
            return Ok(data);
        }
        [HttpGet]
        public IActionResult GetStudents()
        {
            IQueryable<Student> data = _student.GetStudents;
            return Ok(data);
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(int? id)
        {
            _student.Delete(id);
            return Ok();
        }
    }
}