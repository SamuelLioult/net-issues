using EfCoreTester.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreTester.Data
{
    class DataAccessService
    {
        #region Singleton

        public static DataAccessService Instance { get; } = new DataAccessService();

        #endregion

        #region Constructors

        private DataAccessService()
        {

        }

        #endregion

        #region Public methods

        public void AddBlog(Blog blog)
        {
            using (var db = new EfCoreTesterContext())
            {
                db.Add(blog);
                db.SaveChanges();
            }
        }

        public List<Blog> GetBlogs()
        {
            using (var db = new EfCoreTesterContext())
            {
                return db.Blogs.ToList();
            }
        }

        public void AddPost(Post post)
        {
            using (var db = new EfCoreTesterContext())
            {
                db.Add(post);
                db.SaveChanges();
            }
        }

        public List<Post> GetPosts()
        {
            using (var db = new EfCoreTesterContext())
            {
                return db.Posts.ToList();
            }
        }

        #endregion
    }
}
