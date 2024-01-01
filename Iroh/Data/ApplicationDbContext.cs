using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Iroh.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Thing> Things {  get; set; } = default!;
        public DbSet<Tag> Tags { get; set; } = default!;
        public DbSet<Upvote> Upvotes { get; set; } = default!;
        public DbSet<Description> Descriptions { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Upvote>().HasKey(upv => new { upv.UserId, upv.ThingId });
            modelBuilder.Entity<Description>().HasKey(desc => new { desc.ThingId, desc.TagId});

            modelBuilder.Entity<Thing>().HasData(
                new Thing { Id = 1, Name = "Don Quijote", Description = "Funny Spanish guy gets beat up alot of times", App = UsedInApp.History, CreatedAt = DateTime.Now, Upvotes = 0},
                new Thing { Id = 2, Name = "Niccolo Machiavelli - The Prince", Description = "Crush them enemies", App = UsedInApp.History, CreatedAt = DateTime.Parse("1/1/2000"), Upvotes = 0 }
                );
        }
    }
}
