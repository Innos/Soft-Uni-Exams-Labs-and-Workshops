namespace IssueTrackerTests
{
    using System.Collections.Generic;

    using IssueManager;
    using IssueManager.Data;
    using IssueManager.Interfaces;
    using IssueManager.Model;
    using IssueManager.Utilities;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class RegisterUserTests : TestBootstraper
    {
        [TestMethod]
        public void RegisterUser_WithACorrectUser_ShouldRegisterUser()
        {
            string name = "Admin";
            var result = this.tracker.RegisterUser(name, "password", "password");
            var expectedResult = string.Format("User {0} registered successfully", name);

            Assert.AreEqual(expectedResult, result, "Register User method did not return a User Registered successfully message.");
        }

        [TestMethod]
        public void RegisterUser_WhileUserIsLoggedIn_ShouldReturnErrorMessage()
        {
            string name = "Admin";
            this.tracker.RegisterUser(name, "password", "password");
            this.tracker.LoginUser(name, "password");
            var result = this.tracker.RegisterUser("Admin2", "123", "123");
            var expectedResult = "There is already a logged in user";

            Assert.AreEqual(expectedResult, result, "Register User method did not return a There is already a logged in user message.");
        }

        [TestMethod]
        public void RegisterUser_WithANonMatchingPassword_ShouldReturnErrorMessage()
        {
            string name = "Admin";
            var result = this.tracker.RegisterUser(name, "password", "password1");
            var expectedResult = "The provided passwords do not match";

            Assert.AreEqual(expectedResult, result, "Register User method did not return a passwords didn't match message.");
        }

        [TestMethod]
        public void RegisterUser_WithAnExistingName_ShouldReturnErrorMessage()
        {
            string name = "Admin";
            this.tracker.RegisterUser(name, "password", "password");
            var result = this.tracker.RegisterUser(name, "123", "123");
            var expectedResult = string.Format("A user with username {0} already exists", name);

            Assert.AreEqual(expectedResult, result, "Register User method did not return an user with given username already exists message.");
        }

        [TestMethod]
        public void RegisterUser_WithAValidUser_ShouldAddAnEntryToTheUsersCollectionInTheDatabase()
        {
            var mock = new Mock<IIssueTrackerDatabase>();
            var mockDictionary = new Mock<IDictionary<string, User>>();
            mock.Setup(d => d.UsersByUsername).Returns(mockDictionary.Object);

            var name = "Name";
            var password = "Password";
            var database = mock.Object;
            var trackerTest = new IssueTracker(database);

            trackerTest.RegisterUser(name, password, password);

            mockDictionary.Verify(d => d.Add(It.IsAny<string>(), It.IsAny<User>()), Times.Exactly(1));
        }

        [TestMethod]
        public void RegisterUser_ShouldAddAnEntryWithTheCorrectKeyAndValueToTheCollection()
        {
            var mock = new Mock<IIssueTrackerDatabase>();
            var mockDictionary = new Mock<IDictionary<string, User>>();

            string expectedUsername = null;
            User expectedUser = null;
            mockDictionary.Setup(d => d.Add(It.IsAny<string>(), It.IsAny<User>()))
                .Callback<string, User>(
                    (name, user) =>
                    {
                        expectedUsername = name;
                        expectedUser = user;
                    });

            mock.Setup(d => d.UsersByUsername).Returns(mockDictionary.Object);

            var username = "Name";
            var password = "Password";
            var database = mock.Object;
            var trackerTest = new IssueTracker(database);

            trackerTest.RegisterUser(username, password, password);

            Assert.AreEqual(expectedUsername, username);
            Assert.AreEqual(expectedUser.Name, username);
            Assert.AreEqual(expectedUser.Password, HashUtility.HashPassword(password));
        }
    }
}
