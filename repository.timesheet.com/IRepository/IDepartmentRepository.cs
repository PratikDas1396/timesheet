using db.timesheet.com;

namespace repository.timesheet.com {
    public interface IDepartmentRepository : IGenericRepository<Department> {
        Department GetDepartmentByCode(string DepartmentCode);

        Department GetDepartmentByName(string DepartmentName);
    }
}
