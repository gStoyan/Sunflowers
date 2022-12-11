namespace SunflowersBookingSystem.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.EntityFrameworkCore;
    using SunflowersBookingSystem.Data.Models;

    public class SunflowersDbContext : DbContext
    {
        private const string ConnectionString = "Server=.;Database=SunflowersDB;Integrated Security=True;Trusted_Connection=True;MultipleActiveResultSets=true";

        public SunflowersDbContext()
        {
        }
        public SunflowersDbContext(DbContextOptions<SunflowersDbContext> options)
               : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(ConnectionString);
            base.OnConfiguring(options);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Ignore<IdentityUserLogin>();
            builder.Ignore<IdentityUserRole>();
            builder.Ignore<IdentityUserClaim>();

            builder.Entity<User>()
                .HasKey(u => u.Id);
            builder.Entity<User>()
                .HasData(
                new User { Id = 1, Email = "my@email.com", FirstName = "Stoyan", SecondName = "Grancharov" },
                new User { Id = 2, Email = "my@email.com", FirstName = "E", SecondName = "I" });
        }
    }
}
