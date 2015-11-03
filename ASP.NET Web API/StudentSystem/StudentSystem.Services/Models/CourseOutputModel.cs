namespace StudentSystem.Services.Models
{
    using System.Collections.Generic;

    public class CourseOutputModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<string> Materials { get; set; }

        public IEnumerable<StudentOutputModel> Students { get; set; }
    }
}