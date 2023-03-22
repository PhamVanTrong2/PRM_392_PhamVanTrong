using BusinessObject;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface  IAccountRepository

    {
        IEnumerable<Account> GetAccounts();
        Account GetAccountByUserName(String AccountId);

        Account GetAccountByEmail(String email);
        void InsertAccount(Account Account);
        void UpdateAccount(Account Account);
        void DeleteAccount(Account Account);

        Account Login(String Username, String Password);
    }
}
