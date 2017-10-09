using EfCoreTester.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreTester.Data
{
    class EfCoreTesterContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Owner> Owners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=efcoretester.sqlite");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Post>()
                .HasOne(x => x.Blog)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.BlogId);

            modelBuilder.Entity<Post>()
                .HasOne(x => x.Owner)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.OwnerId);
        }
    }
}
