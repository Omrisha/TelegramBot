using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bot
{
    public class AppDbContext : DbContext
    {
        public DbSet<Phrase> Phrases { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(@"User ID=postgres;Password=o1m3r4i7;Server=localhost;Port=5432;Database=testDb;Integrated Security=true;Pooling=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phrase>()
                .HasKey(p => new { p.Id, p.Value, p.Answer });
        }
    }
}
