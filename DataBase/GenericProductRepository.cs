using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;


namespace DataBase
{

    public abstract class GenericProductRepository<T> : IProductRepository<T>
          where T : class
    {
        protected DbContext _entities;
        protected readonly IDbSet<T> _dbset;

        public GenericProductRepository(DbContext context)
        {
            _entities = context;
            _dbset = context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {

            return _dbset.AsEnumerable<T>();
        }

        public T GetElementById(int Id)
        {
            return _dbset.Find(Id);
        }

        public virtual void Create(T product, byte[] array)
        {
             _dbset.Add(product);
        }

        public void Delete(int id)
        {
           _dbset.Remove(GetElementById(id));
           Save();
        }

        public void Save()
        {
            _entities.SaveChanges();
        }

    }
}
