namespace IssueManager.Interfaces
{
    using System.Collections.Generic;

    using IssueManager.Model;

    using Wintellect.PowerCollections;

    public interface IIssueTrackerDatabase
    {
        User CurrentUser { get; set; }

        IDictionary<string, User> UsersByUsername { get; }

        OrderedDictionary<int, Issue> IssuesById { get; }

        MultiDictionary<User, Issue> IssuesByUser { get; }

        MultiDictionary<string, Issue> IssuesByTag { get; }

        MultiDictionary<User, Comment> Comments { get; }

        void AddIssue(Issue p);

        void RemoveIssue(Issue p);
    }
}
