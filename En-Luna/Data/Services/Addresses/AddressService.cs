using En_Luna.Data.Models;

namespace En_Luna.Data.Services
{
    /// <inheritdoc />
    public class AddressService : BaseService<Address>, IAddressService
    {
        public AddressService(ApplicationContext context) : base(context)
        {
        }
    }
}
