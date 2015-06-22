using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;

namespace ConsoleForum.Entities.Posts
{
    class BestAnswer : Answer
    {
        public BestAnswer(int id, string body, IUser author) : base(id, body, author)
        {

        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(new string('*',Delimiter));
            result.AppendLine(base.ToString());
            result.AppendLine(new string('*', Delimiter));

            return result.ToString();
        }
    }
}
