using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Embrace.Models;
using Embrace.Repository.Entity;
using Embrace.Services.Interface;
using Embrace.Repository;

namespace Embrace.Services.Services
{
    public class ContactService : IContactService
    {
        IUnitOfWork unitOfWork; 
        public ContactService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void AddContact(Contacts model)
        {
            unitOfWork.ContactRepository.Insert(model);
            unitOfWork.Save();
        }

        public void EditContact(ContactEditModel model)
        {

            unitOfWork.ContactRepository.Update((Contacts)model);
            unitOfWork.Save();
        }

        public ContactDetailsModel GetContactDetails(object id)
        {
            var result = unitOfWork.ContactRepository.Get(filter: x=>x.ContactId == (int)id)
                .Select(x => new ContactDetailsModel() {
                    ContactId = x.ContactId,
                    ContactName = x.ContactName,
                    ContactMobile = x.ContactMobile,
                    ApplicationUser = x.ApplicationUser,
                    UserId = x.UserId
            }).FirstOrDefault();
            return result;
        }

        public ContactEditModel GetContactEditModel(object id)
        {
            var result = unitOfWork.ContactRepository.Get(filter: x => x.ContactId == (int)id)
                .Select(x => new ContactEditModel()
                {
                    ContactId = x.ContactId,
                    ContactName = x.ContactName,
                    ContactMobile = x.ContactMobile, 
                    UserId = x.UserId
                }).FirstOrDefault();
            return result;
        }

        public ContactListModel GetContactList(int page, int pageSize)
        {
            var result = unitOfWork.ContactRepository.Get()
                .Select(x => new ContactDetailsModel()
                {
                    ContactId = x.ContactId,
                    ContactName = x.ContactName,
                    ContactMobile = x.ContactMobile,
                    ApplicationUser = x.ApplicationUser,
                    UserId = x.UserId
                }).ToPagedList(page, pageSize);
            return new ContactListModel() { Contactslist = result };
        }
    }
}
