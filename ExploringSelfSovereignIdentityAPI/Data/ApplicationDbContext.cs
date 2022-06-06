using ExploringSelfSovereignIdentityAPI.Models.Default;
using ExploringSelfSovereignIdentityAPI.Models.DefaultIdentity;
using ExploringSelfSovereignIdentityAPI.Models.Entity; 
using Microsoft.EntityFrameworkCore;

namespace ExploringSelfSovereignIdentityAPI.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<DefaultSessionModel> DefaultSessionModels { get; set; }
        public DbSet<DefaultIdentityModel> DefaultIdentityModels { get; set; }

        public DbSet<UserDataModel> UserDataModels { get; set; }

        public DbSet<Attribute> Attributes { get; set; }

        public DbSet<OrganizationCredentials> OrganizationCredentials { get; set; } 

        public DbSet<Organization> Organizations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DefaultSessionModel>().ToTable("defaultSessionModel");
            modelBuilder.Entity<DefaultSessionModel>().HasKey("Id");

            modelBuilder.Entity<DefaultIdentityModel>().ToTable("DefaultIdentityModel");
            modelBuilder.Entity<DefaultIdentityModel>().HasKey("Id");

            modelBuilder.Entity<UserDataModel>().ToTable("User");
            modelBuilder.Entity<UserDataModel>().HasKey("Id");

            modelBuilder.Entity<OrganizationCredentials>().ToTable("OrganizationCredentials");
            modelBuilder.Entity<OrganizationCredentials>().HasKey("Id");

            modelBuilder.Entity<Attribute>().ToTable("Attribute");
            modelBuilder.Entity<Attribute>().HasKey("Id");

            modelBuilder.Entity<Organization>().ToTable("Organization");
            modelBuilder.Entity<Organization>().HasKey("Id");



        }
    }
}
