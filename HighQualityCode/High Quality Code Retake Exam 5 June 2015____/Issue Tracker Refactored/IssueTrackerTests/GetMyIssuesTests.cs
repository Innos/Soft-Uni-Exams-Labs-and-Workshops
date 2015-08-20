namespace IssueTrackerTests
{
    using System;
    using System.Collections.Generic;
    using IssueManager;
    using IssueManager.Interfaces;
    using IssueManager.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using Wintellect.PowerCollections;

    [TestClass]
    public class GetMyIssuesTests : TestBootstraper
    {
        [TestMethod]
        public void GetMyIssues_WithCorrectInput_ShouldReturnIssues()
        {
            this.tracker.RegisterUser("Admin", "password", "password");
            this.tracker.LoginUser("Admin", "password");
            this.tracker.CreateIssue("Random Issue", "Just an issue.", IssuePriority.Low, new[] { "issue", "new" });
            this.tracker.CreateIssue("Random Issue2", "Just an issue.", IssuePriority.Low, new[] { "issue", "new" });

            var result = this.tracker.GetMyIssues();
            var expectedResult = string.Format(
                "Random Issue{0}Priority: *{0}Just an issue.{0}Tags: issue,new{0}Random Issue2{0}Priority: *{0}Just an issue.{0}Tags: issue,new",
                Environment.NewLine);

            Assert.AreEqual(expectedResult, result, "GetMyIssues Method did not return a correct result.");
        }

        [TestMethod]
        public void GetMyIssues_WithCorrectInput_ShouldReturnOnlyCorrectIssues()
        {
            this.tracker.RegisterUser("Admin", "password", "password");
            this.tracker.LoginUser("Admin", "password");
            this.tracker.CreateIssue("Random Issue", "Just an issue.", IssuePriority.Low, new[] { "issue", "new" });
            this.tracker.CreateIssue("Random Issue2", "Just an issue.", IssuePriority.Low, new[] { "issue", "new" });
            this.tracker.LogoutUser();
            this.tracker.RegisterUser("Pesho", "123", "123");
            this.tracker.LoginUser("Pesho", "123");
            this.tracker.CreateIssue("Pesho's Issue", "Help I can't find my keys!", IssuePriority.High, new[] { "urgent" });
            this.tracker.LogoutUser();
            this.tracker.LoginUser("Admin", "password");

            var result = this.tracker.GetMyIssues();
            var expectedResult = string.Format(
                "Random Issue{0}Priority: *{0}Just an issue.{0}Tags: issue,new{0}Random Issue2{0}Priority: *{0}Just an issue.{0}Tags: issue,new",
                Environment.NewLine);

            Assert.AreEqual(expectedResult, result, "GetMyIssues Method did not return a correct result.");
        }

        [TestMethod]
        public void GetMyIssues_WithCorrectInput_ShouldReturnCorrectlySortedResult()
        {
            this.tracker.RegisterUser("Admin", "password", "password");
            this.tracker.LoginUser("Admin", "password");
            this.tracker.CreateIssue("Random Issue", "Just an issue.", IssuePriority.Low, new[] { "issue", "new" });
            this.tracker.CreateIssue("Random Issue2", "Just an issue.", IssuePriority.High, new[] { "issue", "new" });
            this.tracker.CreateIssue("Alpha Issue", "Just an issue.", IssuePriority.Low, new[] { "issue", "new" });

            var result = this.tracker.GetMyIssues();
            var expectedResult = string.Format(
                "Random Issue2{0}Priority: ***{0}Just an issue.{0}Tags: issue,new{0}Alpha Issue{0}Priority: *{0}Just an issue.{0}Tags: issue,new{0}Random Issue{0}Priority: *{0}Just an issue.{0}Tags: issue,new",
                Environment.NewLine);

            Assert.AreEqual(expectedResult, result, "GetMyIssues Method did not return a correct result.");
        }

        [TestMethod]
        public void GetMyIssues_WithoutALoggedUser_ShouldReturnErrorMessage()
        {
            this.tracker.RegisterUser("Admin", "password", "password");

            var result = this.tracker.GetMyIssues();
            var expectedResult = "There is no currently logged in user";

            Assert.AreEqual(expectedResult, result, "GetMyIssues Method did not return a No Logged In User message.");
        }

        [TestMethod]
        public void GetMyIssues_ForAnUserWithoutIssues_ShouldReturnErrorMessage()
        {
            this.tracker.RegisterUser("Admin", "password", "password");
            this.tracker.LoginUser("Admin", "password");

            var result = this.tracker.GetMyIssues();
            var expectedResult = "No issues";

            Assert.AreEqual(expectedResult, result, "GetMyIssues Method did not return a No Issues Message.");
        }

        [TestMethod]
        public void GetMyIssues_WithValidUser_ShouldCallTheCorrectDatabaseCollection()
        {
            var mock = new Mock<IIssueTrackerDatabase>();
            var mockDictionary = new Mock<MultiDictionary<User, Issue>>(true);
            mock.Setup(d => d.IssuesByUser).Returns(mockDictionary.Object);
            mockDictionary.Setup(d => d[It.IsAny<User>()]).Returns(new Issue[] { });
            mock.SetupProperty(d => d.CurrentUser, new User("Admin", "password"));
            var database = mock.Object;
            var trackerTest = new IssueTracker(database);

            trackerTest.GetMyIssues();

            mockDictionary.Verify(d => d[It.IsAny<User>()], Times.Exactly(1));
        }

        [TestMethod]
        public void GetMyIssues_WithValidUser_ShouldCallTheDatabaseWithCorrectUser()
        {
            var mock = new Mock<IIssueTrackerDatabase>();
            var mockDictionary = new Mock<MultiDictionary<User, Issue>>(true);
            mock.Setup(d => d.IssuesByUser).Returns(mockDictionary.Object);
            
            mockDictionary.Setup(d => d[It.IsAny<User>()]).Returns(new Issue[] { });
            var user = new User("Admin", "password");
            mock.SetupProperty(d => d.CurrentUser, user);
            var database = mock.Object;
            var trackerTest = new IssueTracker(database);

            trackerTest.GetMyIssues();

            mockDictionary.Verify(d => d[user], Times.Exactly(1));
        }
    }
}
