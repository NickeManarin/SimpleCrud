using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleCrud.Data.Context;
using SimpleCrud.Domain.Interfaces;
using SimpleCrud.Domain.Models;

namespace SimpleCrud.Data.Repository
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly DataContext _context;

        public EmpresaRepository(DataContext context)
        {
            _context = context;
        }


        public IQueryable<Empresa> GetEmpresas()
        {
            return _context.Empresas;
        }
        
        public async Task AddEmpresa(Empresa empresa)
        {
            await _context.Empresas.AddAsync(empresa);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmpresa(Empresa empresa)
        {
            _context.Empresas.Attach(empresa);
            _context.Entry(empresa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmpresa(Empresa empresa)
        {
            _context.Empresas.Remove(empresa);
            await _context.SaveChangesAsync();
        }
    }
}