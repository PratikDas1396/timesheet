using db.timesheet.com;

namespace repository.timesheet.com {
    public class UnitOfWork : IUnitOfWork {

        private readonly TimeSheetDBContext context;

        public ICustomerRepository Customers { get; private set; }
        public IProductRepository Products { get; private set; }
        public IDepartmentRepository Departments { get; private set; }
        public IDesignationRepository Designations { get; private set; }
        public ICustomerProductMappingRepository CustomerProductMapping { get; private set; }
        public ITaskRepository Tasks { get; private set; }
        public IActivityRepository Activity { get; private set; }
        public ITimeSheetRepository TimeSheet { get; private set; }
        public IAccountRepository Account { get; private set; }



        public UnitOfWork(TimeSheetDBContext _context) {
            // Setup the context
            context = _context;

            // Initailize Repositories
            Customers = new CustomerRepository(_context);
            Products = new ProductRepository(_context);
            Departments = new DepartmentRepository(_context);
            Designations = new DesignationRepository(_context);
            CustomerProductMapping = new CustomerProductMappingRepository(_context);
            Tasks = new TaskRepository(_context);
            Activity = new ActivityRepository(_context);
            TimeSheet = new TimeSheetRepository(_context);
            Account = new AccountRepository(_context);
        }

        public int Complete() {
            return context.SaveChanges();
        }

        public void Dispose() {
            context.Dispose();
        }
    }
}
