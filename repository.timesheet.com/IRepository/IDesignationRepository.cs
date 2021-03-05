using db.timesheet.com;

namespace repository.timesheet.com {
    public interface IDesignationRepository : IGenericRepository<Designation> {

        Designation GetDesignationByCode(string DesignationCode);

        Designation GetDesignationByName(string DesignationName);
    }
}
