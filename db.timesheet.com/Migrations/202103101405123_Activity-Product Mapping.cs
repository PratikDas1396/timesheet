namespace db.timesheet.com.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActivityProductMapping : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Activities", new[] { "customerProductMapping_CustomerID", "customerProductMapping_ProductID" }, "dbo.CustomerProductMappings");
            DropIndex("dbo.Activities", new[] { "customerProductMapping_CustomerID", "customerProductMapping_ProductID" });
            AddColumn("dbo.Activities", "RecId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Activities", "CustomerProductMapping_CustomerID", c => c.Guid());
            AlterColumn("dbo.Activities", "CustomerProductMapping_ProductID", c => c.Guid());
            CreateIndex("dbo.Activities", new[] { "CustomerProductMapping_CustomerID", "CustomerProductMapping_ProductID" });
            AddForeignKey("dbo.Activities", new[] { "CustomerProductMapping_CustomerID", "CustomerProductMapping_ProductID" }, "dbo.CustomerProductMappings", new[] { "CustomerID", "ProductID" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activities", new[] { "CustomerProductMapping_CustomerID", "CustomerProductMapping_ProductID" }, "dbo.CustomerProductMappings");
            DropIndex("dbo.Activities", new[] { "CustomerProductMapping_CustomerID", "CustomerProductMapping_ProductID" });
            AlterColumn("dbo.Activities", "CustomerProductMapping_ProductID", c => c.Guid(nullable: false));
            AlterColumn("dbo.Activities", "CustomerProductMapping_CustomerID", c => c.Guid(nullable: false));
            DropColumn("dbo.Activities", "RecId");
            CreateIndex("dbo.Activities", new[] { "customerProductMapping_CustomerID", "customerProductMapping_ProductID" });
            AddForeignKey("dbo.Activities", new[] { "customerProductMapping_CustomerID", "customerProductMapping_ProductID" }, "dbo.CustomerProductMappings", new[] { "CustomerID", "ProductID" }, cascadeDelete: true);
        }
    }
}
