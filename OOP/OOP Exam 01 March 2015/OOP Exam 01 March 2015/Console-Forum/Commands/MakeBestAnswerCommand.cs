using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;
using ConsoleForum.Entities.Posts;

namespace ConsoleForum.Commands
{
    class MakeBestAnswerCommand : AbstractCommand
    {
        public MakeBestAnswerCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            int id = int.Parse(Data[1]);
            var question = this.Forum.CurrentQuestion;

            if (!this.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }
            //question == null is always false?!?!?!?
            if (this.Forum.CurrentQuestion == null)
            {
                throw new CommandException(Messages.NoQuestionOpened);
            }

            var answer = this.Forum.CurrentQuestion.Answers.FirstOrDefault(ans => ans.Id == id);

            if (answer == null)
            {
                throw new CommandException(Messages.NoAnswer);
            }
            if (this.Forum.CurrentUser != question.Author && !(this.Forum.CurrentUser is IAdministrator))
            {
                throw new CommandException(Messages.NoPermission);
            }
            var previousBestAnswer = question.Answers.FirstOrDefault(ans => ans is BestAnswer);
            if (previousBestAnswer != null && previousBestAnswer != answer)
            {
                question.Answers.Add(new Answer(previousBestAnswer.Id,previousBestAnswer.Body,previousBestAnswer.Author));
                question.Answers.Remove(previousBestAnswer);
            }
            question.Answers.Add(new BestAnswer(answer.Id, answer.Body, answer.Author));
            question.Answers.Remove(answer);

            this.Forum.Output.AppendLine(string.Format(Messages.BestAnswerSuccess, answer.Id));

        }
    }
}
