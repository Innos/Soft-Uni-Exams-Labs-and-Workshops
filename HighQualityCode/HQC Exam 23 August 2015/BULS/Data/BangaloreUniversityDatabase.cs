namespace BangaloreUniversityLearningSystem.Data
{
    using BangaloreUniversityLearningSystem.Interfaces;
    using BangaloreUniversityLearningSystem.Models;

    public class BangaloreUniversityDatabase : IBangaloreUniversityDatabase
    {
        public BangaloreUniversityDatabase()
        {
            this.Users = new UsersRepository();
            this.Courses = new Repository<Course>();
        }

        public UsersRepository Users { get; private set; }

        public IRepository<Course> Courses { get; private set; }
    }
}
