using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporsalonuBYSS.Repisotory.Abstract
{
    public interface IRepisotory<T> where T : class
    {
        void Add(T t);
        void Update(T t);
        List<T> GetAll();
        T GetID(int id);
        List<T> GetByID(int id);
        void Remove(T t);
        void RemoveByID(int id);
    }
}
