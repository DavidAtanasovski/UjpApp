using Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Data
{
    public class UjpDbContext : DbContext
    {
        public UjpDbContext(DbContextOptions<UjpDbContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<TaxPayer> TaxPayers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<DDV> DDVs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(new List<Country>
            {
                new Country
                {
                    Id = 1,
                    Name = "Macedonia",
                    TaxReturnPolicy = 0.15
                },
                new Country
                {
                    Id = 2,
                    Name = "USA",
                    TaxReturnPolicy = 0.05
                },
                new Country
                {
                    Id = 3,
                    Name = "Great Britain",
                    TaxReturnPolicy = 0.005
                }
            });

            modelBuilder.Entity<TaxPayer>().HasData(new List<TaxPayer>
            {
                new TaxPayer
                {
                    Id = 1,
                    FirstName = "Petar",
                    LastName = "Petrevski",
                    CountryId = 1
                },
                new TaxPayer
                {
                    Id = 2,
                    FirstName = "Igor",
                    LastName = "Igorovski",
                    CountryId = 1
                },
                new TaxPayer
                {
                    Id = 3,
                    FirstName = "Kire",
                    LastName = "Kocev",
                    CountryId = 1
                },
                new TaxPayer
                {
                    Id = 4,
                    FirstName = "ALeksandar",
                    LastName = "Aleksandrovski",
                    CountryId = 1
                },
                new TaxPayer
                {
                    Id = 5,
                    FirstName = "Franklin",
                    LastName = "Short",
                    CountryId = 2
                },
                new TaxPayer
                {
                    Id = 6,
                    FirstName = "George",
                    LastName = "Wilkerson",
                    CountryId = 2
                },
                new TaxPayer
                {
                    Id = 7,
                    FirstName = "Kyle",
                    LastName = "McBride",
                    CountryId = 2
                },
                new TaxPayer
                {
                    Id = 8,
                    FirstName = "Joseph",
                    LastName = "Hudkins",
                    CountryId = 2
                },
                 new TaxPayer
                {
                    Id = 9,
                    FirstName = "Ben",
                    LastName = "Duncan",
                    CountryId = 3
                },
                new TaxPayer
                {
                    Id = 10,
                    FirstName = "Anthony",
                    LastName = "Marshall",
                    CountryId = 3
                },
                new TaxPayer
                {
                    Id = 11,
                    FirstName = "Jordan",
                    LastName = "Murray",
                    CountryId = 3
                }
            });

            modelBuilder.Entity<DDV>().HasData(new List<DDV>
            {
                new DDV
                {
                    Id = 1,
                    Tax = 0
                },
                new DDV
                {
                    Id = 2,
                    Tax = 0.05
                },
                new DDV
                {
                    Id = 3,
                    Tax = 0.18
                }
            });
        }
    }
}
