using DAL_Blogging.ModelEnity;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL_Blogging
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comments> Comments { get; set; }
    }
}
