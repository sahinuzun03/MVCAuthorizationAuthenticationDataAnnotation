using KD12MVCDataAnnotation.Models;
using Microsoft.EntityFrameworkCore;

namespace KD12MVCDataAnnotation.Contexts
{
    public class HastaneDbContext : DbContext
    {
        public HastaneDbContext(DbContextOptions<HastaneDbContext> options) : base(options)
        {

        }

        public DbSet<Hastane> Hastanes { get; set; }
        public DbSet<Calisan> Calisans { get; set; }
        

    }
}
