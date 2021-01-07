using HomeControl.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeControl.DataAccess
{
	public class HomeControlContext : DbContext
	{
		public HomeControlContext(DbContextOptions<HomeControlContext> options) : base(options)
		{
		}

		public DbSet<Room> Rooms { get; set; }

		public DbSet<Device> Devices { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Room>().HasIndex(i => i.RoomId).IsUnique();
			
			modelBuilder.Entity<Device>().HasIndex(i => i.DeviceId).IsUnique();
		}
	}
}