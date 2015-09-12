namespace BangaloreUniversityLearningSystem.Models
{
    using System;
    using System.Collections.Generic;

    using BangaloreUniversityLearningSystem.Utilities;

    public class Course
    {
        private string name;

        public Course(string name)
        {
            this.Name = name;
            this.Lectures = new List<Lecture>();
            this.Students = new List<User>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < Constants.MinCourseNameLength)
                {
                    throw new ArgumentException(string.Format(Constants.IncorrectParameterLength, "course name", Constants.MinCourseNameLength));
                }

                this.name = value;
            }
        }

        public IList<Lecture> Lectures { get; private set; }

        public IList<User> Students { get; private set; }

        public void AddLecture(Lecture lecture)
        {
            this.Lectures.Add(lecture);
        }

        public void AddStudent(User student)
        {
            this.Students.Add(student);
            student.Courses.Add(this);
        }
    }
}