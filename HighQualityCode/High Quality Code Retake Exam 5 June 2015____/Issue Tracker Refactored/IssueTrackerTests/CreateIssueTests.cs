namespace IssueTrackerTests
{
    using System.Collections;
    using System.Collections.Generic;
    using IssueManager;
    using IssueManager.Data;
    using IssueManager.Interfaces;
    using IssueManager.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class CreateIssueTests : TestBootstraper
    {
        [TestMethod]
        public void CreateIssue_WithACorrectInput_ShouldCreateIssue()
        {
            this.tracker.RegisterUser("Admin", "password", "password");
            this.tracker.LoginUser("Admin", "password");
            var result = this.tracker.CreateIssue("Random Issue", "Just an issue.", IssuePriority.Low, new[] { "issue", "new" });
            var expectedResult = "Issue 1 created successfully";

            Assert.AreEqual(expectedResult, result, "Create Issue Method did not return an Issue created succesfully message.");
        }

        [TestMethod]
        public void CreateIssue_WithRemovedAndAddedIssues_ShouldReturnAnIssueWithACorrectID()
        {
            this.tracker.RegisterUser("Admin", "password", "password");
            this.tracker.LoginUser("Admin", "password");
            this.tracker.CreateIssue("Random Issue", "Just an issue.", IssuePriority.Low, new[] { "issue", "new" });
            this.tracker.CreateIssue("Random Issue2", "Just an issue.", IssuePriority.Low, new[] { "issue", "new" });
            this.tracker.RemoveIssue(2);
            var result = this.tracker.CreateIssue("Random Issue3", "Just an issue.", IssuePriority.Low, new[] { "issue", "new" });
            var expectedResult = "Issue 3 created successfully";

            Assert.AreEqual(expectedResult, result, "Create Issue Method did not return a Issue created succesfully message.");
        }

        [TestMethod]
        public void CreateIssue_WithoutALoggedUser_ShouldReturnAErrorMessage()
        {
            this.tracker.RegisterUser("Admin", "password", "password");
            var result = this.tracker.CreateIssue("Random Issue", "Just an issue.", IssuePriority.Low, new[] { "issue", "new" });
            var expectedResult = "There is no currently logged in user";

            Assert.AreEqual(expectedResult, result, "Create Issue Method did not return a Issue created succesfully message.");
        }

        [TestMethod]
        public void CreateIssue_WithACorrectInput_ShouldCallDatabaseAddIssueMethod()
        {
            var mock = new Mock<IIssueTrackerDatabase>();
            mock.SetupProperty(a => a.CurrentUser, new User("Admin", "password"));

            var title = "Title";
            var desc = "Description";
            var priority = IssuePriority.High;
            var tags = new string[] { "new" };
            var database = mock.Object;
            var trackerTest = new IssueTracker(database);

            trackerTest.CreateIssue(title, desc, priority, tags);

            mock.Verify(d => d.AddIssue(It.IsAny<Issue>()), Times.Exactly(1));
        }

        [TestMethod]
        public void CreateIssue_WithACorrectInput_ShouldSendAnIssueWithCorrectValuesToTheDatabase()
        {
            var mock = new Mock<IIssueTrackerDatabase>();
            Issue expected = null;
            mock.Setup(d => d.AddIssue(It.IsAny<Issue>())).Callback<Issue>(r => expected = r);
            mock.SetupProperty(a => a.CurrentUser, new User("Admin", "password"));

            var title = "Title";
            var desc = "Description";
            var priority = IssuePriority.High;
            var tags = new string[] { "new" };
            var database = mock.Object;
            var trackerTest = new IssueTracker(database);

            trackerTest.CreateIssue(title, desc, priority, tags);

            Assert.AreEqual(title, expected.Title);
            Assert.AreEqual(desc, expected.Description);
            Assert.AreEqual(priority, expected.Priority);
            CollectionAssert.AreEqual(tags, (ICollection)expected.Tags);
        }
    }
}
