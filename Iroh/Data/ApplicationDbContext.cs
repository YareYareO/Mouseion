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

        }
    }
}
