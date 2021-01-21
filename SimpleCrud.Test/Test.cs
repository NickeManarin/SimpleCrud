using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SimpleCrud.Application.Interfaces;
using SimpleCrud.Domain.Models;
using Xunit;

namespace SimpleCrud.Test
{
    public class Test : IClassFixture<DependencySetupFixture>
    {
        private readonly ServiceProvider _serviceProvider;

        public Test(DependencySetupFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
        }

        [Fact]
        public async Task CanGetCompanies()
        {
            using var scope = _serviceProvider.CreateScope();

            var service = scope.ServiceProvider.GetService<IEmpresaService>();
            var response = await service.GetAll();

            Assert.NotNull(response);
        }

        [Fact]
        public async Task CanAddCompany()
        {
            using var scope = _serviceProvider.CreateScope();

            var service = scope.ServiceProvider.GetService<IEmpresaService>();
            var response = await service.Add(new Empresa
            {
                Nome = "Test" + Path.GetRandomFileName(),
                Site = "",
                QuantidadeFuncionarios = 2
            });

            Assert.Equal(200, response.Status);
        }

        [Fact]
        public async Task CannotAddCompany()
        {
            using var scope = _serviceProvider.CreateScope();

            var service = scope.ServiceProvider.GetService<IEmpresaService>();
            var response = await service.Add(new Empresa
            {
                Nome = "Test",
                Site = "",
                QuantidadeFuncionarios = 0
            });

            Assert.Equal(400, response.Status);
        }

        [Fact]
        public async Task CanEditCompany()
        {
            using var scope = _serviceProvider.CreateScope();

            var service = scope.ServiceProvider.GetService<IEmpresaService>();
            var response = await service.Update(new Empresa
            {
                Id = 1,
                Nome = "Apple",
                Site = "",
                QuantidadeFuncionarios = 2
            });

            Assert.Equal(200, response.Status);
        }

        [Fact]
        public async Task CannotEditCompany()
        {
            using var scope = _serviceProvider.CreateScope();

            var service = scope.ServiceProvider.GetService<IEmpresaService>();
            var response = await service.Update(new Empresa
            {
                Id = 1,
                Nome = "Microsoft",
                Site = "",
                QuantidadeFuncionarios = 0
            });

            Assert.Equal(400, response.Status);
        }

        [Fact]
        public async Task CanDeleteCompany()
        {
            using var scope = _serviceProvider.CreateScope();

            var service = scope.ServiceProvider.GetService<IEmpresaService>();
            var response = await service.Delete(4);

            Assert.Equal(200, response.Status);
        }
    }
}