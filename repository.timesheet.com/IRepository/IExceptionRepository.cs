using db.timesheet.com;
using System;

namespace repository.timesheet.com {
    public interface IExceptionRepository : IGenericRepository<ErrorLog> {
        void Log(Exception ex, string ClassName, string UserID);
        void Log(Exception ex, string ClassName, string MethodName, string UserID);
    }
}
