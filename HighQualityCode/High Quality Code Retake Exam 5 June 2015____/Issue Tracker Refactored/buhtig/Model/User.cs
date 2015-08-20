namespace IssueManager.Model
{
    using IssueManager.Utilities;

    public class User
    {
        public User(string username, string password)
        {
            this.Name = username;
            this.Password = HashUtility.HashPassword(password);
        }

        public string Name { get; set; }

        public string Password { get; set; }

    }
}
