namespace BangaloreUniversityLearningSystem.Controllers
{
    using System;
    using System.Linq;

    using BangaloreUniversityLearningSystem.Enums;
    using BangaloreUniversityLearningSystem.Exceptions;
    using BangaloreUniversityLearningSystem.Interfaces;
    using BangaloreUniversityLearningSystem.Models;
    using BangaloreUniversityLearningSystem.Utilities;

    public class CoursesController : Controller
    {
        public CoursesController(IBangaloreUniversityDatabase data, User user)
            : base(data, user)
        {
        }

        public IView All()
        {
            return this.CreateView(this.Database.Courses.GetAll().OrderBy(c => c.Name).ThenByDescending(c => c.Students.Count));
        }

        public IView Details(int courseId)
        {
            this.EnsureAuthorization(Role.Student, Role.Lecturer);
            var course = this.GetCourse(courseId);

            if (!this.CurrentUser.Courses.Contains(course))
            {
                throw new ArgumentException(Constants.NotEnrolled);
            }

            return this.CreateView(course);
        }

        public IView Enroll(int courseId)
        {
            this.EnsureAuthorization(Role.Student, Role.Lecturer);

            var course = this.GetCourse(courseId);

            if (this.CurrentUser.Courses.Contains(course))
            {
                throw new ArgumentException(Constants.AlreadyEnrolled);
            }

            course.AddStudent(this.CurrentUser);
            return this.CreateView(course);
        }

        public IView Create(string name)
        {
            this.EnsureAuthorization(Role.Lecturer);

            var course = new Course(name);
            this.Database.Courses.Add(course);
            return this.CreateView(course);
        }

        public IView AddLecture(int courseId, string lectureName)
        {
            this.EnsureAuthorization(Role.Lecturer);
            var course = this.GetCourse(courseId);

            course.AddLecture(new Lecture(lectureName));
            return this.CreateView(course);
        }

        private Course GetCourse(int courseId)
        {
            var course = this.Database.Courses.Get(courseId);
            if (course == null)
            {
                throw new ArgumentException(string.Format(Constants.CourseDoesNotExist, courseId));
            }

            return course;
        }

        private void EnsureAuthorization(params Role[] roles)
        {
            this.EnsureUserIsLoggedIn();

            // PERFORMANCE Every user in the database was checked for their role, instead we only need to check the currently logged in user's role for authorization of the task.
            if (!roles.Contains(this.CurrentUser.Role))
            {
                throw new AuthorizationFailedException(Constants.NotAuthorized);
            }
        }
    }
}
