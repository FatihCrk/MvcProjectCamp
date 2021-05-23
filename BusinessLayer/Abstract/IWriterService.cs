using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetWriterList();
        void HeadingAddBl(Writer writer);

        Writer GetByWriterId(int id);

        void WriterDelete(Writer writer);

        void WriterUpdate(Writer writer);
    }
}
