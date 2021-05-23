using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
   public class ContactManager :IContactService
    {
        public List<Contact> GetContactList()
        {
            throw new NotImplementedException();
        }

        public void ContactAddBl(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Contact GetByContactId(int id)
        {
            throw new NotImplementedException();
        }

        public void ContactDelete(Contact contact)
        {
            throw new NotImplementedException();
        }

        public void ContactUpdate(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
