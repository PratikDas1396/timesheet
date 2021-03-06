using db.timesheet.com;
using System.Collections.Generic;
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

        public IList<DropdownKeyValue> GetDropdown() {
            return context.Department 
                          .Select(x => new DropdownKeyValue() {
                              ParamText = x.DepartmentName,
                              ParamValue = x.ID.ToString()
                          }).ToList();
        }

        public TimeSheetDBContext dBContext { get { return context as TimeSheetDBContext; } }
    }
}
