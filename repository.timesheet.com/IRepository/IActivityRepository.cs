using db.timesheet.com;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository.timesheet.com   {
   public interface IActivityRepository : IGenericRepository<Activity> {

        IList<Activity> GetActivities();

        Activity GetActivityByID(Guid ID);
    }
}
