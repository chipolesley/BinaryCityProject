using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCityData.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "The surname is required")]
        public string Surname { get; set; } = null!;

        [Required(ErrorMessage = "The email address is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = null!;
        public int NumberOfLinkedClients { get; set; }

        public ContactAssignment? ContactAssignments { get; set; }
    }
}
