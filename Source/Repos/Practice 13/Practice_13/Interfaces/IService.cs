using System;
using System.Collections.Generic;

namespace Practice_13.Interfaces
{
    public interface IService<T>
    {
        void Add(T item);
        List<T> GetAll();
        T GetById(Guid id);
        void Update(T item);
        void Delete(T item);
    }
}