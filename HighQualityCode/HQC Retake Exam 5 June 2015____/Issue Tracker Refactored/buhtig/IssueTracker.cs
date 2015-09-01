namespace IssueManager
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using IssueManager.Data;
    using IssueManager.Interfaces;
    using IssueManager.Model;
    using IssueManager.Utilities;

    public class IssueTracker : IIssueTracker
    {
        public IssueTracker(IIssueTrackerDatabase database)
        {
            this.Database = database;
        }

        public IssueTracker()
            : this(new IssueTrackerDatabase())
        {
        }

        private IIssueTrackerDatabase Database { get; set; }

        public string RegisterUser(string username, string password, string confirmPassword)
        {
            if (this.Database.CurrentUser != null)
            {
                return "There is already a logged in user";
            }

            if (password != confirmPassword)
            {
                return "The provided passwords do not match";
            }

            if (this.Database.UsersByUsername.ContainsKey(username))
            {
                return string.Format("A user with username {0} already exists", username);
            }

            var user = new User(username, password);
            this.Database.UsersByUsername.Add(username, user);
            return string.Format("User {0} registered successfully", username);
        }

        public string LoginUser(string username, string password)
        {
            if (this.Database.CurrentUser != null)
            {
                return "There is already a logged in user";
            }

            if (!this.Database.UsersByUsername.ContainsKey(username))
            {
                return string.Format("A user with username {0} does not exist", username);
            }

            var user = this.Database.UsersByUsername[username];
            if (user.Password != HashUtility.HashPassword(password))
            {
                return string.Format("The password is invalid for user {0}", username);
            }

            this.Database.CurrentUser = user;

            return string.Format("User {0} logged in successfully", username);
        }

        public string LogoutUser()
        {
            if (this.Database.CurrentUser == null)
            {
                return "There is no currently logged in user";
            }

            string username = this.Database.CurrentUser.Name;
            this.Database.CurrentUser = null;
            return string.Format("User {0} logged out successfully", username);
        }

        public string CreateIssue(string title, string description, IssuePriority priority, string[] strings)
        {
            if (this.Database.CurrentUser == null)
            {
                return "There is no currently logged in user";
            }

            var issue = new Issue(title, description, priority, strings.Distinct().ToList());
            this.Database.AddIssue(issue);

            return string.Format("Issue {0} created successfully", issue.Id);
        }

        public string RemoveIssue(int issueId)
        {
            if (this.Database.CurrentUser == null)
            {
                return "There is no currently logged in user";
            }

            if (!this.Database.IssuesById.ContainsKey(issueId))
            {
                return string.Format("There is no issue with ID {0}", issueId);
            }

            var issue = this.Database.IssuesById[issueId];
            if (
                !this.Database.IssuesByUser[this.Database.CurrentUser]
                     .Contains(issue))
            {
                return string.Format(
                    "The issue with ID {0} does not belong to user {1}", 
                    issueId, 
                    this.Database.CurrentUser.Name);
            }

            this.Database.RemoveIssue(issue);
            return string.Format("Issue {0} removed", issueId);
        }

        public string AddComment(int issueId, string commentToAdd)
        {
            if (this.Database.CurrentUser == null)
            {
                return "There is no currently logged in user";
            }

            if (!this.Database.IssuesById.ContainsKey(issueId))
            {
                return string.Format("There is no issue with ID {0}", issueId);
            }

            var issue = this.Database.IssuesById[issueId];
            var comment = new Comment(this.Database.CurrentUser, commentToAdd);
            issue.AddComment(comment);
            this.Database.Comments[this.Database.CurrentUser].Add(comment);
            return string.Format("Comment added successfully to issue {0}", issue.Id);
        }

        // Fixed a bottleneck by introducing a dictionary with users and their issues in the database.
        public string GetMyIssues()
        {
            if (this.Database.CurrentUser == null)
            {
                return "There is no currently logged in user";
            }

            var issues =
                this.Database.IssuesByUser[this.Database.CurrentUser];
            if (!issues.Any())
            {
                return "No issues";
            }

            return string.Join(Environment.NewLine, issues.OrderByDescending(x => x.Priority).ThenBy(x => x.Title));
        }

        // Fixed a bottleneck by introducing a dictionary with users and their comments in the database
        public string GetMyComments()
        {
            if (this.Database.CurrentUser == null)
            {
                return "There is no currently logged in user";
            }

            var comments = this.Database.Comments[this.Database.CurrentUser];
            if (!comments.Any())
            {
                return "No comments";
            }

            return string.Join(Environment.NewLine, comments);
        }

        public string SearchForIssues(string[] tags)
        {
            if (tags.Length <= 0)
            {
                return "There are no tags provided";
            }

            var issues = new List<Issue>();
            foreach (var tag in tags)
            {
                issues.AddRange(this.Database.IssuesByTag[tag]);
            }

            if (!issues.Any())
            {
                return "There are no issues matching the tags provided";
            }

            var orderedIssues = issues.Distinct().OrderByDescending(x => x.Priority).ThenBy(x => x.Title);

            return string.Join(Environment.NewLine, orderedIssues);
        }
    }
}