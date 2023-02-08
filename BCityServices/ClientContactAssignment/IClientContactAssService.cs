using BCityData.Models.ViewModel;

namespace BCityServices.ClientContactAssignment
{
    public interface IClientContactAssService
    {
        public ServiceResponse<ClientContactViewModel> AddClientContactAssignment(ClientContactViewModel clientContactViewModel);
        public ServiceResponse<ClientContactViewModel> DeleteClientContactAssignment(ClientContactViewModel clientContactViewModel);
    }
}
