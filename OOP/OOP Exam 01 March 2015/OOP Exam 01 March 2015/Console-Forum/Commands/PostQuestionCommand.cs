using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;
using ConsoleForum.Entities.Posts;

namespace ConsoleForum.Commands
{
    class PostQuestionCommand : AbstractCommand
    {
        public PostQuestionCommand(IForum forum) : base(forum)
        {
        }

        public override void Execute()
        {
            var questions = this.Forum.Questions;
            string title = Data[1];
            string body = Data[2];
            IUser author = this.Forum.CurrentUser;
            if (author == null)
            {
                throw new CommandException(Messages.NotLogged);
            }
            IQuestion question = new Question(questions.Count + 1,body,author,title,new List<IAnswer>());
            questions.Add(question);
            author.Questions.Add(question);
            this.Forum.Output.AppendLine(string.Format(Messages.PostQuestionSuccess, question.Id));
        }
    }
}
