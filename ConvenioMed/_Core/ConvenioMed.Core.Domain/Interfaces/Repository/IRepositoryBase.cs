using ConvenioMed._Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConvenioMed._Core.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<T> where T : Entity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(Guid id);
        Task<T> Insert(T entity);
        Task<bool> Delete(Guid id);
    } 
} 
