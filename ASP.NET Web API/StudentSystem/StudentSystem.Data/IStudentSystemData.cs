namespace StudentSystem.Data
{
    using StudentSystem.Models;
    using StudentSystem.Data.Repositories;

    public interface IStudentSystemData
    {
        IRepository<Course> Courses { get; }

        IRepository<Student> Students { get; }

        IRepository<Homework> Homeworks { get; }

        void SaveChanges();
    }
}
