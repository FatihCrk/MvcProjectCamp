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
    public class DraftManager:IDraftService
    {
         IDraftDal _draftDal;

        public DraftManager(IDraftDal draftDal)
        {
            _draftDal = draftDal;
        }

        public List<Draft> GetDraftList()
        {
            return _draftDal.List();
        }

        public void DraftAddBl(Draft draft)
        {
            _draftDal.Insert(draft);
        }

        public Draft GetByDraftId(int id)
        {
            return _draftDal.GetById(x => x.DraftID == id);
        }

        public void DraftDelete(Draft draft)
        {
            _draftDal.Delete(draft);
        }

        public void DraftUpdate(Draft draft)
        {
            _draftDal.Update(draft);
        }
    }
}
