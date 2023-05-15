using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DbContext: Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Node> Nodes { get; set; }

        public DbSet<Journal> Journals { get; set; }

        public DbContext(DbContextOptions<DbContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Node>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name);
                entity.HasOne(x => x.Parent)
                    .WithMany(x => x.Childrens)
                    .HasForeignKey(x => x.ParentId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
