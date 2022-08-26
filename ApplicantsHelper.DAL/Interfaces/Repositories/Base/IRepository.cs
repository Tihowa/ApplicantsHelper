using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicantsHelper.DAL.Interfaces.Repositories.Base
{
    public interface IRepository<T> : IDisposable where T : class
    {
        T Read(int id);
        void Create(T data);
        void Remove(int id);
        void Remove(T data);
        void Update(T data);
        List<T> ReadAll();
    }
}
