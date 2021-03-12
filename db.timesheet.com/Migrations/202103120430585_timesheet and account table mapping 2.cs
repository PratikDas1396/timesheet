namespace db.timesheet.com.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class timesheetandaccounttablemapping2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TimeSheets", "AccountID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TimeSheets", "AccountID");
        }
    }
}
