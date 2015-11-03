namespace StudentSystem.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using StudentSystem.Models;
    using Models;
    using Data;

    public class StudentsController : ApiController
    {
        private IStudentSystemData data;

        public StudentsController()
            :this(new StudentsSystemData())
        {
        }

        public StudentsController(IStudentSystemData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var studentsFromDatabase = this.data.Students.All()
                .Select(StudentOutputModel.FromStudent);

            return Ok(studentsFromDatabase);
        }

        [HttpPost]
        public IHttpActionResult Create(StudentInputModel student)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var newStudent = new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Number = student.Number,
                Age = student.Age,
                Status = (StudentStatus)Enum.Parse(typeof(StudentStatus), student.Status)
            };

            this.data.Students.Add(newStudent);
            this.data.Students.SaveChanges();

            return Ok(newStudent);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, StudentInputModel student)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var studentFromDatabase = this.data.Students
                .All()
                .FirstOrDefault(s => s.Id == id);

            if(studentFromDatabase == null)
            {
                return BadRequest("Student not exist!");
            }

            studentFromDatabase.FirstName = student.FirstName;
            studentFromDatabase.LastName = student.LastName;
            studentFromDatabase.Age = student.Age;
            studentFromDatabase.Email = student.Email;
            studentFromDatabase.Number = student.Number;
            studentFromDatabase.Status = (StudentStatus)Enum.Parse(typeof(StudentStatus), student.Status);

            this.data.Students.SaveChanges();

            return Ok(student);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var studentFromDatabase = this.data.Students
                .All()
                .FirstOrDefault(s => s.Id == id);

            if (studentFromDatabase == null)
            {
                return BadRequest("Student not exist!");
            }

            this.data.Students.Delete(studentFromDatabase);
            this.data.Students.SaveChanges();

            return Ok();
        }
    }
}
