using AdminManagement.Domain.Interfaces;
using System;
using Microsoft.EntityFrameworkCore;
using AdminManagement.Domain.Aggregates;
using AdminManagement.Domain.Entities;
using AdminManagement.Domain.Specification;
using System.Collections.Generic;
using AdminManagement.Infrastructure.Data.Contexts;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace AdminManagement.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase, IAggregateRoot
    {
        private readonly AdminMAnagementContext context;

        public Repository(AdminMAnagementContext context)
        {
            this.context = context;
        }

        public T Add(T item)
        {

            return context.Add(item).Entity;
        }

        public IReadOnlyCollection<T> Get()
        {
            var Data = context.Set<T>().ToList();
            return Data.AsReadOnly();
        }

        public T GetById(long id)
        {
            return context.Set<T>().Find(id);
        }

        public IReadOnlyCollection<T> GetBySpec(SpecificationBase<T> spec)
        {
            IQueryable<T> Set = context.Set<T>();
            foreach (var include in spec.Includes)
                Set = Set.Include(include);
            var Query = Set.Where(spec.ToExpression().Compile());
            return Query.ToList().AsReadOnly();
        }

        public T Remove(T item)
        {
            return context.Remove(item).Entity;
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }

        public T Update(T item)
        {
            return context.Update(item).Entity;
        }
    }
}
