using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Linq;
using AdminManagement.Domain.Aggregates;
using AdminManagement.Domain.Entities;

namespace AdminManagement.Domain.Specification
{
    public abstract class SpecificationBase<T> where T : EntityBase, IAggregateRoot
    {
        public abstract Expression<Func<T, bool>> ToExpression();
        public List<string> Includes { get; } = new List<string>();

    }
}
