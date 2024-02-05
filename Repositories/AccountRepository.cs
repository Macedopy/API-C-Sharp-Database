
using System.Data;
using System.Data.Common;
using System.IO.Compression;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PaymentAPI.Data;
using PaymentAPI.Models;
using PaymentAPI.Repositories.Interfaces;

namespace PaymentAPI.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly PaymentAPIContext DBContext;
        public AccountRepository(PaymentAPIContext paymentAPIContext)
        {
            DBContext = paymentAPIContext;
        }

        public async Task<AccountModel> ConsumeValue(AccountModel accountModel, int password, int number)
        {
            AccountModel account = await FindAccount(number);
            if(account.User.Password == password)
            {
                if(account == null){throw new Exception($"Account not found with number: {number}");}
                account.Value -= accountModel.Value;

                DBContext.Account.Update(account);
                await DBContext.SaveChangesAsync();

                return account;
            }else{throw new Exception($"Password is not correct");}

        }

        public async Task<AccountModel> FindAccount(int number)
        {
            return await DBContext.Account.FromSql($"SELECT * FROM Account WHERE Number ={number}").Include(a => a.User).SingleAsync();
        }

        public async Task<AccountModel> GenerateAccount(AccountModel accountModel)
        {
            UserModel lastId = await DBContext.Users.OrderBy(x=>x.Id).LastOrDefaultAsync();
            accountModel.UserId = lastId.Id;
            Random rnd = new Random();
            var number = rnd.Next(1000,9999);
            accountModel.Number = number;
            accountModel.Code = null;
            /// Anexar o accountId com o último Id colocado no banco users
            await DBContext.Account.AddAsync(accountModel);
            await DBContext.SaveChangesAsync();

            return accountModel;
        }

        public async Task<AccountModel> GeneratePayment(AccountModel accountModel, int password, int number, int value)
        {
            AccountModel account = await FindAccount(number);
            if(account.User.Password == password){

                Guid guid = Guid.NewGuid();
                guid.ToString();
                var convert = guid.ToString();
                account.Code = convert + $"value:{value}";
                DBContext.Update(account);
                await DBContext.SaveChangesAsync();
            return account;
            }else{throw new Exception($"Password is not correct");}
        }
        

        public async Task<AccountModel> InsertValue(AccountModel accountModel, int password, int number)
        {
            AccountModel account = await FindAccount(number);
            if(account.User.Password == password)
            {
                if(account == null){throw new Exception($"Account not found with number: {number}");}
                account.Value += accountModel.Value;

                DBContext.Account.Update(account);
                await DBContext.SaveChangesAsync();

                return account;
            }else{throw new Exception($"Password is not correct");}

        }

        public async Task<AccountModel> PayPayment(AccountModel accountModel, int number, int password, string code)
        {
            AccountModel accountSeller = await DBContext.Account.Where(a => a.Code == code).FirstOrDefaultAsync();
            AccountModel accountBuyer = await FindAccount(number);
            var transform = accountSeller.Code.ToString();
            var findPayment = transform.Split(':');
            var Payment = findPayment[1];
            int PaymentToInt = int.Parse(Payment);
            accountBuyer.Value -= PaymentToInt;
            accountSeller.Code = null;

            //aplicar o For para o Update, testa primeiro se funciona
            // DBContext.Account.Update(accountBuyer, accountSeller);
            DBContext.Account.Update(accountBuyer);
            DBContext.Account.Update(accountSeller);
            await DBContext.SaveChangesAsync();
            return accountBuyer;
            
        }
    }
}
