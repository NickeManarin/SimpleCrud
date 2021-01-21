using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleCrud.Application.Interfaces;
using SimpleCrud.Application.Models;
using SimpleCrud.Domain.Interfaces;
using SimpleCrud.Domain.Models;

namespace SimpleCrud.Application.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _repository;
        private readonly ILogger<EmpresaService> _logger;

        public EmpresaService(IEmpresaRepository repository, ILogger<EmpresaService> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        
        
        public async Task<IEnumerable<Empresa>> GetAll()
        {
            try
            {
                return await _repository.GetEmpresas().ToListAsync();
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, "Error while getting all companies.", e.Data);
                return null;
            }
        }

        public async Task<IResponse> Add(Empresa empresa)
        {
            try
            {
                if ((empresa.Nome ?? "").Length < 2)
                    return new SimpleResponse(400, 100, "O nome da empresa deve ser maior que 2 caracteres.");

                if (empresa.QuantidadeFuncionarios < 1)
                    return new SimpleResponse(400, 101, "A quantidade de funcionários deve ser maior que 0.");

                if (await _repository.GetEmpresas().AnyAsync(f => f.Nome == empresa.Nome.Trim()))
                    return new SimpleResponse(400, 102, "Já existe uma empresa com o mesmo nome.");

                await _repository.AddEmpresa(empresa);

                return new SimpleResponse(200, 200, "Empresa adicionada.");
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, "Error while adding company.", e.Data);
                return new SimpleResponse(500, 500, "Erro ao adicionar empresa.");
            }
        }

        public async Task<IResponse> Update(Empresa empresa)
        {
            try
            {
                if ((empresa.Nome ?? "").Length < 2)
                    return new SimpleResponse(400, 100, "O nome da empresa deve ser maior que 2 caracteres.");

                if (empresa.QuantidadeFuncionarios < 1)
                    return new SimpleResponse(400, 101, "A quantidade de funcionários deve ser maior que 0.");

                if (await _repository.GetEmpresas().AnyAsync(f => f.Id != empresa.Id && f.Nome == empresa.Nome.Trim()))
                    return new SimpleResponse(400, 102, "Já existe uma empresa com o mesmo nome.");

                await _repository.UpdateEmpresa(empresa);

                return new SimpleResponse(200, 200, "Empresa atualizada.");
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, "Error while updating company.", e.Data);
                return new SimpleResponse(500, 500, "Erro ao atualizar empresa.");
            }
        }

        public async Task<IResponse> Delete(long empresaId)
        {
            try
            {
                var empresa = await _repository.GetEmpresas().FirstOrDefaultAsync(f => f.Id == empresaId);

                if (empresa == null)
                    return new SimpleResponse(200, 201, "A empresa já não existe na base de dados.");

                await _repository.DeleteEmpresa(empresa);

                return new SimpleResponse(200, 200, "Empresa atualizada.");
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, "Error while removing company.", e.Data);
                return new SimpleResponse(500, 500, "Erro ao remover empresa.");
            }
        }
    }
}