using ExploringSelfSovereignIdentityAPI.Models.Default;
using ExploringSelfSovereignIdentityAPI.Models.DefaultIdentity;
using Microsoft.EntityFrameworkCore;

namespace ExploringSelfSovereignIdentityAPI.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<DefaultSessionModel> defaultSessionModels { get; set; }
        public DbSet<DefaultIdentityModel> DefaultIdentityModels { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DefaultSessionModel>().ToTable("defaultSessionModel");
            modelBuilder.Entity<DefaultSessionModel>().HasKey("SessionId");

            modelBuilder.Entity<DefaultIdentityModel>().ToTable("DefaultIdentityModel");
            modelBuilder.Entity<DefaultIdentityModel>().HasKey("IdentityName");
        }



    }
}
