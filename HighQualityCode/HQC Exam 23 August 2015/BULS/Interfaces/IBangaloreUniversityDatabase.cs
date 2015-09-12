namespace BangaloreUniversityLearningSystem.Interfaces
{
    using BangaloreUniversityLearningSystem.Data;
    using BangaloreUniversityLearningSystem.Models;

    public interface IBangaloreUniversityDatabase
    {
        UsersRepository Users { get; }

        IRepository<Course> Courses { get; }
    }
}
