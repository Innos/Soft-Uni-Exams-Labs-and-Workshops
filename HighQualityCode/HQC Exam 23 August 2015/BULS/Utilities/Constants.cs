namespace BangaloreUniversityLearningSystem.Utilities
{
    public static class Constants
    {
        public const string NoLoggedInUserMessage = "There is no currently logged in user.";

        public const string NotAuthorized = "The current user is not authorized to perform this operation.";

        public const string NotEnrolled = "You are not enrolled in this course.";

        public const string CourseDoesNotExist = "There is no course with ID {0}.";

        public const string AlreadyEnrolled = "You are already enrolled in this course.";

        public const string PasswordsDoNotMatch = "The provided passwords do not match.";

        public const string AlreadyLoggedIn = "There is already a logged in user.";

        public const string UserAlreadyExists = "A user with username {0} already exists.";

        public const string UserDoesNotExist = "A user with username {0} does not exist.";

        public const string IncorrectPassword = "The provided password is wrong.";

        public const string IncorrectParameterLength = "The {0} must be at least {1} symbols long.";

        public const int MinUsernameLength = 5;

        public const int MinPasswordLength = 6;

        public const int MinCourseNameLength = 5;

        public const int MinLectureNameLength = 3;
    }
}
