using db.timesheet.com;
using System;

namespace repository.timesheet.com {
    public class ExceptionRepository : GenericRepository<ErrorLog>, IExceptionRepository {

        public string ClassName { get; set; }

        public ExceptionRepository(TimeSheetDBContext _context) : base(_context) {
        }

        public ExceptionRepository(TimeSheetDBContext _context, string ClassName) : base(_context) {
            this.ClassName = ClassName;
        }

        public void Log(Exception ex, string ClassName, string MethodName, string UserID) {
            base.Add(new ErrorLog() {
                ClassName = ClassName,
                CreatedDtim = DateTime.Now,
                MethodName = MethodName,
                CreatedBy = UserID,
                ErrorDescription = $"{Convert.ToString(ex.Message) } - {Convert.ToString(ex.InnerException?.Message)}",
                StackTrace = ex.StackTrace
            });
        }

        public void Log(Exception ex, string MethodName, string UserID) {
            base.Add(new ErrorLog() {
                ClassName = this.ClassName,
                CreatedDtim = DateTime.Now,
                MethodName = MethodName,
                CreatedBy = UserID,
                ErrorDescription = $"{Convert.ToString(ex.Message) } - {Convert.ToString(ex.InnerException?.Message)}",
                StackTrace = ex.StackTrace
            });
        }
    }
}
