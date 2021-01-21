using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SimpleCrud.Application.Interfaces;
using SimpleCrud.Application.Services;
using SimpleCrud.Data.Context;
using SimpleCrud.Data.Repository;
using SimpleCrud.Domain.Interfaces;

namespace SimpleCrud.Test
{
    public class DependencySetupFixture
    {
        public DependencySetupFixture()
        {
            var services = new ServiceCollection();
            services.AddDbContext<DataContext>(options => options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MVCTest;Trusted_Connection=True;MultipleActiveResultSets=true"));

            //Application services.
            services.AddTransient<IEmpresaService, EmpresaService>();

            //Data.
            services.AddTransient<IEmpresaRepository, EmpresaRepository>();
            
            //Configuration.
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", false, true);
            var configuration = builder.Build();
            
            services.AddLogging(config =>
            {
                config.AddDebug();
                config.AddConsole();
            });

            ServiceProvider = services.BuildServiceProvider();
        }

        public ServiceProvider ServiceProvider { get; private set; }
    }
}