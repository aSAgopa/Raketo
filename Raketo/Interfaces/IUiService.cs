﻿using Raketo.ViewModel;

namespace Raketo.Interfaces
{
    public interface IUiService<T> where T : class
    {
        T GetById(Guid id);
        IEnumerable<T> GetAll();
        void Add(T data);
        void Delete(Guid id);
        void Update(ProductViewModel product);
    }
}