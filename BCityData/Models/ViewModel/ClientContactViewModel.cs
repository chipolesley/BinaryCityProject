using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCityData.Models.ViewModel
{
    public class ClientContactViewModel
    {
        public Contact Contact { get; set; } = null!;
        public Client Client { get; set; } = null!;
    }
}
