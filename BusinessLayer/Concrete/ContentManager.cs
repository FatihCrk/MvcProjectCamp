using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
   public class ContentManager:IContentService
   {
       private IContentDal _contentDal;

       public ContentManager(IContentDal contentDal)
       {
           _contentDal = contentDal;
       }

       public List<Content> GetContentList()
        {
            return _contentDal.List();
        }


       public void ContentAddBl(Content content)
        {
            throw new NotImplementedException();
        }

        public Content GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void ContentDelete(Content content)
        {
            throw new NotImplementedException();
        }

        public void ContentUpdate(Content content)
        {
            throw new NotImplementedException();
        }
     

        public List<Content> GetListByWriterId(int id)
        {
            return _contentDal.List(x => x.WriterId == id);
        }

        public List<Content> GetListByHeadingId(int id)
        {
            return _contentDal.List(x => x.HeadingId == id);
        }
    }
}
