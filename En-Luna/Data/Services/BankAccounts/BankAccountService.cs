using En_Luna.Data.Models;

namespace En_Luna.Data.Services
{
    /// <inheritdoc />
    public class BankAccountService : BaseService<BankAccount>, IBankAccountService
    {
        public BankAccountService(ApplicationContext context) : base(context)
        {
        }

        /// <inheritdoc />
        public BankAccount Verify(BankAccount bankAccount)
        {
            bankAccount.IsVerified = true;
            _context.BankAccounts.Update(bankAccount);
            _context.SaveChanges();
            return bankAccount;
        }
    }
}
