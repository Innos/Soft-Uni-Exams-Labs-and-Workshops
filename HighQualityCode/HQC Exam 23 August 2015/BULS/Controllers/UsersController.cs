namespace BangaloreUniversityLearningSystem.Controllers
{
    using System;

    using BangaloreUniversityLearningSystem.Enums;
    using BangaloreUniversityLearningSystem.Interfaces;
    using BangaloreUniversityLearningSystem.Models;
    using BangaloreUniversityLearningSystem.Utilities;
    using BangaloreUniversityLearningSystem.Views;

    public class UsersController : Controller
    {
        public UsersController(IBangaloreUniversityDatabase data, User user)
            : base(data, user)
        {
            this.Database = data;
            this.CurrentUser = user;
        }

        /// <summary>
        /// Registers an user in the database if he passes validation for having no currently logged in user, having a matching password and having an existing user with given username in the database.
        /// </summary>
        /// <param name="username">The username of the user who wants to register.</param>
        /// <param name="password">The password of the user who wants to register.</param>
        /// <param name="confirmPassword">Conformation the password(same password typed again).</param>
        /// <param name="role">The role that the user will have (ex.Lecturer, Student).</param>
        /// <returns>Returns an IView of the user.</returns>
        public IView Register(string username, string password, string confirmPassword, string role)
        {
            if (password != confirmPassword)
            {
                throw new ArgumentException(Constants.PasswordsDoNotMatch);
            }

            this.EnsureNoLoggedInUser();

            var existingUser = this.Database.Users.GetByUsername(username);
            if (existingUser != null)
            {
                throw new ArgumentException(string.Format(Constants.UserAlreadyExists, username));
            }

            Role userRole = (Role)Enum.Parse(typeof(Role), role, true);
            var user = new User(username, password, userRole);
            this.Database.Users.Add(user);
            return this.CreateView(user);
        }

        public IView Login(string username, string password)
        {
            this.EnsureNoLoggedInUser();

            var existingUser = this.Database.Users.GetByUsername(username);
            if (existingUser == null)
            {
                throw new ArgumentException(string.Format(Constants.UserDoesNotExist, username));
            }

            if (existingUser.Password != HashUtilities.HashPassword(password))
            {
                throw new ArgumentException(Constants.IncorrectPassword);
            }

            this.CurrentUser = existingUser;
            return this.CreateView(existingUser);
        }

        public IView Logout()
        {
            this.EnsureUserIsLoggedIn();

            var user = this.CurrentUser;
            this.CurrentUser = null;
            return this.CreateView(user);
        }

        private void EnsureNoLoggedInUser()
        {
            if (this.CurrentUser != null)
            {
                throw new ArgumentException(Constants.AlreadyLoggedIn);
            }
        }
    }
}