﻿ using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox(string p);
        List<Message> GetListSendbox(string p);

        List<Message> GetTheDraftMessage();

        void MessageAddBl(Message message);

        Message GetById(int id);

        void MessageDelete(Message message);

        void MessageUpdate(Message message);

        
    }
}
