using System.Linq;
using System.Threading.Tasks;
using SimpleCrud.Domain.Models;

namespace SimpleCrud.Domain.Interfaces
{
    public interface IEmpresaRepository
    {
        Task AddEmpresa(Empresa empresa);
        Task UpdateEmpresa(Empresa empresa);
        Task DeleteEmpresa(Empresa empresa);
        IQueryable<Empresa> GetEmpresas();
    }
}