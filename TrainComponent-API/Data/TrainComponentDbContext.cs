using Microsoft.EntityFrameworkCore;

namespace TrainComponent.Data
{
    public class TrainComponentDbContext : DbContext
    {
        public DbSet<Models.TrainComponent> TrainComponents { get; set; }

        public TrainComponentDbContext()
        {
            
        }

        public TrainComponentDbContext(DbContextOptions<TrainComponentDbContext> options) : base(options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.TrainComponent>()
                .HasIndex(i => i.UniqueNumber)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
