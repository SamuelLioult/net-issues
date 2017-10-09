using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreTester.Models
{
    class Owner
    {
        public int OwnerId { get; set; }
        public string Name { get; set; }

        public List<Post> Posts { get; set; }

        public Owner()
        {
            Posts = new List<Post>();
        }
    }
}
