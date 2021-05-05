﻿ using System;
using System.Collections.Generic;
 using System.Data.Entity;
 using System.Linq;
 using System.Linq.Expressions;
 using System.Text;
using System.Threading.Tasks;
 using DataAcessLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAcessLayer.Concrete.Repositories
{
    public class CategoryRepository :ICategoryDal
    {
       Context c = new Context();
      DbSet<Category> _object;

      

        public List<Category> List()
        {
            return _object.ToList();
        }

        public void Insert(Category p)
        {
            _object.Add(p);
            c.SaveChanges();

        }

        public void Update(Category p)
        {
          
        }

        public void Delete(Category p)
        {
            _object.Remove(p);
            c.SaveChanges();
        }

        public List<Category> List(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}


 /*
  * ToList Add ve Remove    
  */
