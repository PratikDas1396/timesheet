namespace db.timesheet.com.Migrations {
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<db.timesheet.com.TimeSheetDBContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(db.timesheet.com.TimeSheetDBContext context) {
            var DepartmentID = Guid.NewGuid();
            var DesignationID = Guid.NewGuid();

            var CustomerID = Guid.NewGuid();
            var ProductID = Guid.NewGuid();

            context.Department.Add(new Department() {
                ID = DepartmentID,
                DepartmentCode = "D1001",
                DepartmentName = "Admin",
                CreatedBy = "System",
                CreatedDtim = DateTime.Now
            });

            context.Designation.Add(new Designation() {
                ID = DesignationID,
                DesignationCode = "DG1001",
                DesignationName = "System Admininstrator",
                CreatedBy = "System",
                CreatedDtim = DateTime.Now
            });

            context.Account.Add(new Account() {
                ID = Guid.NewGuid(),
                UserID = "admin",
                UserName = "Administrator",
                DepartmentID = DepartmentID,
                DesignationID = DesignationID,
                Email = "admin@company.com",
                IsActive = true,
                UserPin = "1GrLjxtnjhTciNRrzGNeR02GK2ezUCjt6WC3fsV9ctg=",
                CreatedBy = "System",
                CreatedDtim = DateTime.Now
            });

        }
    }
}
