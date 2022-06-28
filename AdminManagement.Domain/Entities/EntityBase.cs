﻿using System;
using System.Collections.Generic;
using System.Text;
using AdminManagement.Domain.DomainEvents;

namespace AdminManagement.Domain.Entities
{
    public abstract class EntityBase
    {
        public long Id { get; set; }
        public EntityBase() { }
        public List<EventBase> DomainEvents = new List<EventBase>();
        //public IReadOnlyCollection<EventBase>DomainEvents { get; protected set; }
        public override bool Equals(object obj)
        {

            EntityBase entityBase = obj as EntityBase;
            if (ReferenceEquals(this, entityBase))
                return true;
            else if (ReferenceEquals(entityBase, null))
                return false;
            else if (this.GetType().Name != entityBase.GetType().Name)
                return false;
            return this.Id == entityBase.Id;
        }

        public override int GetHashCode()
        {
            return (this.GetType().FullName + this.Id).GetHashCode();
        }
    }
}
