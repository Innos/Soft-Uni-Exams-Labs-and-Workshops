namespace IssueManager.Data
{
    using System.Collections.Generic;

    using IssueManager.Interfaces;
    using IssueManager.Model;

    using Wintellect.PowerCollections;

    public class IssueTrackerDatabase : IIssueTrackerDatabase
    {
        private int nextIssueId;

        public IssueTrackerDatabase()
        {
            this.nextIssueId = 1;
            this.UsersByUsername = new Dictionary<string, User>();
            this.IssuesById = new OrderedDictionary<int, Issue>();
            this.IssuesByUser = new MultiDictionary<User, Issue>(true);
            this.IssuesByTag = new MultiDictionary<string, Issue>(true);
            this.Comments = new MultiDictionary<User, Comment>(true);
        }

        public User CurrentUser { get; set; }

        public IDictionary<string, User> UsersByUsername { get; set; }

        public OrderedDictionary<int, Issue> IssuesById { get; private set; }

        public MultiDictionary<User, Issue> IssuesByUser { get; set; }

        public MultiDictionary<string, Issue> IssuesByTag { get; set; }

        public MultiDictionary<User, Comment> Comments { get; set; }

        public void AddIssue(Issue problem)
        {
            problem.Id = this.nextIssueId;
            this.nextIssueId++;
            this.IssuesById.Add(problem.Id, problem);
            this.IssuesByUser.Add(this.CurrentUser, problem);
            foreach (var tag in problem.Tags)
            {
                this.IssuesByTag.Add(tag, problem);
            }
        }

        public void RemoveIssue(Issue problem)
        {
            this.IssuesById.Remove(problem.Id);
            this.IssuesByUser.Remove(this.CurrentUser, problem);
            foreach (var tag in problem.Tags)
            {
                this.IssuesByTag.Remove(tag, problem);
            }
        }
    }
}