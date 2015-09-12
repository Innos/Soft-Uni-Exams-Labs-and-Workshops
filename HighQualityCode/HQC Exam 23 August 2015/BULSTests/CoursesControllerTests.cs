using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BULSTests
{
    using System.Collections.Generic;

    using BangaloreUniversityLearningSystem.Controllers;
    using BangaloreUniversityLearningSystem.Data;
    using BangaloreUniversityLearningSystem.Enums;
    using BangaloreUniversityLearningSystem.Exceptions;
    using BangaloreUniversityLearningSystem.Interfaces;
    using BangaloreUniversityLearningSystem.Models;
    using BangaloreUniversityLearningSystem.Utilities;

    using Moq;

    [TestClass]
    public class CoursesControllerTests
    {
        [TestMethod]
        public void All_WithValidData_ShouldCallDatabaseGetAll()
        {
            var database = new Mock<IBangaloreUniversityDatabase>();
            database.Setup(a => a.Courses.GetAll()).Returns(new List<Course>());

            var courseController = new CoursesController(database.Object, new User("Ivan Ivanov", "123456", Role.Lecturer));

            courseController.All();

            database.Verify(d => d.Courses.GetAll(), Times.Exactly(1));
        }

        [TestMethod]
        public void All_ShouldReturnAnIViewObject()
        {
            var database = new Mock<IBangaloreUniversityDatabase>();
            database.Setup(a => a.Courses.GetAll()).Returns(new List<Course>());

            var courseController = new CoursesController(database.Object, new User("Ivan Ivanov", "123456", Role.Lecturer));

            var result = courseController.All();

            NUnit.Framework.Assert.IsInstanceOf(typeof(IView), result);
        }

        [TestMethod]
        public void All_WithoutALoggedUser_ShouldStillReturnResult()
        {
            var database = new Mock<IBangaloreUniversityDatabase>();
            database.Setup(a => a.Courses.GetAll()).Returns(new List<Course>());

            var courseController = new CoursesController(database.Object, null);

            var result = courseController.All();

            NUnit.Framework.Assert.IsInstanceOf(typeof(IView), result);
        }

        [TestMethod]
        public void AddLecture_WithValidInput_ShouldCallDatabaseCourses()
        {
            var database = new Mock<IBangaloreUniversityDatabase>();
            database.Setup(a => a.Courses.Get(It.IsAny<int>())).Returns(new Course("Test1234"));

            var courseController = new CoursesController(database.Object, new User("Ivan Ivanov", "123456", Role.Lecturer));

            var result = courseController.AddLecture(1, "TestLecture");

            database.Verify(a => a.Courses.Get(It.IsAny<int>()), Times.Exactly(1));
        }

        [TestMethod]
        public void AddLecture_WithValidInput_ShouldAddNewLectureToSpecifiedCourse()
        {
            var database = new Mock<IBangaloreUniversityDatabase>();
            var course = new Course("Test1234");
            Assert.AreEqual(0, course.Lectures.Count);
            database.Setup(a => a.Courses.Get(It.IsAny<int>())).Returns(course);

            var courseController = new CoursesController(database.Object, new User("Ivan Ivanov", "123456", Role.Lecturer));

            var result = courseController.AddLecture(5, "TestLecture");

            Assert.AreEqual(1, course.Lectures.Count);
        }

        [TestMethod]
        public void AddLecture_WithValidInput_ShouldAddCorrectLectureToTheCourse()
        {
            var database = new Mock<IBangaloreUniversityDatabase>();
            var course = new Course("Test1234");
            Assert.AreEqual(0, course.Lectures.Count);
            database.Setup(a => a.Courses.Get(It.IsAny<int>())).Returns(course);

            var courseController = new CoursesController(database.Object, new User("Ivan Ivanov", "123456", Role.Lecturer));

            var result = courseController.AddLecture(5, "TestLecture");

            Assert.AreEqual("TestLecture", course.Lectures[0].Name);
        }

        [TestMethod]
        public void AddLecture_WithoutLoggedUser_ShouldThrowCorrectException()
        {
            var database = new Mock<IBangaloreUniversityDatabase>();
            var course = new Course("Test1234");
            database.Setup(a => a.Courses.Get(It.IsAny<int>())).Returns(course);

            var courseController = new CoursesController(database.Object, null);

            var exception = NUnit.Framework.Assert.Catch<ArgumentException>(
                () =>
                {
                    var result = courseController.AddLecture(5, "TestLecture");
                });
            Assert.AreEqual(Constants.NoLoggedInUserMessage, exception.Message);
        }

        [TestMethod]
        public void AddLecture_WithIncorrectRole_ShouldThrowCorrectException()
        {
            var database = new Mock<IBangaloreUniversityDatabase>();
            var course = new Course("Test1234");
            database.Setup(a => a.Courses.Get(It.IsAny<int>())).Returns(course);

            var courseController = new CoursesController(database.Object, new User("Ivan ivanov", "123456", Role.Student));

            var exception = NUnit.Framework.Assert.Catch<AuthorizationFailedException>(
                () =>
                {
                    var result = courseController.AddLecture(5, "TestLecture");
                });
            Assert.AreEqual(Constants.NotAuthorized, exception.Message);
        }

        [TestMethod]
        public void AddLecture_WithNonExistantCourse_ShouldThrowCorrectException()
        {
            var database = new Mock<IBangaloreUniversityDatabase>();
            Course course = null;
            database.Setup(a => a.Courses.Get(It.IsAny<int>())).Returns(course);

            var courseController = new CoursesController(database.Object, new User("Ivan Ivanov", "123456", Role.Lecturer));

            var exception = NUnit.Framework.Assert.Catch<ArgumentException>(
                () =>
                {
                    var result = courseController.AddLecture(5, "TestLecture");
                });
            Assert.AreEqual(string.Format(Constants.CourseDoesNotExist, 5), exception.Message);
        }

        [TestMethod]
        public void AddLecture_WithValidData_ReturnAnIViewObject()
        {
            var database = new Mock<IBangaloreUniversityDatabase>();
            var course = new Course("Test1234");
            Assert.AreEqual(0, course.Lectures.Count);
            database.Setup(a => a.Courses.Get(It.IsAny<int>())).Returns(course);

            var courseController = new CoursesController(database.Object, new User("Ivan Ivanov", "123456", Role.Lecturer));

            var result = courseController.AddLecture(5, "TestLecture");

            NUnit.Framework.Assert.IsInstanceOf(typeof(IView),result);
        }
    }
}
