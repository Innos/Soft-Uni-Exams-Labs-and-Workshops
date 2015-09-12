namespace BangaloreUniversityLearningSystem.Models
{
    using System;
    using System.Collections.Generic;

    using BangaloreUniversityLearningSystem.Enums;
    using BangaloreUniversityLearningSystem.Utilities;

    public class User
    {
        private string username;
        private string passwordHash;

        public User(string username, string password, Role role)
        {
            this.Username = username;
            this.Password = password;
            this.Role = role;
            this.Courses = new List<Course>();
        }

        public string Username
        {
            get
            {
                return this.username;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < Constants.MinUsernameLength)
                {
                    throw new ArgumentException(string.Format(Constants.IncorrectParameterLength, "username", Constants.MinUsernameLength));
                }

                this.username = value;
            }
        }

        public string Password
        {
            get
            {
                return this.passwordHash;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < Constants.MinPasswordLength)
                {
                    throw new ArgumentException(string.Format(Constants.IncorrectParameterLength, "password", Constants.MinPasswordLength));
                }

                this.passwordHash = HashUtilities.HashPassword(value);
            }
        }

        public Role Role { get; private set; }

        public IList<Course> Courses { get; private set; }
    }
}
