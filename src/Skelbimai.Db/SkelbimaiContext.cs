using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.Design;

namespace Skelbimai.Db
{
  public class SkelbimaiContext  : DbContext
  {
    public DbSet<Core.User> Users { get; set; }
    public DbSet<Core.Skelbimas> Skelbimai { get; set; }
    public DbSet<Core.Classification> Classifications { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);
      optionsBuilder.UseSqlite($"Data Source=D:/dbs/SkelbimaiContext.db3");
    }
    protected override void OnModelCreating(ModelBuilder mb)
    {
      base.OnModelCreating(mb);
      // HasAlternateKey // isUnique
      mb.Entity<Core.Classification>().HasAlternateKey(item => new { item.UserID, item.SkelbimasID });
      // HasKey
      // Relations
      // Property
      // Owns
      // ToTable
    }
  }
}
