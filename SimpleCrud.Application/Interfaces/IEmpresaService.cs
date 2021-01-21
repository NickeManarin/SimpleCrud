using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleCrud.Domain.Models;

namespace SimpleCrud.Application.Interfaces
{
    public interface IEmpresaService
    {
        Task<IEnumerable<Empresa>> GetAll();
        Task<IResponse> Add(Empresa empresa);
        Task<IResponse> Update(Empresa empresa);
        Task<IResponse> Delete(long empresaId);
    }
}