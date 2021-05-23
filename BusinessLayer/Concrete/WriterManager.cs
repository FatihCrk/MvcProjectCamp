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
    public class WriterManager:IWriterService
    {
        private IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }


        public List<Writer> GetWriterList()
        {
            return _writerDal.List();
        }

        public void WriterAddBl(Writer writer)
        {
            _writerDal.Insert(writer);
        }

        public Writer GetByWriterId(int id)
        {
            return _writerDal.GetById(x => x.WriterId == id);
        }

        public void WriterDelete(Writer writer)
        {
           _writerDal.Delete(writer);
        }

        public void WriterUpdate(Writer writer)
        {
           _writerDal.Update(writer);
        }
    }
}
