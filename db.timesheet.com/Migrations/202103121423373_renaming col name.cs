namespace db.timesheet.com.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renamingcolname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "Email", c => c.String(nullable: false));
            DropColumn("dbo.Accounts", "UserEmail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accounts", "UserEmail", c => c.String(nullable: false));
            DropColumn("dbo.Accounts", "Email");
        }
    }
}
