using db.timesheet.com;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace repository.timesheet.com {
    public class TimeSheetRepository : GenericRepository<TimeSheet>, ITimeSheetRepository {

        public TimeSheetRepository(TimeSheetDBContext _context) : base(_context) {
        }

        public override bool Equals(object obj) {
            return base.Equals(obj);
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public override string ToString() {
            return base.ToString();
        }

        public TimeSheetDBContext dBContext { get { return context as TimeSheetDBContext; } }
    }
}
