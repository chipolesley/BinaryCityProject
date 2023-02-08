using BCityServices.ClientContactAssignment;
using Microsoft.AspNetCore.Mvc;

namespace BCityWeb.Controllers
{
    [ApiController]
    public class ClientContactAssignmentController : ControllerBase
    {
        private readonly IClientContactAssService _IClientContactAssService;
        public ClientContactAssignmentController(IClientContactAssService IClientContactAssService)
        {
            _IClientContactAssService = IClientContactAssService;
        }
        /// <summary>
        /// Add Contact Assignment
        /// </summary>
        /// <param name="clientContactView"></param>
        /// <returns></returns>
        [HttpPost("api/contactassignment")]
        public IActionResult AddContactAssignment(BCityData.Models.ViewModel.ClientContactViewModel clientContactView)
        {
            var contactAssign = _IClientContactAssService.AddClientContactAssignment(clientContactView);
            return Ok(contactAssign);
        }
        /// <summary>
        /// Delete Contact Assignment
        /// </summary>
        /// <param name="clientContactView"></param>
        /// <returns></returns>
        [HttpDelete("api/contactassignment")]
        public IActionResult DeleteContactAssignment(BCityData.Models.ViewModel.ClientContactViewModel clientContactView)
        {
            var unlinkContact = _IClientContactAssService.DeleteClientContactAssignment(clientContactView);

            return Ok(unlinkContact);
        }

    }
}
