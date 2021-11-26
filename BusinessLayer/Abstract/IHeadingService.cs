using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetHeadingList();
        void HeadingAddBl(Heading heading);

        Heading GetByHeadingId(int id);

        void HeadingDelete(Heading heading);

        void HeadingUpdate(Heading heading);

        List<Heading> GetListByWriter(int id);

    }
}
