using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BCityData.Models
{
    public class Client
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "The name is required")]
        public string Name { get; set; } = null!;
        public string? ClientCode { get; set; }
        public int NumberOfLinkedContacts { get; set; }

        public ContactAssignment? ContactAssignments { get; set; }
    }
}
