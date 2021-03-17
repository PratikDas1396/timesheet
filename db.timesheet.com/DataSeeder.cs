using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db.timesheet.com {

    public class DataSeeder: DropCreateDatabaseAlways<TimeSheetDBContext> {

        protected override void Seed(TimeSheetDBContext context) {

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

            //context.Customer.Add(new Customer() {
            //    ID = CustomerID,
            //    CustomerCode = "RGIC",
            //    CustomerName = "Reliance General Health Insurance Pvt. Ltd.",
            //    CreatedBy = "System",
            //    CreatedDtim = DateTime.Now
            //});

            //context.Product.Add(new Product() {
            //    ID = ProductID,
            //    ProductCode = "TS",
            //    ProductName = "TimeSheet Application",
            //    CreatedBy = "System",
            //    CreatedDtim = DateTime.Now
            //});


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

            //context.SaveChanges();
            base.Seed(context);
        }
    }
}
