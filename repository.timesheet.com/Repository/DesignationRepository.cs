using db.timesheet.com;
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
