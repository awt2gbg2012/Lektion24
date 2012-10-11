using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Lektion24.Models.Entities;

namespace Lektion24.Models.Contexts
{
    public class EFDbContext : DbContext
    {
        public DbSet<News> News { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<NewsCaption> NewsCaptions { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<News>()
                        .HasRequired(n => n.PostedBy)
                        .WithMany(u => u.News)
                        .HasForeignKey(n => n.PostedByID);
        }
    }
}