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
    public class ImageFileManager : IImageFileService
    {
         IImageDal _iImageDal;

         public ImageFileManager(IImageDal iImageDal)
         {
             _iImageDal = iImageDal;
         }

        public ImageFile GetByImageId(int id)
        {
            return _iImageDal.Get(x => x.ImageId == id);
        }

        public List<ImageFile> GetImageList()
        {
            return _iImageDal.List();
        }
    }
}
