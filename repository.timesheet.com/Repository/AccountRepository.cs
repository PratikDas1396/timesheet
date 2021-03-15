using db.timesheet.com;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace repository.timesheet.com {
    public class AccountRepository : GenericRepository<Account>, IAccountRepository {

        public AccountRepository(TimeSheetDBContext _context) : base(_context) {
        }

        public bool Authenticate(string UserID, string password) {
            return context.Account.Where(x => x.UserID == UserID && x.UserPin == password).Count() > 0;
        }

        public bool CheckUserCode(string UserID) {
            return context.Account.Where(x => x.UserID == UserID).Count() > 0;
        }

        public bool CheckUserEmail(string Email) {
            return context.Account.Where(x => x.Email == Email).Count() > 0;
        }

        public Account GetAccount(Guid ID) {
            return context.Account
                          .Where(x => x.ID == ID)
                          .Include(x => x.Department)
                          .Include(x => x.Designation)
                          .FirstOrDefault();
        }

        public Account GetAccountByUserID(string UserID) {
            return context.Account
                          .Where(x => x.UserID == UserID)
                          .Include(x => x.Department)
                          .Include(x => x.Designation)
                          .FirstOrDefault();
        }

        public Account GetAccount(string Email) {
            return context.Account
                          .Where(x => x.Email == Email)
                          .Include(x => x.Department)
                          .Include(x => x.Designation)
                          .FirstOrDefault();
        }

        public List<Account> GetAccounts() {
            return context.Account
                          .Include(x => x.Department)
                          .Include(x => x.Designation)
                          .ToList();
        }
    }
}
