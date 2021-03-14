using System;
using db.timesheet.com;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace repository.timesheet.com {
    public class CustomerProductMappingRepository : GenericRepository<CustomerProductMapping>, ICustomerProductMappingRepository {
        public CustomerProductMappingRepository(TimeSheetDBContext _context) : base(_context) {
        }

        public bool CheckCustomerMappingExists(Guid CustomerID, Guid ProductID) {
            var isAvail = context.CustomerProductMapping.Where(x => x.Customer.ID == CustomerID && x.Product.ID == ProductID).FirstOrDefault();
            return isAvail != null;
        }

        public IList<CustomerProductMapping> GetCustomerProductMapping() {
            return context.CustomerProductMapping.Include(x => x.Customer).Include(y => y.Product).ToList();
        }

        public CustomerProductMapping GetCustomerProductMappingByID(Guid ID) {
            return context.CustomerProductMapping.Where(x => x.ID == ID).Include(x => x.Customer).Include(y => y.Product).SingleOrDefault();
        }

        public IList<DropdownKeyValue> GetDropdown() {
            List<DropdownKeyValue> dropdown = new List<DropdownKeyValue>();

            dropdown = context.CustomerProductMapping
                              .Include(x => x.Customer)
                              .Include(y => y.Product)
                              .AsEnumerable()
                              .Select(x => new DropdownKeyValue() {
                                  ParamText = String.Format("{0} - {1}", x.Customer.CustomerName, x.Product.ProductName),
                                  ParamValue = x.ID.ToString()
                              }).ToList();

            return dropdown;
        }

        public TimeSheetDBContext dBContext { get { return context as TimeSheetDBContext; } }
    }
}
