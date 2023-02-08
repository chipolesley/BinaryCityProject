using BCityData;
using BCityData.Models;
using BCityData.Models.ViewModel;

namespace BCityServices.ClientContactAssignment
{
    public class ClientContactAssService : IClientContactAssService
    {
        public readonly BCityDBContext _db;
        public ClientContactAssService(BCityDBContext dBContext)
        {
            _db = dBContext;
        }
        public ServiceResponse<ClientContactViewModel> AddClientContactAssignment(ClientContactViewModel clientContactViewModel)
        {
            //find the client
            var client = _db.Clients.Where(x => x.ClientCode == clientContactViewModel.Client.ClientCode).FirstOrDefault();
            //find the contact
            var contact = _db.Contacts.Where(x => x.Email == clientContactViewModel.Contact.Email).FirstOrDefault();

            //Link the client with the contact
            if(client != null && contact != null)
            {
                try
                {
                    var contactAssignment = new ContactAssignment()
                    {
                        ClientId = client.Id,
                        ContactId = contact.Id
                    };

                    _db.ContactAssignments.Add(contactAssignment);
                    _db.SaveChanges();

                    //count number of assigned clients
                    var clientAssignedCount = _db.ContactAssignments.Where(x => x.ClientId == client.Id).Count();
                    //update number of linked contacts
                    client.NumberOfLinkedContacts = clientAssignedCount;

                    //count number of assigned contacts
                    var contactAssignedCount = _db.ContactAssignments.Where(x => x.ContactId == contact.Id).Count();
                    //update the number of linked Clients
                    contact.NumberOfLinkedClients = contactAssignedCount;
                    //save the assignment counts
                    _db.SaveChanges();

                    return new ServiceResponse<ClientContactViewModel>()
                    {
                        IsSuccess = true,
                        Message = $"Succefully linked Contact ({contact.Email} to Client ({client.ClientCode})"
                    };
                }
                catch
                {
                    return new ServiceResponse<ClientContactViewModel>()
                    {
                        IsSuccess = false,
                        Message = $"Failed to linked Contact ({contact.Email} to Client ({client.ClientCode})"
                    };
                }
            }

            return new ServiceResponse<ClientContactViewModel>()
            {
                IsSuccess = false,
                Message = "Falied To link Contact to Client for one or both are not found"
            };

        }

        public ServiceResponse<ClientContactViewModel> DeleteClientContactAssignment(ClientContactViewModel clientContactViewModel)
        {
            //get client id
              var client = _db.Clients.Where(x=>x.ClientCode == clientContactViewModel.Client.ClientCode).FirstOrDefault();
            //get contactId
            var contact = _db.Contacts.Where(x=>x.Email == clientContactViewModel.Contact.Email).FirstOrDefault();

              //Check for availability
              
            if (client != null && contact != null)
              {
                var contactAssignment = _db.ContactAssignments.Where(x => x.ContactId == contact.Id && x.ClientId == client.Id).FirstOrDefault();
                if(contactAssignment != null)
                {
                    try
                    {
                        _db.ContactAssignments.Remove(contactAssignment);
                        _db.SaveChanges();

                        //count number of assigned clients
                        var clientAssignedCount = _db.ContactAssignments.Where(x => x.ClientId == client.Id).Count();
                        //update number of linked contacts
                        client.NumberOfLinkedContacts = clientAssignedCount;

                        //count number of assigned contacts
                        var contactAssignedCount = _db.ContactAssignments.Where(x => x.ContactId == contact.Id).Count();
                        //update the number of linked Clients
                        contact.NumberOfLinkedClients = contactAssignedCount;
                        //save the assignment counts
                        _db.SaveChanges();

                        return new ServiceResponse<ClientContactViewModel>()
                        {
                            IsSuccess = true,
                            Message = $"Succefully unlinked Contact ({clientContactViewModel.Contact.Email} to Client ({clientContactViewModel.Client.ClientCode})"
                        };
                    }
                 
                    catch
                    {
                         return new ServiceResponse<ClientContactViewModel>()
                         {
                            IsSuccess = false,
                            Message = $"Failed to unlinked Contact ({clientContactViewModel.Contact.Email} to Client ({clientContactViewModel.Client.ClientCode})"
                         };
                    }
                }
                return new ServiceResponse<ClientContactViewModel>()
                {
                    IsSuccess = false,
                    Message = "Falied To unlink Contact to Client for one or both are not found"
                };
            }
                   
              return new ServiceResponse<ClientContactViewModel>()
              {
                 IsSuccess = false,
                 Message = "Falied To link Contact to Client for one or both are not found"
              };  
        }
    }
}
