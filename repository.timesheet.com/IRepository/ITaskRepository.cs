
using db.timesheet.com;
using System.Collections.Generic;

namespace repository.timesheet.com{
    public interface ITaskRepository : IGenericRepository<Task> {

        Task GetTaskByCode(string TaskCode);

        Task GetTaskByDescription(string TaskDescription);

        IList<DropdownKeyValue> GetDropdown();
    }
}
