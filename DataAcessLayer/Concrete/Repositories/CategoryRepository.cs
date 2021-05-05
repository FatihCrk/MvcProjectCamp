 using System;
using System.Collections.Generic;
 using System.Data.Entity;
 using System.Linq;
using System.Text;
using System.Threading.Tasks;
 using DataAcessLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAcessLayer.Concrete.Repositories
{
    public class CategoryRepository :IRepository<>
    {
       Context C = new Context();
      DbSet<T> _object;

        public void Delete(T p)
        {
            return _object.Remove();
            
        }

        public void Insert(T p)
        {
            return _object.Add(p);
            p.Sa
            
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public void Update(T p)
        {
            throw new NotImplementedException();
        }
    }
}


 /*
  * ToList Add ve Remove    
  */
