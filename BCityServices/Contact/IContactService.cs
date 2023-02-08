using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCityServices.Contact
{
    public interface IContactService
    {
        public ServiceResponse<BCityData.Models.Contact> AddContact(BCityData.Models.Contact contact);
        public ServiceResponse<List<BCityData.Models.Contact>> GetContacts();
    }
}
