using db.timesheet.com;
using System.Collections.Generic;
using System.Linq;

namespace repository.timesheet.com {

    public class ProductRepository : GenericRepository<Product>, IProductRepository {

        public ProductRepository(TimeSheetDBContext _context) : base(_context) {
        }

        public Product GetProductByCode(string ProductCode) {
            return context.Product.FirstOrDefault(x => x.ProductCode == ProductCode);
        }

        public Product GetProductByName(string ProductName) {
            return context.Product.FirstOrDefault(x => x.ProductName == ProductName);
        }

        public IList<DropdownKeyValue> GetDropdown() {
            return context.Product
                          .Select(x => new DropdownKeyValue() {
                              ParamText = x.ProductName,
                              ParamValue = x.ID.ToString()
                          }).ToList();
        }
    }
}
