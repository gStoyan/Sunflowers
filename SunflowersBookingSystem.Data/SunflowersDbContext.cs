namespace SunflowersBookingSystem.Data
{
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

        public DbSet<User> Users{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(ConnectionString);
            base.OnConfiguring(options);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasData(new User { Id = 1, Name = "Stoyan"},new User { Id = 2, Name = "Elisabeth"});

        }
    }
}
