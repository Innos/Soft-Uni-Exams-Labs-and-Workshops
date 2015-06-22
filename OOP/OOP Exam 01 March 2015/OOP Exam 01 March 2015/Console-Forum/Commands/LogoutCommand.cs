using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;

namespace ConsoleForum.Commands
{
    class LogoutCommand : AbstractCommand
    {
        public LogoutCommand(IForum forum) : base(forum)
        {
        }

        public override void Execute()
        {
            if (this.Forum.IsLogged == false)
            {
                throw new CommandException(Messages.NotLogged);
            }
            this.Forum.CurrentUser = null;
            this.Forum.CurrentQuestion = null;

            this.Forum.Output.AppendLine(Messages.LogoutSuccess);
        }
    }
}
