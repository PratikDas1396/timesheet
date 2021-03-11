using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace db.timesheet.com {
    public class TimeSheetDBContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Designation> Designation { get; set; }
        public DbSet<CustomerProductMapping> CustomerProductMapping { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TimeSheet> TimeSheet { get; set; }
        public DbSet<Activity> Activity { get; set; }
        public DbSet<Account> Account { get; set; }

        public TimeSheetDBContext(): base("TimeSheetDb") {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {

            //Initialization Stratergy
            //Database.SetInitializer<TimeSheetDBContext>(new DropCreateDatabaseIfModelChanges<TimeSheetDBContext>());
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));

            //modelBuilder.Entity<Customer>().Property(e => e.ID).HasColumnName("CustomerID");
            //modelBuilder.Entity<Product>().Property(e => e.ID).HasColumnName("ProductID");

            //modelBuilder.Entity<Customer>().HasMany(c => c.Product)
            //                               .WithMany(c => c.Customer)
            //                               .Map(ep => {
            //                                   ep.MapLeftKey("Customer");
            //                                   ep.MapRightKey("Product");
            //                                   ep.ToTable("CustomerProductMappings");
            //                               });
        }
    }
}
