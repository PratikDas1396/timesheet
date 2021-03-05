using db.timesheet.com;

namespace repository.timesheet.com {
    public interface IProductRepository : IGenericRepository<Product> {
        Product GetProductByCode(string ProductCode);

        Product GetProductByName(string ProductName);
    }
}
