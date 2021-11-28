using System.Collections.Generic;
using System.Linq;
using EF.GlobalFilters.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF.GlobalFilters.EntityFramework
{
    public class GlobalFiltersDbContext: DbContext
    {
        public GlobalFiltersDbContext()
        {
            
        }
        
        public GlobalFiltersDbContext(DbContextOptions<GlobalFiltersDbContext> options)
            : base(options)
        {}
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {           
            optionsBuilder.UseSqlServer("Server=localhost;Database=GlobalFiltersDb;Trusted_Connection=True;ConnectRetryCount=0");
        }

        public DbSet<Person> Persons { get; set; }

        public DbSet<CreditCard> CreditCards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Person configurations

            modelBuilder.Entity<Person>().HasKey(p => p.Id).IsClustered(true);
            modelBuilder.Entity<Person>().Property(p => p.FirstName).IsRequired();
            modelBuilder.Entity<Person>().Property(p => p.LastName).IsRequired();
            modelBuilder.Entity<Person>().HasMany(p => p.CreditCards)
                .WithOne(c => c.Owner);

            // CreditCard configurations

            modelBuilder.Entity<CreditCard>().HasQueryFilter(c => c.IsActive);
            modelBuilder.Entity<CreditCard>().HasKey(c => c.Id).IsClustered(true);
            modelBuilder.Entity<CreditCard>().Property(c => c.Number).IsRequired();
            modelBuilder.Entity<CreditCard>().Property(c => c.IsActive).HasDefaultValue(false);
        }
        
        public static void Seed(GlobalFiltersDbContext dbContext)
        {
            if (dbContext.Persons.Any())
            {
                return;
            }
            
            dbContext.Persons.Add(new Person
            {
                FirstName = "Bob",
                LastName = "Marley",
                CreditCards = new List<CreditCard>(3)
                {
                    new CreditCard
                    {
                        Number = 4123412463378383,
                        IsActive = true
                    },
                    new CreditCard
                    {
                        Number = 6534253419877654,
                        IsActive = false
                    },
                    new CreditCard
                    {
                        Number = 1234567843218765,
                        IsActive = false
                    }
                }
            });

            dbContext.SaveChanges();
        }
    }
}