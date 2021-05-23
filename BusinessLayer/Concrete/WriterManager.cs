using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class WriteManager:IWriterService
    {
        public List<Writer> GetWriterList()
        {
            throw new NotImplementedException();
        }

        public void HeadingAddBl(Writer writer)
        {
            throw new NotImplementedException();
        }

        public Writer GetByWriterId(int id)
        {
            throw new NotImplementedException();
        }

        public void WriterDelete(Writer writer)
        {
            throw new NotImplementedException();
        }

        public void WriterUpdate(Writer writer)
        {
            throw new NotImplementedException();
        }
    }
}
