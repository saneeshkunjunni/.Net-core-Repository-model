using Embrace.Models;
using Embrace.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Embrace.Services.Interface
{
    public interface IContactService
    {
        void AddContact(Contacts model);
        void EditContact(ContactEditModel model);
        ContactEditModel GetContactEditModel(object id);
        ContactListModel GetContactList(int page, int pageSize);
        ContactDetailsModel GetContactDetails(object id);
    }
}
