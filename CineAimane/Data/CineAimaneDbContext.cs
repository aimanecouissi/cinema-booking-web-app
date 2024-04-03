using CineAimane.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CineAimane.Data
{
	public class CineAimaneDbContext : IdentityDbContext
	{
		public CineAimaneDbContext() { }
		public CineAimaneDbContext(DbContextOptions<CineAimaneDbContext> options) : base(options) { }
		public DbSet<Movie> Movies { get; set; }
		public DbSet<Showtime> Showtimes { get; set; }
		public DbSet<Showdate> Showdates { get; set; }
		public DbSet<Reservation> Reservations { get; set; }
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.Seed();
		}
	}
}
