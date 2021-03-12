using db.timesheet.com;
using System;
using System.Collections.Generic;

namespace repository.timesheet.com {
    public interface IActivityRepository : IGenericRepository<Activity> {

        IList<Activity> GetActivities();

        Activity GetActivityByID(Guid ID);

        IList<DropdownKeyValue> GetDropdown();
    }
}
