using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;
using ConsoleForum.Entities.Posts;

namespace ConsoleForum.Commands
{
    class PostAnswerCommand : AbstractCommand
    {
        public PostAnswerCommand(IForum forum) : base(forum)
        {
        }

        public override void Execute()
        {
            var question = this.Forum.CurrentQuestion;
            string body = Data[1];
            if (!this.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }
            if (question == null)
            {
                throw new CommandException(Messages.NoQuestionOpened);
            }
            IAnswer answer = new Answer(this.Forum.Answers.Count + 1,body, this.Forum.CurrentUser);
            question.Answers.Add(answer);
            this.Forum.Answers.Add(answer);

            this.Forum.Output.AppendLine(string.Format(Messages.PostAnswerSuccess,answer.Id));
        }
    }
}
