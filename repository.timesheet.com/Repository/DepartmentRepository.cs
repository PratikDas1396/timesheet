using db.timesheet.com;
using System.Linq;

namespace repository.timesheet.com {
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository  {
        public DepartmentRepository(TimeSheetDBContext _context) : base(_context) {
        }

        public Department GetDepartmentByCode(string DepartmentCode) {
            return context.Department.FirstOrDefault(x => x.DepartmentCode == DepartmentCode);
        }

        public Department GetDepartmentByName(string DepartmentName) {
            return context.Department.FirstOrDefault(x => x.DepartmentName == DepartmentName);
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
