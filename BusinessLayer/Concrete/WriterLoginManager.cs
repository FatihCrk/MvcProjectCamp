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
   public class WriterLoginManager:IWriterLoginService
    {
       

        IWriterDal _writerDal;

        public WriterLoginManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer getWriter(string username, string password)
        {
            return _writerDal.GetById(x => x.WriterMail == username && x.WriterPassword == password);
        }
    }
}
