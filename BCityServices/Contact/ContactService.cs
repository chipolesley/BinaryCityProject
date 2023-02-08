using BCityData;

namespace BCityServices.Contact
{
    public class ContactService : IContactService
    {
        public readonly BCityDBContext _db;

        public ContactService(BCityDBContext dBContext)
        {
          _db = dBContext;
        }
        public ServiceResponse<BCityData.Models.Contact> AddContact(BCityData.Models.Contact contact)
        {
            try
            {
                _db.Contacts.Add(contact);
                _db.SaveChanges();
                return new ServiceResponse<BCityData.Models.Contact>()
                {
                    IsSuccess = true,
                    Message = $"Contact ({ contact.Email}) was successfully added",
                    Data = contact
                };
            }
            catch
            {
                return new ServiceResponse<BCityData.Models.Contact>()
                {
                    IsSuccess = true,
                    Message = $"Faild to create Contact ({ contact.Email})",
                    Data = contact
                };
            }
        }

        public ServiceResponse<List<BCityData.Models.Contact>> GetContacts()
        {
            var contactList = _db.Contacts.ToList();
            if (contactList.Any())
            {
                return new ServiceResponse<List<BCityData.Models.Contact>>()
                {
                    IsSuccess = true,
                    Message = "Contacts were successfully loaded.",
                    Data = contactList
                };
            }
            return new ServiceResponse<List<BCityData.Models.Contact>>()
            {
                IsSuccess = false,
                Message = "No contact(s) found.",
                Data = contactList
            };
        }
    }
}
