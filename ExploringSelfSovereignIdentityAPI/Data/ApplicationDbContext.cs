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

        public DbSet<Contract> Contracts { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<UserAttribute> UserAttributes { get; set; }

        public DbSet<ContractAttribute> ContractAttributes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DefaultSessionModel>().ToTable("defaultSessionModel");
            modelBuilder.Entity<DefaultSessionModel>().HasKey("Id");

            modelBuilder.Entity<DefaultIdentityModel>().ToTable("DefaultIdentityModel");
            modelBuilder.Entity<DefaultIdentityModel>().HasKey("Id");

            modelBuilder.Entity<UserDataModel>().ToTable("userDataModel");
            modelBuilder.Entity<UserDataModel>().HasKey("Id");

            modelBuilder.Entity<OrganizationCredentials>().ToTable("OrganizationCredentials");
            modelBuilder.Entity<OrganizationCredentials>().HasKey("Id");

            modelBuilder.Entity<Attribute>().ToTable("Attribute");
            modelBuilder.Entity<Attribute>().HasKey("Id");

            modelBuilder.Entity<Organization>().ToTable("Organization");
            modelBuilder.Entity<Organization>().HasKey("Id");

            modelBuilder.Entity<Contract>().ToTable("Contract");
            modelBuilder.Entity<Contract>().HasKey("Id");

            modelBuilder.Entity<ContractAttribute>().ToTable("ContractAttribute");
            modelBuilder.Entity<ContractAttribute>().HasKey("Id");

            modelBuilder.Entity<Transaction>().ToTable("Transaction");
            modelBuilder.Entity<Transaction>().HasKey("Id");

            modelBuilder.Entity<UserAttribute>().ToTable("UserAttribute");
            modelBuilder.Entity<UserAttribute>().HasKey("Id");



        }
    }
}
