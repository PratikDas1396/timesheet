using db.timesheet.com;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace repository.timesheet.com {
    public class ActivityRepository : GenericRepository<Activity>, IActivityRepository {

        public ActivityRepository(TimeSheetDBContext _context) : base(_context) {
        }


        public IList<Activity> GetActivities() {
            return context.Activity
                          .Include(x => x.Department)
                          .Include(y => y.CustomerProductMapping)
                          .Include(c => c.CustomerProductMapping.Customer)
                          .Include(c => c.CustomerProductMapping.Product)
                          .ToList();
        }

        public Activity GetActivityByID(Guid ID) {
            return context.Activity
                  .Where(x => x.ID == ID)
                  .Include(x => x.Department)
                  .Include(y => y.CustomerProductMapping)
                  .Include(c => c.CustomerProductMapping.Customer)
                  .Include(c => c.CustomerProductMapping.Product)
                  .SingleOrDefault();
        }

        public IList<DropdownKeyValue> GetDropdown() {
            return context.Activity
                          .Select(x => new DropdownKeyValue() {
                              ParamText = x.ActivityName,
                              ParamValue = x.ID.ToString()
                          }).ToList();
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
