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
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }


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
            builder.Entity<Reservation>()
                .HasKey(r => r.Id);
            builder.Entity<Room>()
                .HasKey(r => r.Id);

            builder.Entity<User>()
                .HasMany(u => u.Reservations)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Entity<Reservation>()
                .HasMany(r => r.Rooms)
                .WithMany(r => r.Reservations)
                .UsingEntity(j => j.ToTable("ReservationRooms"));
            //Seed database --->
            var reservation1 = new Reservation { Id = 1, StartDate = DateTime.Now, EndDate = DateTime.UtcNow, ArriveTime = DateTime.Today, Comment = "It was aight", UserId = 3 };
            var reservation2 = new Reservation { Id = 2, StartDate = DateTime.Now, EndDate = DateTime.UtcNow, ArriveTime = DateTime.Today, Comment = "same", UserId = 3 };

            builder.Entity<User>()
                .HasData(
                new User { Id = 1, Email = "my@email.com", FirstName = "Sa", SecondName = "An", Country = "Bulgaria", Phone = "012345678" },
                new User { Id = 2, Email = "my@email.com", FirstName = "E", SecondName = "I", Country = "Bulgaria", Phone = "012345678" },
                new User { Id = 3, Email = "testing@res.bg", FirstName = "Se", SecondName = "Ed", Country = "Bulgaria", Phone = "012345678" });

            builder.Entity<Room>()
                .HasData(new Room() { Id = 1, Number = 1, Capacity = 2, Booked = true },
                new Room() { Id = 2, Number = 2, Capacity = 2, Booked = false },
                new Room() { Id = 3, Number = 3, Capacity = 4, Booked = false },
                new Room() { Id = 4, Number = 4, Capacity = 4, Booked = false },
                new Room() { Id = 5, Number = 5, Capacity = 4, Booked = false });

            builder.Entity<Reservation>()
                .HasData(reservation1, reservation2);
        }
    }
}
