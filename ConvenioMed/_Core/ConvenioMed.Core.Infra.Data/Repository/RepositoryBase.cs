using ConvenioMed._Core.Domain.Entities;
using ConvenioMed._Core.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConvenioMed._Core.Infra.Data.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : Entity
    {
        public async Task<bool> Delete(Guid id)
        {
            return await Task.FromResult(true);
        } 

        public async Task<T> Get(Guid id)
        {
            return await Task.FromResult((new Entity { Id = id, DataCadastro = DateTime.Now }  as T));
        } 

        public async Task<IEnumerable<T>> GetAll()
        {
            return await Task.FromResult(new List<T> { } );
        } 

        public async Task<T> Insert(T entity)
        {
            return await Task.FromResult(entity);
        } 
    } 
} 
