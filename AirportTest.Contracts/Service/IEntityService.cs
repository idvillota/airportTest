using System;
using System.Collections.Generic;

namespace AirportTest.Contracts.Service
{
    public interface IEntityService<T>
    {
        IList<T> GetAll();
        T GetById(Guid id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
