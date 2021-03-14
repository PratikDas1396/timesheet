using db.timesheet.com;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace repository.timesheet.com {
    public class AccountRepository : GenericRepository<Account>, IAccountRepository {

        public AccountRepository(TimeSheetDBContext _context) : base(_context) {
        }

        public Account GetAccount(Guid ID) {
            return context.Account
                          .Where(x => x.ID == ID)
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
