using BusinessObject;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{

    public class AccountRepository : IAccountRepository
    {
        public void DeleteAccount(Account Account) => AccountDAO.Insance.Remove(Account);

        public Account GetAccountByEmail(string email)
        => AccountDAO.Insance.GetAccountByEmail(email);

        public Account GetAccountByUserName(String UserNaame) => AccountDAO.Insance.GetAccountByUserName(UserNaame);


        public IEnumerable<Account> GetAccounts()
        => AccountDAO.Insance.GetAccountList();

        public void InsertAccount(Account Account)
        => AccountDAO.Insance.AddNew(Account);

        public Account Login(string Email, string Password)

        => AccountDAO.Insance.Login(Email, Password);


        public void UpdateAccount(Account Account)
        => AccountDAO.Insance.Update(Account);
    }
}
