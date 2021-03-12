using db.timesheet.com;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace repository.timesheet.com {
    public class TaskRepository : GenericRepository<Task>, ITaskRepository {

        public TaskRepository(TimeSheetDBContext _context) : base(_context) {
        }

        public Task GetTaskByCode(string TaskCode) {
            return context.Tasks.FirstOrDefault(x => x.TaskCode == TaskCode);
        }

        public Task GetTaskByDescription(string TaskDescription) {
            return context.Tasks.FirstOrDefault(x => x.TaskDescription == TaskDescription);
        }

        public IList<DropdownKeyValue> GetDropdown() {
            return context.Tasks
                          .Select(x => new DropdownKeyValue() {
                              ParamText = x.TaskDescription,
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
