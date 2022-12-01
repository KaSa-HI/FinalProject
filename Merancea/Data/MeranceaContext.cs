using Merancea.Models;
using Microsoft.EntityFrameworkCore;

namespace Merancea.Data
{
    public class MeranceaContext : DbContext
    {
        public MeranceaContext(DbContextOptions<MeranceaContext> options) : base(options)
        {
        }

        public DbSet<Page> Pages { get; set; }
        public DbSet<Button> Buttons { get; set; }
    }
}