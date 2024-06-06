using IveApi.Models;
using Microsoft.EntityFrameworkCore;

namespace IveApi
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}

		public DbSet<Artist> Artists { get; set; }
		public DbSet<Venue> Venues { get; set; }
		public DbSet<Event> Events { get; set; }
		public DbSet<Performance> Performances { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//Defines relationships between models.
			modelBuilder.Entity<Performance>()
				.HasKey(p => new { p.ArtistId, p.EventId });
			modelBuilder.Entity<Performance>()
				.HasOne(p => p.Artist)
				.WithMany(a => a.Performances)
				.HasForeignKey(p => p.ArtistId);
			modelBuilder.Entity<Performance>()
				.HasOne(p => p.Event)
				.WithMany(e => e.Performances)
				.HasForeignKey(p => p.EventId);
			modelBuilder.Entity<Event>()
				.HasOne(e => e.Venue)
				.WithMany(v => v.Events)
				.HasForeignKey(e => e.VenueId);

			//Seeds data
			modelBuilder.Entity<Venue>()
				.HasData(new Venue
				{
					Id = 2,
					Name = "Pub",
					Capacity = 200,
					MinLat = 0.345,
					MinLong = 0.43534,
					MaxLong = 3.556,
					MaxLat = 3.435
				});

            modelBuilder.Entity<Venue>()
				.HasData(new Venue
				{
					Id = 3,
					Name = "Cocktail Bar",
					Capacity = 300,
					MinLat = 0.32432,
					MinLong = 0.4324,
					MaxLong = -3.24234,
					MaxLat = -3.24
				});

            modelBuilder.Entity<Artist>()
				.HasData(new Artist
				{
					Id = 1,
					Name = "Dua Lipa",
					Genre = "Pop"
				});

            modelBuilder.Entity<Artist>()
				.HasData(new Artist
				{
					Id = 2,
					Name = "Taylor Swift",
					Genre = "Pop"
				});

            modelBuilder.Entity<Artist>()
				.HasData(new Artist
				{
					Id = 3,
					Name = "Elton John",
					Genre = "Pop"
				});

            modelBuilder.Entity<Event>()
				.HasData(new Event
				{
					Id = 1,
					Name = "Open Mic Night",
					Date = new DateOnly(2024, 10, 5),
					VenueId = 2
				});

            modelBuilder.Entity<Event>()
				.HasData(new Event
				{
					Id = 2,
					Name = "Talent Show",
					Date = new DateOnly(2024, 8, 20),
					VenueId = 3
				});

            modelBuilder.Entity<Event>()
				.HasData(new Event
				{
					Id = 3,
					Name = "Pop Night",
					Date = new DateOnly(2024, 9, 15),
					VenueId = 2
				});

            modelBuilder.Entity<Performance>()
				.HasData(new Performance
				{
					ArtistId = 2,
					EventId = 2
				});

            modelBuilder.Entity<Performance>()
				.HasData(new Performance
				{
					ArtistId = 3,
					EventId = 2
				});

            modelBuilder.Entity<Performance>()
				.HasData(new Performance
				{
					ArtistId = 1,
					EventId = 3
				});

            modelBuilder.Entity<Performance>()
				.HasData(new Performance
				{
					ArtistId = 2,
					EventId = 3
				});
        }
    }
}

