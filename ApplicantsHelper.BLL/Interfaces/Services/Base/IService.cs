using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicantsHelper.BLL.Interfaces.Services.Base
{
    public interface IService<T> : IDisposable where T : class
    {
        void Create(T data);
        T Read(int id);
        void Remove(int id);
        void Remove(T data);
        void Update(T data);
        List<T> ReadAll();
    }
}
