using db.timesheet.com;
using System.Collections.Generic;
using System.Linq;

namespace repository.timesheet.com {
    public class DesignationRepository : GenericRepository<Designation>, IDesignationRepository {
        public DesignationRepository(TimeSheetDBContext _context) : base(_context) {
        }

        public Designation GetDesignationByCode(string DesignationCode) {
            return context.Designation.FirstOrDefault(x => x.DesignationCode == DesignationCode);
        }

        public Designation GetDesignationByName(string DesignationName) {
            return context.Designation.FirstOrDefault(x => x.DesignationName == DesignationName);
        }

        public IList<DropdownKeyValue> GetDropdown() {
            return context.Designation
                          .Select(x => new DropdownKeyValue() {
                              ParamText = x.DesignationName,
                              ParamValue = x.ID.ToString()
                          }).ToList();
        }

        public TimeSheetDBContext dBContext { get { return context as TimeSheetDBContext; } }
    }
}
