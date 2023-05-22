using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Persistence.Context
{
	public class EfContext : DbContext
	{
		public DbSet<Product> Product { get; set; }

		public EfContext(DbContextOptions<EfContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Product>()
				.HasKey(p => p.ID);

			modelBuilder.Entity<Product>()
				.Property(p => p.Name);

			modelBuilder.Entity<Product>()
				.Property(p => p.Price);

			base.OnModelCreating(modelBuilder);
		}
	}
}
