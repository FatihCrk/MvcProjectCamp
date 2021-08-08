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
   public class ContactManager :IContactService
   { 
       IContactDal _contactDal;

       public ContactManager(IContactDal contactDal)
       {
           _contactDal = contactDal;
       }

       public List<Contact> GetContactList()
       {
           return _contactDal.List();
       }

        public void ContactAddBl(Contact contact)
        {
           _contactDal.Insert(contact);
        }

        public Contact GetByContactId(int id)
        {
            return _contactDal.GetById(x => x.ContactId == id);
        }

        public void ContactDelete(Contact contact)
        {
           _contactDal.Delete(contact);
        }

        public void ContactUpdate(Contact contact)
        {
           _contactDal.Update(contact);
        }
    }
}
