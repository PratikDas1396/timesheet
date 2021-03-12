using db.timesheet.com;
using System.Collections.Generic;

namespace repository.timesheet.com {
    public interface ICustomerRepository : IGenericRepository<Customer> {

        Customer GetCustomerByCode(string CustomerCode);

        Customer GetCustomerByName(string CustomerName);
        
        IList<DropdownKeyValue> GetDropdown();
    }
}
