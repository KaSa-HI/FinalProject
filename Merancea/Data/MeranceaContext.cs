using Merancea.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Merancea.Data
{
    public class MeranceaContext : DbContext
    {
        public MeranceaContext(DbContextOptions<MeranceaContext> options) : base(options)
        {
        }

        public DbSet<Page> Pages { get; set; }
        public DbSet<Button> Buttons { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Page>()
				.HasMany(p => p.Buttons).WithOne(b => b.Page);
			modelBuilder.Entity<Page>()
				.HasMany(p => p.DestinationButtons).WithOne(b => b.DestinationPage);
		}
	}
}