using CMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Infrastructure.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }
        public DbSet<Page> Pages { get; set; }
        public DbSet<PageComment> PageComments { get; set; }
        public DbSet<PageGroup> PageGroups { get; set; }
        public DbSet<Member> Members { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().HasData(new Member()
            {
                Id = 1,
                Email = "a@yahoo.com",
                IsActive = true,
                BrithDay = new DateTime(2025, 02, 23),
                ActiveCode = "",
                UserName = "a",
                Password = "20-2C-B9-62-AC-59-07-5B-96-4B-07-15-2D-23-4B-70"
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
