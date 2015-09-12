namespace BangaloreUniversityLearningSystem.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using BangaloreUniversityLearningSystem.Models;

    public class UsersRepository : Repository<User>
    {
        public UsersRepository()
        {
            this.UsersByUsername = new Dictionary<string, User>();
        }

        public Dictionary<string, User> UsersByUsername { get; private set; }

        public User GetByUsername(string username)
        {
            return this.Items.FirstOrDefault(u => u.Username == username);
        }
    }
}
