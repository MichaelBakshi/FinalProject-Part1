using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    public interface IBasicDb<T> where T: IPoco
    {
        void Add(T newItem);
        T GetById(int id);

        List<T> GetAll();
         void Remove(int id);
        void Update(T item_for_update);

    }
}
