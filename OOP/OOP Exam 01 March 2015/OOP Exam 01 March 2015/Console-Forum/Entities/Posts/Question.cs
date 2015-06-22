using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;

namespace ConsoleForum.Entities.Posts
{
    class Question : Post, IQuestion
    {
        public Question(int id, string body, IUser author, string title, IList<IAnswer> answers)
            : base(id, body, author)
        {
            this.Title = title;
            this.Answers = answers;
        }

        public string Title { get; set; }
        public IList<IAnswer> Answers { get; private set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("[ Question ID: {0} ]{1}", this.Id, Environment.NewLine);
            output.AppendFormat("Posted by: {0}{1}", this.Author.Username, Environment.NewLine);
            output.AppendFormat("Question Title: {0}{1}", this.Title, Environment.NewLine);
            output.AppendFormat("Question Body: {0}{1}", this.Body, Environment.NewLine);
            output.AppendLine(new string('=',Delimiter));
            if (this.Answers.Count == 0)
            {
                output.AppendLine("No answers");
            }
            else
            {
                output.AppendLine("Answers:");
                IAnswer bestAnswer = this.Answers.FirstOrDefault(answer => answer is BestAnswer);
                if (bestAnswer != null)
                {
                    output.Append((BestAnswer)bestAnswer);
                }
                foreach (var answer in this.Answers.Where(ans => !(ans is BestAnswer)).OrderBy(ans=>ans.Id))
                {
                    output.AppendLine(answer.ToString());
                }
            }

            return output.ToString();
        }
    }
}
