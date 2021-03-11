﻿namespace repository.timesheet.com {
    public interface IUnitOfWork {
        ICustomerRepository Customers { get; }
        IProductRepository Products { get; }
        IDepartmentRepository Departments { get; }
        IDesignationRepository Designations { get; }
        ICustomerProductMappingRepository CustomerProductMapping { get; }
        ITaskRepository Tasks { get; }
        IActivityRepository Activity { get; }

        int Complete();
    }
}
