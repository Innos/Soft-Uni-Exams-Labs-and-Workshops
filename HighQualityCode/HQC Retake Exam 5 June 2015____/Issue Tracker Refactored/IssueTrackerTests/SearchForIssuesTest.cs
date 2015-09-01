namespace IssueTrackerTests
{
    using System;

    using IssueManager;
    using IssueManager.Interfaces;
    using IssueManager.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using Wintellect.PowerCollections;

    [TestClass]
    public class SearchForIssuesTest : TestBootstraper
    {
        [TestMethod]
        public void SearchForIssues_WithValidTag_ShouldCorrectIssues()
        {
            this.tracker.RegisterUser("Admin", "password", "password");
            this.tracker.LoginUser("Admin", "password");
            this.tracker.CreateIssue("Random Issue", "Just an issue.", IssuePriority.High, new[] { "issue", "new" });
            this.tracker.CreateIssue("Random Issue2", "Just an issue.", IssuePriority.Low, new[] { "issue", "new" });
            this.tracker.CreateIssue("Random Issue3", "Just an issue.", IssuePriority.High, new[] { "issue" });

            var result = this.tracker.SearchForIssues(new[] { "new" });
            var expectedResult = string.Format(
                "Random Issue{0}Priority: ***{0}Just an issue.{0}Tags: issue,new{0}Random Issue2{0}Priority: *{0}Just an issue.{0}Tags: issue,new",
                Environment.NewLine);

            Assert.AreEqual(expectedResult, result, "SearchForIssues Method did not return the correct issues.");
        }

        [TestMethod]
        public void SearchForIssues_ShouldReturnSortedIssues()
        {
            this.tracker.RegisterUser("Admin", "password", "password");
            this.tracker.LoginUser("Admin", "password");
            this.tracker.CreateIssue("Random Issue", "Just an issue.", IssuePriority.High, new[] { "issue", "new" });
            this.tracker.CreateIssue("Random Issue2", "Just an issue.", IssuePriority.Low, new[] { "issue", "new" });
            this.tracker.CreateIssue("Alpha Issue", "Just an issue.", IssuePriority.High, new[] { "new" });

            var result = this.tracker.SearchForIssues(new[] { "new" });
            var expectedResult = string.Format(
                "Alpha Issue{0}Priority: ***{0}Just an issue.{0}Tags: new{0}Random Issue{0}Priority: ***{0}Just an issue.{0}Tags: issue,new{0}Random Issue2{0}Priority: *{0}Just an issue.{0}Tags: issue,new",
                Environment.NewLine);

            Assert.AreEqual(expectedResult, result, "SearchForIssues Method returned an incorrectly ordered result.");
        }

        [TestMethod]
        public void SearchForIssues_WithAnEmptyArrayOfTags_ShouldReturnAnErrorMessage()
        {
            this.tracker.RegisterUser("Admin", "password", "password");
            this.tracker.LoginUser("Admin", "password");

            var result = this.tracker.SearchForIssues(new string[0]);
            var expectedResult = "There are no tags provided";

            Assert.AreEqual(expectedResult, result, "SearchForIssues Method did not return a No tags provided message.");
        }

        [TestMethod]
        public void SearchForIssues_WithoutMatchingResults_ShouldReturnAnErrorMessage()
        {
            this.tracker.RegisterUser("Admin", "password", "password");
            this.tracker.LoginUser("Admin", "password");

            var result = this.tracker.SearchForIssues(new[] { "new" });
            var expectedResult = "There are no issues matching the tags provided";

            Assert.AreEqual(expectedResult, result, "SearchForIssues Method did not return a No issues matching tags message.");
        }

        [TestMethod]
        public void SearchForIssues_WithValidUser_ShouldCallTheCorrectDatabaseCollection()
        {
            var mock = new Mock<IIssueTrackerDatabase>();
            var mockDictionary = new Mock<MultiDictionary<string, Issue>>(true);
            mock.Setup(d => d.IssuesByTag).Returns(mockDictionary.Object);
            mockDictionary.Setup(d => d[It.IsAny<string>()]).Returns(new Issue[] { });
            mock.SetupProperty(d => d.CurrentUser, new User("Admin", "password"));
            var tags = new string[] { "tag1", "tag2" };
            var database = mock.Object;
            var trackerTest = new IssueTracker(database);

            trackerTest.SearchForIssues(tags);

            mockDictionary.Verify(d => d[It.IsAny<string>()]);
        }

        [TestMethod]
        public void SearchForIssues_WithValidUser_ShouldCallTheDatabaseACorrectAmountOfTimes()
        {
            var mock = new Mock<IIssueTrackerDatabase>();
            var mockDictionary = new Mock<MultiDictionary<string, Issue>>(true);
            mock.Setup(d => d.IssuesByTag).Returns(mockDictionary.Object);
            mockDictionary.Setup(d => d[It.IsAny<string>()]).Returns(new Issue[] { });
            mock.SetupProperty(d => d.CurrentUser, new User("Admin", "password"));
            var tags = new string[] { "tag1", "tag2" };
            var database = mock.Object;
            var trackerTest = new IssueTracker(database);

            trackerTest.SearchForIssues(tags);

            mockDictionary.Verify(d => d[It.IsAny<string>()], Times.Exactly(tags.Length));
        }

        [TestMethod]
        public void SearchForIssues_WithValidUser_ShouldCallTheDatabaseWithCorrectParameters()
        {
            var mock = new Mock<IIssueTrackerDatabase>();
            var mockDictionary = new Mock<MultiDictionary<string, Issue>>(true);
            mock.Setup(d => d.IssuesByTag).Returns(mockDictionary.Object);
            mockDictionary.Setup(d => d[It.IsAny<string>()]).Returns(new Issue[] { });
            mock.SetupProperty(d => d.CurrentUser, new User("Admin", "password"));
            var tags = new string[] { "tag1", "tag2" };
            var database = mock.Object;
            var trackerTest = new IssueTracker(database);

            trackerTest.SearchForIssues(tags);

            mockDictionary.Verify(d => d[tags[0]], Times.Exactly(1));
            mockDictionary.Verify(d => d[tags[1]], Times.Exactly(1));

        }
    }
}
