using BCityServices.Contact;
using Microsoft.AspNetCore.Mvc;

namespace BCityWeb.Controllers
{
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _IContactService;
        public ContactController(IContactService IContactService)
        {
            _IContactService = IContactService;
        }

        /// <summary>
        /// Get all Clients
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/contacts")]
        public IActionResult GetClients()
        {
            var contacts = _IContactService.GetContacts();
            return Ok(contacts);
        }
        /// <summary>
        /// Add a Client
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        [HttpPost("api/contact")]
        public IActionResult AddClients(BCityData.Models.Contact contact)
        {
            var contacts = _IContactService.AddContact(contact);
            return Ok(contacts);
        }

    }
}
