using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Entities.Posts;

namespace ConsoleForum
{
    class ExtendedForum : Forum
    {
        private const int Delimiter = 20;

        protected override void ExecuteCommandLoop()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(new string('~', Delimiter));
            if (this.CurrentUser == null)
            {
                result.AppendLine("Hey stranger, care to login/register?");
            }
            else
            {
                result.AppendLine(string.Format("Welcome, {0}!", this.CurrentUser.Username));
            }
            result.AppendLine(string.Format("Hot questions: {0}, Active users: {1}",
                this.Questions.Count(question => question.Answers.Any(answer => answer is BestAnswer)),
                this.Answers.GroupBy(answer => answer.Author).Count(group => group.Count() >= 3)));
            result.AppendLine(new string('~', Delimiter));

            Console.Write(result.ToString());
            base.ExecuteCommandLoop();
            

        }
    }
}
