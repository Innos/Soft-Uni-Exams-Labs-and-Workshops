using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;
using ConsoleForum.Utility;

namespace ConsoleForum.Commands
{
    class LoginCommand : AbstractCommand
    {
        public LoginCommand(IForum forum) : base(forum)
        {
        }

        public override void Execute()
        {
            var users = this.Forum.Users;
            string username = this.Data[1];
            string password = PasswordUtility.Hash(this.Data[2]);

            if (users.All(u=>u.Username != username || u.Password != password))
            {
                throw new CommandException(Messages.InvalidLoginDetails);
            }

            if (this.Forum.IsLogged)
            {
                throw new CommandException(Messages.AlreadyLoggedIn);
            }

            this.Forum.CurrentUser = users.First(u => u.Username == username && u.Password == password);

            this.Forum.Output.AppendLine(
                string.Format(Messages.LoginSuccess, username)
            );
        }
    }
}
