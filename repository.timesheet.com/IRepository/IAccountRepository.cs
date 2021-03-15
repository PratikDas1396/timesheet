using db.timesheet.com;
using System;
using System.Collections.Generic;

namespace repository.timesheet.com {
    public interface IAccountRepository : IGenericRepository<Account> {
        List<Account> GetAccounts();

        Account GetAccount(Guid ID);

        Account GetAccount(string Email);

        bool CheckUserEmail(string Email);

        bool CheckUserCode(string UserID);

        bool Authenticate(string UserID, string password);
    }
}
