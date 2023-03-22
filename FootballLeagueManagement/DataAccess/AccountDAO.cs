using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    //internal class AccountDAO
    //{
    //}
    internal class AccountDAO
    {
        private static AccountDAO instance = null;
        private static readonly object instanceLock = new object();
        private AccountDAO() { }
        public static AccountDAO Insance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AccountDAO();
                    }
                }
                return instance;
            }
        }


        public IEnumerable<Account> GetAccountList()
        {
            List<Account> Accounts;
            try
            {
                var myStockDB = new NhaappContext();
                Accounts = myStockDB.Accounts.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Accounts;
        }

        public Account GetAccountByUserName(String UserName)
        {
            Account Account = null;
            try
            {
                var myStockDB = new NhaappContext();
                Account = myStockDB.Accounts.SingleOrDefault(Account => Account.Username == UserName);

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            return Account;
        }

        public Account GetAccountByEmail(String email)
        {
            Account Account = null;
            try
            {
                var myStockDB = new NhaappContext();
                Account = myStockDB.Accounts.SingleOrDefault(Account => Account.Email == email);

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            return Account;
        }

        public void AddNew(Account Account)
        {
            try
            {
                Account _Account = GetAccountByUserName(Account.Username);
                if (_Account == null)
                {
                    var myStockDb = new NhaappContext();
                    myStockDb.Accounts.Add(Account);
                    myStockDb.SaveChanges();
                }
                else
                { throw new Exception("The Account is already exist"); }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void Update(Account Account)
        {
            try
            {
                Account c = GetAccountByUserName(Account.Username);
                if (c != null)
                {
                    var myStockDb = new NhaappContext();
                    myStockDb.Entry<Account>(Account).State = EntityState.Modified;
                    myStockDb.SaveChanges();
                }
                else
                { throw new Exception("The Account does not already exist"); }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(Account Account)
        {
            try
            {
                Account c = GetAccountByUserName(Account.Username);
                if (c != null)
                {
                    var myStockDb = new NhaappContext();
                    myStockDb.Accounts.Remove(Account);
                    myStockDb.SaveChanges();
                }
                else
                { throw new Exception("The Account does not already exist"); }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Account Login(String eamil, String password)
        {
            Account Account = null;
            try
            {
                var myStockDB = new NhaappContext();
                Account = myStockDB.Accounts.SingleOrDefault(Account => Account.Username == eamil && Account.Password == password);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            return Account;
        }
    }
}
