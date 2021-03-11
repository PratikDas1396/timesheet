
using db.timesheet.com;

namespace repository.timesheet.com{
    public interface ITaskRepository : IGenericRepository<Task> {

        Task GetTaskByCode(string TaskCode);

        Task GetTaskByDescription(string TaskDescription);
    }
}
