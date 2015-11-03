namespace StudentSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using StudentSystem.Data;
    using StudentSystem.Models;
    using StudentSystem.Services.Models;

    public class CoursesController : ApiController
    {
        private IStudentSystemData data;

        public CoursesController()
            : this(new StudentsSystemData())
        {
        }

        public CoursesController(IStudentSystemData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var courses = this.data.Courses.All();

            return Ok(courses);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var course = this.data
                .Courses
                .All()
                .Where(c => c.Id == id)
                .Select(c => new CourseOutputModel
                {
                    Name = c.Name,
                    Description = c.Description,
                    Students = c.Students.Select(s => new StudentOutputModel
                    {
                        FullName = s.FirstName + " " + s.LastName,
                        Number = s.Number,
                        Age = s.Age,
                        Email = s.Email,
                        Status = s.Status.ToString()
                    }),
                    Materials = c.Materials.Select(m => m.Content)
                })
                .FirstOrDefault();
                

            if (course == null)
            {
                return BadRequest("Course not exist - invalid id");
            }

            return Ok(course);
        }

        [HttpPost]
        public IHttpActionResult Create(CourseInputModel course)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            this.data
                .Courses
                .Add(new Course
                {
                    Name = course.Name,
                    Description = course.Description
                });

            this.data.Courses.SaveChanges();

            return Ok(course);
        }

        [HttpPut]
        public IHttpActionResult AddStudent(int id, int studentId)
        {
            var course = this.data.Courses
                .All()
                .FirstOrDefault(c => c.Id == id);

            if(course == null)
            {
                return BadRequest("Course not exist - invalid id");
            }

            var student = this.data.Students
                .All()
                .FirstOrDefault(s => s.Id == studentId);

            if (student == null)
            {
                return BadRequest("Student not exist - invalid id");
            }

            course.Students.Add(student);
            this.data.Courses.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AddMaterial(int id, MaterialModel material)
        {
            var course = this.data.Courses
                .All()
                .FirstOrDefault(c => c.Id == id);

            if (course == null)
            {
                return BadRequest("Course not exist - invalid id");
            }

            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            course.Materials.Add(new Material
            {
                Content = material.Content
            });

            this.data.Courses.SaveChanges();

            return Ok(material);
        }

        [HttpPost]
        public IHttpActionResult AddHomework(int id, HomeworkModel homework)
        {
            var course = this.data.Courses
                .All()
                .FirstOrDefault(c => c.Id == id);

            if (course == null)
            {
                return BadRequest("Course not exist - invalid id");
            }

            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var newHomework = new Homework
            {
                Content = homework.Content,
                Deadline = homework.Deadline
            };

            course.Homeworks.Add(newHomework);
            foreach (var student in course.Students)
            {
                student.Homeworks.Add(newHomework);
            }

            this.data.Courses.SaveChanges();

            return Ok(homework);
        }
    }
}
