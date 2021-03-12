using db.timesheet.com;
using System.Collections.Generic;

namespace repository.timesheet.com {
    public interface IDesignationRepository : IGenericRepository<Designation> {

        Designation GetDesignationByCode(string DesignationCode);

        Designation GetDesignationByName(string DesignationName);

        IList<DropdownKeyValue> GetDropdown();
    }
}
