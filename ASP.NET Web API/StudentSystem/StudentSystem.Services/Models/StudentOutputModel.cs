namespace StudentSystem.Services.Models
{
    using System;
    using StudentSystem.Models;
    using System.Linq.Expressions;

    public class StudentOutputModel
    {
        public static Expression<Func<Student, StudentOutputModel>> FromStudent
        {
            get
            {
                return s => new StudentOutputModel
                {
                    FullName = s.FirstName + " " + s.LastName,
                    Number = s.Number,
                    Email = s.Email,
                    Age = s.Age,
                    Status = s.Status.ToString()
                };
            }
        }

        public string FullName { get; set; }

        public string Number { get; set; }

        public string Email { get; set; }

        public string Status { get; set; }

        public byte Age { get; set; }
    }
}