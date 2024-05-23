using System.Collections.Generic;
using System.Data.Common;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using MilaLaba.Models;

namespace MilaLaba
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Person> people { get; set; }
        public DbSet<Plant> plants { get; set; }
        public DbSet<Basket> baskets { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Устанавливаем связь между таблицами Product и ProductCategories
            modelBuilder.Entity<Person>()
                .HasMany(e => e.Basket)
                .WithOne(e => e.Person)
                .HasForeignKey(e => e.IdPerson).IsRequired();
            modelBuilder.Entity<Plant>()
                .HasMany(e => e.Basket)
                .WithOne(e => e.Plant)
                .HasForeignKey(e => e.IdPlant).IsRequired();
        }

    }
}
