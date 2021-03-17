using System;
using System.Data.Entity;

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
        public DbSet<ErrorLog> ErrorLog { get; set; }

        public TimeSheetDBContext(): base("TimeSheetDB") {
            //Database.SetInitializer(new DataSeeder());
        }
      
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
        }
    }
}
