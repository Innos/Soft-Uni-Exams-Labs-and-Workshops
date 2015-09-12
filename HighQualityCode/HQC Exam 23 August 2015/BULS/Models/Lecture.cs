namespace BangaloreUniversityLearningSystem.Models
{
    using System;

    using BangaloreUniversityLearningSystem.Utilities;

    public class Lecture
    {
        private string name;

        public Lecture(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < Constants.MinLectureNameLength)
                {
                    throw new ArgumentException(string.Format(Constants.IncorrectParameterLength, "lecture name", Constants.MinLectureNameLength));
                }

                this.name = value;
            }
        }
    }
}