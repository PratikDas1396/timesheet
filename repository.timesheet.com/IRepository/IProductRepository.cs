using db.timesheet.com;
using System.Collections.Generic;

namespace repository.timesheet.com {
    public interface IProductRepository : IGenericRepository<Product> {
        Product GetProductByCode(string ProductCode);

        Product GetProductByName(string ProductName);

        IList<DropdownKeyValue> GetDropdown();
    }
}
