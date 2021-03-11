using db.timesheet.com;
using System.Collections.Generic;

namespace repository.timesheet.com {
    public interface IDepartmentRepository : IGenericRepository<Department> {
        Department GetDepartmentByCode(string DepartmentCode);

        Department GetDepartmentByName(string DepartmentName);

        IList<DropdownKeyValue> GetDropdown();
    }
}
