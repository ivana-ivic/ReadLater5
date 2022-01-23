using Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ReadLaterDataContext : IdentityDbContext

    {
        public ReadLaterDataContext(DbContextOptions<ReadLaterDataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Bookmarks)
                .WithOne()
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Bookmark>()
                .HasOne(e => e.Category)
                .WithMany(e => e.Bookmarks)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Bookmark> Bookmarks { get; set; }
    }
}
