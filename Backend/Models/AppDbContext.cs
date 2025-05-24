using Microsoft.EntityFrameworkCore;

namespace CinephileProject.Models
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Showtime> Showtimes { get; set; }
        public virtual DbSet<Seat> Seats { get; set; }
        public virtual DbSet<Screen> Screens { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(m => m.Id);
                entity.Property(m => m.YouTubeTrailerId).HasMaxLength(20);
            });


            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(g => g.Id);
                entity.Property(g => g.Name).IsRequired();
            });

            // Movie-Genre Many-to-Many
            modelBuilder.Entity<Movie>()
           .HasMany(m => m.Genres)
           .WithMany(g => g.Movies)
           .UsingEntity<Dictionary<string, object>>(
          "GenreMovie",
          j => j.HasOne<Genre>()
              .WithMany()
              .HasForeignKey("GenreId")
              .OnDelete(DeleteBehavior.Cascade),
          j => j.HasOne<Movie>()
              .WithMany()
              .HasForeignKey("MovieId")
              .OnDelete(DeleteBehavior.Cascade),
          j =>
          {
              j.HasKey("GenreId", "MovieId");
              j.ToTable("GenreMovie");
          });


            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Showtimes)
                .WithOne(s => s.Movie)
                .HasForeignKey(s => s.MovieId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Screen>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Capacity).IsRequired();
            });


            modelBuilder.Entity<Seat>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Row).HasMaxLength(1).IsRequired();
                //entity.HasOne(s => s.Screen)
                //      .WithMany(sc => sc.Seats)
                //      .HasForeignKey(s => s.ScreenId)
                //      .OnDelete(DeleteBehavior.Restrict); 
            });


                modelBuilder.Entity<Showtime>(entity =>
                {
                    entity.HasKey(st => st.Id);
                    entity.Property(st => st.StartTime).IsRequired();
                    entity.HasOne(st => st.Screen)
                          .WithMany(s => s.Showtimes)
                          .HasForeignKey(st => st.ScreenId)
                          .OnDelete(DeleteBehavior.Restrict);
                });

                // User Configuration
                modelBuilder.Entity<User>(entity =>
                {
                    entity.HasKey(u => u.Id);
                    entity.Property(u => u.Username).HasMaxLength(50).IsRequired();
                    entity.Property(u => u.Email).HasMaxLength(100).IsRequired();
                    entity.Property(u => u.Role).HasMaxLength(20).IsRequired();
                });

                // Booking Configuration
                modelBuilder.Entity<Booking>(entity =>
                {
                    entity.HasKey(b => b.Id);
                    entity.HasOne(b => b.User)
                          .WithMany(u => u.Bookings)
                          .HasForeignKey(b => b.UserId)
                          .OnDelete(DeleteBehavior.Cascade); // Changed from ClientCascade

                    entity.HasOne(b => b.Showtime)
                          .WithMany(st => st.Bookings)
                          .HasForeignKey(b => b.ShowtimeId)
                          .OnDelete(DeleteBehavior.Cascade); // Changed from ClientCascade
                });

                // Payment Configuration
                modelBuilder.Entity<Payment>(entity =>
                {
                    entity.HasKey(p => p.Id);
                    entity.HasOne(p => p.Booking)
                          .WithOne(b => b.Payment)
                          .HasForeignKey<Payment>(p => p.BookingId)
                          .OnDelete(DeleteBehavior.Cascade); // Changed from ClientCascade
                });

                // Ticket Configuration
                modelBuilder.Entity<Ticket>(entity =>
                {
                    entity.HasKey(t => t.Id);


                    //entity.HasOne(t => t.Seat)
                    //      .WithMany()
                    //      .HasForeignKey(t => t.SeatId)
                    //      .OnDelete(DeleteBehavior.Restrict); 

                    //entity.HasOne(t => t.Showtime)
                    //      .WithMany()
                    //      .HasForeignKey(t => t.ShowtimeId)
                    //      .OnDelete(DeleteBehavior.Restrict); 
                });
        } 
    } 
}
