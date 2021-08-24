using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
   public interface IDraftService
    {
        List<Draft> GetDraftList();
        void DraftAddBl(Draft draft);

        Draft GetByDraftId(int id);

        void DraftDelete(Draft draft);

        void DraftUpdate(Draft draft);
    }
}
