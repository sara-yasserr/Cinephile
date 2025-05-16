using LetterboxdProject.AccountDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LetterboxdProject.Models
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Watched> WatchedFilms { get; set; }
        public virtual DbSet<Watchlist> Watchlists { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Watchlist>()
        .HasKey(w => new { w.UserId, w.FilmId }); 

        }
    }
}
