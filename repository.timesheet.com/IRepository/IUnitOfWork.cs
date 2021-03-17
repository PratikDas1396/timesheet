namespace repository.timesheet.com {
    public interface IUnitOfWork {
        ICustomerRepository Customers { get; }
        IProductRepository Products { get; }
        IDepartmentRepository Departments { get; }
        IDesignationRepository Designations { get; }
        ICustomerProductMappingRepository CustomerProductMapping { get; }
        ITaskRepository Tasks { get; }
        IActivityRepository Activity { get; }
        ITimeSheetRepository TimeSheet { get; }
        IAccountRepository Account { get; }
        IExceptionRepository Exception { get; }

        int Complete();
    }
}
