using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreTester.Models
{
    class Post
    {
        public int PostId { get; set; }
        public string Message { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }

        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
    }
}
