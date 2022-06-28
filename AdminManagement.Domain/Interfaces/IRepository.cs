using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AdminManagement.Domain.Entities;
using AdminManagement.Domain.Aggregates;
using AdminManagement.Domain.Specification;

namespace AdminManagement.Domain.Interfaces
{
    public interface IRepository <T> where T : EntityBase, IAggregateRoot
    {
        T Add(T item);
        T Remove(T item);
        T Update(T item);
        IReadOnlyCollection<T> Get();
        T GetById(long id);
        IReadOnlyCollection<T> GetBySpec(SpecificationBase<T> spec);
        Task<int> SaveAsync();
    }
}
