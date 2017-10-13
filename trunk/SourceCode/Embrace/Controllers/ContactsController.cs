using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Embrace.Services.Interface;
using Embrace.Repository.Entity;
using Embrace.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Embrace.Controllers
{
    [Authorize]
    public class ContactsController : Controller
    {

        private IContactService contactService;
        private UserManager<ApplicationUser> _userManager;
        public ContactsController(IContactService contactService , UserManager<ApplicationUser> userManager)
        {
            this.contactService = contactService;
            this._userManager = userManager;
        }
        public IActionResult Index(int? page)
        {
            return View(contactService.GetContactList(page ?? 1, 4));
        }
        public IActionResult AddContact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddContact(ContactRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var result = new Contacts() { ContactMobile=model.ContactMobile, ContactName = model.ContactName, UserId = _userManager.GetUserId(User) };
                contactService.AddContact(result);
                return RedirectToAction("Index");
            }
            return View();
        }


    }
}