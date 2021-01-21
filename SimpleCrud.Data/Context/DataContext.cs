using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SimpleCrud.Domain.Models;

namespace SimpleCrud.Data.Context
{
    public class DataContext : DbContext
    {
        //Migrations:
        //Add-Migration "Version0001" -Context DataContext -verbose -Project SimpleCrud.Data
        //Remove-Migration -Context DataContext -verbose -Project SimpleCrud.Data

        //Common SQL commands:
        //Open SQL Server Object Explorer, right click the server, click on "New query".
        //Drop Database MVCTeste;

        public DbSet<Empresa> Empresas { get; set; }


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
#if DEBUG
            options.EnableSensitiveDataLogging();
#endif

            base.OnConfiguring(options);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Seed data

            //Users.
            var empresas = new List<Empresa>
            {
                new Empresa { Id = 1, Nome = "Apple", Site = "www.apple.com", QuantidadeFuncionarios = 2 },
                new Empresa { Id = 2, Nome = "Google", Site = "www.google.com", QuantidadeFuncionarios = 55 },
                new Empresa { Id = 3, Nome = "Microsoft", Site = "www.microsoft.com", QuantidadeFuncionarios = 120 }
            };

            builder.Entity<Empresa>().HasData(empresas);

            #endregion

            base.OnModelCreating(builder);
        }
    }
}