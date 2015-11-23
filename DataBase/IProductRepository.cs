using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace DataBase
{
    public interface IProductRepository<T> where T : class
    {
       IEnumerable<T> GetAll();
        T GetElementById(int id);
        void Create(T product, byte[] array);
        void Delete(int id);
        void Save();
    }
}
