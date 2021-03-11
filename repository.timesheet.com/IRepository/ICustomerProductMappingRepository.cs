using db.timesheet.com;
using System;
using System.Collections.Generic;

namespace repository.timesheet.com {
    public interface ICustomerProductMappingRepository : IGenericRepository<CustomerProductMapping> {

        bool CheckCustomerMappingExists(Guid CustomerID, Guid ProductID);

        CustomerProductMapping GetCustomerProductMappingByID(Guid ID);

        IList<CustomerProductMapping> GetCustomerProductMapping();

        IList<DropdownKeyValue> GetDropdown();
    }
}
