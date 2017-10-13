using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Embrace.Repository.Entity
{
    public class ApplicationUser: IdentityUser
    {
        public ICollection<Contacts> Contacts { get; set; }
    }
}
