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

            //modelBuilder.Entity<UserDataModel>().ToTable("UserDataModel");
            //modelBuilder.Entity<UserDataModel>().HasKey("UserID");

            //modelBuilder.Entity<OrganizationCredentials>().ToTable("OrganizationCredentials");
            //modelBuilder.Entity<OrganizationCredentials>().HasKey("ID");

            //modelBuilder.Entity<Attribute>().ToTable("Attribute");
            //modelBuilder.Entity<Attribute>().HasKey("Value");



        }
    }
}
