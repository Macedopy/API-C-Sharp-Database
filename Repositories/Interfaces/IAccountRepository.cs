using PaymentAPI.Models;

namespace PaymentAPI.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<AccountModel> GenerateAccount(AccountModel accountModel);
        Task<AccountModel> FindAccount( int number);
        Task<AccountModel> InsertValue(AccountModel accountModel,  int password, int number);
        Task<AccountModel> ConsumeValue(AccountModel accountModel, int password, int number);
        Task<AccountModel> GeneratePayment(AccountModel accountModel, int password, int number, int value);
        Task<AccountModel> PayPayment(AccountModel accountModel, int number, int password, string code);
    }
}
