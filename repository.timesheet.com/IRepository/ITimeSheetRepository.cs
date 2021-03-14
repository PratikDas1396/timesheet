using db.timesheet.com;
using System;
using System.Collections.Generic;

namespace repository.timesheet.com {
    public interface ITimeSheetRepository : IGenericRepository<TimeSheet> {

        IList<TimeSheet> GetTimeSheets();

        IList<TimeSheet> GetTimeSheets(Guid EmployeeID, DateTime date);

        IList<TimeSheet> GetTimeSheets(Guid EmployeeID, DateTime Fromdate, DateTime ToTime);


    }
}
