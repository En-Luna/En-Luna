using En_Luna.Data.Models;

namespace En_Luna.Data.Services
{
    public interface IBankAccountService : IBaseService<BankAccount>
    {
        /// <summary>
        /// Verifies the specified bank account.
        /// </summary>
        /// <param name="bankAccount">The bank account.</param>
        /// <returns></returns>
        BankAccount Verify(BankAccount bankAccount);
    }
}
