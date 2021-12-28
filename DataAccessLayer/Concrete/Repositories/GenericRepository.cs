 using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DataAccessLayer.Abstract;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context c = new Context();/*Db Bağlantısı*/
        DbSet<T> _object;
        

        public GenericRepository() // çağırıldığında çalışacak blog - Constructor bloğu
        /*Objeye değer ataması için*/
        {
            _object = c.Set<T>();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter); //bir dizi veya listede sadece 1 değer geri döndürecek metodur.
        }

        public void Insert(T p)
        {

            var addedEntity = c.Entry(p);
            addedEntity.State = EntityState.Added;
            //_object.Add(p);
            c.SaveChanges();

        }

        public void Update(T p)
        {
            var updatedEntity = c.Entry(p);
            updatedEntity.State = EntityState.Modified;
            c.SaveChanges();
        }

        public void Delete(T p)
        {
            var deletedEntity = c.Entry(p);
            deletedEntity.State = EntityState.Deleted;

            //_object.Remove(p);
            c.SaveChanges();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
           return _object.Where(filter).ToList();//şartı sağlayan filtreyi getir.
        }
    }
}
