using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;

namespace ConsoleForum.Commands
{
    class OpenQuestionCommand : AbstractCommand
    {
        public OpenQuestionCommand(IForum forum) : base(forum)
        {
        }

        public override void Execute()
        {
            var questions = this.Forum.Questions;
            int id = int.Parse(Data[1]);
            var question = questions.FirstOrDefault(quest => quest.Id == id);
            if (question == null)
            {
                throw new CommandException(Messages.NoQuestion);
            }

            this.Forum.CurrentQuestion = question;
            this.Forum.Output.Append(question.ToString());
        }
    }
}
