using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer.Abstract;

namespace DataAcessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context c = new Context();
        DbSet<T> _object;
        /*Db Bağlantısı*/

        public GenericRepository() // çağırıldığında çalışacak blog - Constructor bloğu
        /*Objeye değer ataması için*/
        {
            _object = c.Set<T>();
        }





        public List<T> List()
        {
            return _object.ToList();
        }

        public void Insert(T p)
        {
            _object.Add(p);
            c.SaveChanges();

        }

        public void Update(T p)
        {
            c.SaveChanges();
        }

        public void Delete(T p)
        {
            _object.Remove(p);
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
           return _object.Where(filter).ToList();//şartımı sağlayan filtreyi getir.
        }
    }
}
