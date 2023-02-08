using System;
using System.Collections.Generic;
using System.Linq;
namespace BCityData.Models
{
    public class ContactAssignment
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ContactId { get; set; }

        public ICollection<Client> Clients { get; set; }
        public ICollection<Contact> Contacts { get; set; }
    }
}
