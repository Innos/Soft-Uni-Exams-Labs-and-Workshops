namespace IssueManager.Model
{
    using System;
    using System.Text;

    using IssueManager.Utilities;

    public class Comment
    {
        private string text;

        public Comment(User author, string text)
        {
            this.Author = author;
            this.Text = text;
        }

        public User Author { get; set; }

        public string Text
        {
            get
            {
                return this.text;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < Constants.MinCommentLength)
                {
                    throw new ArgumentException("The text must be at least 2 symbols long");
                }

                this.text = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(this.Text);
            result.AppendFormat("-- {0}", this.Author.Name);
            result.AppendLine();
            return result.ToString().Trim();
        }
    }
}
