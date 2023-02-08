namespace BCityServices.Client
{
    public interface IClientService
    {
        public ServiceResponse<BCityData.Models.Client> AddClient(BCityData.Models.Client client);
        public ServiceResponse<List<BCityData.Models.Client>> GetClients();
    }
}
