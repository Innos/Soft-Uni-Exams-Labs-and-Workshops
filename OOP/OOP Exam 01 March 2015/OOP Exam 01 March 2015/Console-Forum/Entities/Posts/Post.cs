using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;

namespace ConsoleForum.Entities.Posts
{
    public abstract class Post : IPost
    {
        public const int Delimiter = 20;

        protected Post(int id, string body, IUser author)
        {
            this.Id = id;
            this.Body = body;
            this.Author = author;
        }
        public int Id { get; set; }
        public string Body { get; set; }
        public IUser Author { get; set; }
    }
}
