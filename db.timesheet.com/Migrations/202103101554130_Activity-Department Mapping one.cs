namespace db.timesheet.com.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActivityDepartmentMappingone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activities", "DepartmentID", c => c.Guid(nullable: false));
            CreateIndex("dbo.Activities", "DepartmentID");
            AddForeignKey("dbo.Activities", "DepartmentID", "dbo.Departments", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activities", "DepartmentID", "dbo.Departments");
            DropIndex("dbo.Activities", new[] { "DepartmentID" });
            DropColumn("dbo.Activities", "DepartmentID");
        }
    }
}
