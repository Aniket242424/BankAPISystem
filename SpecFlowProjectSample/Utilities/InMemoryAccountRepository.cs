using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;
using SpecflowAssesment.Models;

namespace SpecflowAssesment.Utilities
{
    

    public class InMemoryAccountRepository
    {
        private readonly Dictionary<string, AccountModel> accounts;

        public InMemoryAccountRepository()
        {
            accounts = new Dictionary<string, AccountModel>();
        }

        public bool TryGetAccount(string accountNumber, out AccountModel account)
        {
            if (accounts.TryGetValue(accountNumber, out account))
            {
                return true; // Account found
            }

            return false; // Account not found
        }

        public void AddAccount(AccountModel account)
        {
            if (!accounts.ContainsKey(account.AccountNumber))
            {
                accounts.Add(account.AccountNumber, account);
            }
        }

        public void DeleteAccount(AccountModel account)
        {

            if (accounts.ContainsKey(account.AccountNumber))
            {
                accounts.Remove(account.AccountNumber);
            }
        }

        public void UpdateAccount(AccountModel updatedAccount)
        {
            if (accounts.ContainsKey(updatedAccount.AccountNumber))
            {
                accounts[updatedAccount.AccountNumber] = updatedAccount;
            }
        }

    }

}
