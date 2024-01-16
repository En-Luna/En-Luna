using En_Luna.Data.Models;

namespace En_Luna.Data.Services
{
    /// <inheritdoc />
    public class LicenseService : BaseService<License>, ILicenseService
    {
        public LicenseService(ApplicationContext context) : base(context)
        {
        }

        public License Verify(License license)
        {
            license.IsVerified = true;
            _context.Licenses.Update(license);
            _context.SaveChanges();
            return license;
        }
    }
}
