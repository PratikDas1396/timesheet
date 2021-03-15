namespace db.timesheet.com.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeduseridcolumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "UserID", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "UserID");
        }
    }
}
