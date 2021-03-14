using db.timesheet.com;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace repository.timesheet.com {
    public class TimeSheetRepository : GenericRepository<TimeSheet>, ITimeSheetRepository {

        public TimeSheetRepository(TimeSheetDBContext _context) : base(_context) {
        }

        public IList<TimeSheet> GetTimeSheets() {
            throw new NotImplementedException();
        }

        public IList<TimeSheet> GetTimeSheets(Guid EmployeeID, DateTime date) {
            throw new NotImplementedException();
        }

        public IList<TimeSheet> GetTimeSheets(Guid EmployeeID, DateTime Fromdate, DateTime ToTime) {
            throw new NotImplementedException();
        }

        public TimeSheetDBContext dBContext { get { return context as TimeSheetDBContext; } }
    }
}
