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
    public class HeadingManager:IHeadingService
    {
        IHeadingDal _headingDal;


        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public List<Heading> GetHeadingList()
        {
            return _headingDal.List();
        }

        public void HeadingAddBl(Heading heading)
        {
            _headingDal.Insert(heading);
        }

        public Heading GetByHeadingId(int id)
        {
            throw new NotImplementedException();
        }

        public void HeadingDelete(Heading heading)
        {
            throw new NotImplementedException();
        }

        public void HeadingUpdate(Heading heading)
        {
            throw new NotImplementedException();
        }
    }
}
