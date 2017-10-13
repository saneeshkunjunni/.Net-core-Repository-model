using Embrace.Repository.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Embrace.Models
{
    public class ContactRegisterModel
    {
        [Required]
        [StringLength(30, ErrorMessage = "Contact Name Required")]
        public string ContactName { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Contact Name Required", MinimumLength = 10)]
        public string ContactMobile { get; set; } 
    }
    public class ContactDetailsModel:Contacts
    {
        public string UserName { get { return ApplicationUser.UserName; } }
    }
    public class ContactEditModel:Contacts
    { 
           
    }
    public class ContactListModel
    {         
        public PaginatedList<ContactDetailsModel> Contactslist { get; set; }
    }
}
