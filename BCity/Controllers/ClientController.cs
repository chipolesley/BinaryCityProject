using BCityServices.Client;
using Microsoft.AspNetCore.Mvc;

namespace BCityWeb.Controllers
{
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _IClientService;
        public ClientController(IClientService IClientService)
        {
            _IClientService = IClientService;
        }

        /// <summary>
        /// Get all Clients
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/clients")]
        public IActionResult GetClients()
        {
            var clients = _IClientService.GetClients();
            return Ok(clients);
        }
        /// <summary>
        /// Add a Client
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        [HttpPost("api/client")]
        public IActionResult AddClients(BCityData.Models.Client client)
        {
            var clients = _IClientService.AddClient(client);
            return Ok(clients);
        }
    }
}
