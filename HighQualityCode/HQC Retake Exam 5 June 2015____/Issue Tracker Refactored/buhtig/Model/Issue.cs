namespace IssueManager.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using IssueManager.Utilities;

    public class Issue
    {
        private string description;

        private string title;

        private int id;

        public Issue(string title, string description, IssuePriority priority, List<string> tags)
        {
            this.Title = title;
            this.Description = description;
            this.Priority = priority;
            this.Tags = tags;
            this.Comments = new List<Comment>();
        }

        public int Id
        {
            get
            {
                return this.id;
            }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Issue Id cannot be negative or zero.");
                }

                this.id = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < Constants.MinIssueTitleLength)
                {
                    throw new ArgumentException("The title must be at least 3 symbols long");
                }

                this.title = value;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < Constants.MinIssueDescriptionLength)
                {
                    throw new ArgumentException("The description must be at least 5 symbols long");
                }

                this.description = value;
            }
        }

        public IssuePriority Priority { get; set; }

        public IList<string> Tags { get; private set; }

        public List<Comment> Comments { get; private set; }

        public void AddComment(Comment comment)
        {
            this.Comments.Add(comment);
        }

        public override string ToString()
        {
            var issue = new StringBuilder();

            issue.AppendLine(this.Title)
                .AppendFormat("Priority: {0}", this.GetPriorityAsString())
                .AppendLine()
                .AppendLine(this.Description);

            if (this.Tags.Count > 0)
            {
                issue.AppendFormat("Tags: {0}", string.Join(",", this.Tags.OrderBy(t => t)));
                issue.AppendLine();
            }

            if (this.Comments.Count > 0)
            {
                issue.AppendFormat(
                    "Comments:{0}{1}{0}",
                    Environment.NewLine,
                    string.Join(Environment.NewLine, this.Comments));
            }
    
            return issue.ToString().Trim();
        }

        private string GetPriorityAsString()
        {
            switch (this.Priority)
            {
                case IssuePriority.Showstopper:
                    return "****";
                case IssuePriority.High:
                    return "***";
                case IssuePriority.Medium:
                    return "**";
                case IssuePriority.Low:
                    return "*";
                default:
                    throw new InvalidOperationException("The priority is invalid");
            }
        }
    }
}