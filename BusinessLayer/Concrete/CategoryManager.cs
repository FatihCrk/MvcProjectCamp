using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    { 


        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAddBl(Category category)
        {
            _categoryDal.Insert(category);
        }

        public List<Category> GetCategoryList()
        {
            return _categoryDal.List();
        }  
        
      
    }




}
