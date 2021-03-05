using db.timesheet.com;

namespace repository.timesheet.com {
    public interface ICustomerRepository : IGenericRepository<Customer> {

        Customer GetCustomerByCode(string CustomerCode);

        Customer GetCustomerByName(string CustomerName);
    }
}
