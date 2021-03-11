namespace db.timesheet.com.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActivityProductMappingone : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Activities", new[] { "CustomerProductMapping_CustomerID", "CustomerProductMapping_ProductID" }, "dbo.CustomerProductMappings");
            DropIndex("dbo.Activities", new[] { "CustomerProductMapping_CustomerID", "CustomerProductMapping_ProductID" });
            RenameColumn(table: "dbo.Activities", name: "CustomerProductMapping_CustomerID", newName: "CustomerProductMappingID");
            DropPrimaryKey("dbo.CustomerProductMappings");
            AddColumn("dbo.Departments", "RecId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Designations", "RecId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Activities", "CustomerProductMappingID", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.CustomerProductMappings", "ID");
            CreateIndex("dbo.Activities", "CustomerProductMappingID");
            AddForeignKey("dbo.Activities", "CustomerProductMappingID", "dbo.CustomerProductMappings", "ID", cascadeDelete: true);
            DropColumn("dbo.Activities", "CustomerProductMapping_ProductID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Activities", "CustomerProductMapping_ProductID", c => c.Guid());
            DropForeignKey("dbo.Activities", "CustomerProductMappingID", "dbo.CustomerProductMappings");
            DropIndex("dbo.Activities", new[] { "CustomerProductMappingID" });
            DropPrimaryKey("dbo.CustomerProductMappings");
            AlterColumn("dbo.Activities", "CustomerProductMappingID", c => c.Guid());
            DropColumn("dbo.Designations", "RecId");
            DropColumn("dbo.Departments", "RecId");
            AddPrimaryKey("dbo.CustomerProductMappings", new[] { "CustomerID", "ProductID" });
            RenameColumn(table: "dbo.Activities", name: "CustomerProductMappingID", newName: "CustomerProductMapping_CustomerID");
            CreateIndex("dbo.Activities", new[] { "CustomerProductMapping_CustomerID", "CustomerProductMapping_ProductID" });
            AddForeignKey("dbo.Activities", new[] { "CustomerProductMapping_CustomerID", "CustomerProductMapping_ProductID" }, "dbo.CustomerProductMappings", new[] { "CustomerID", "ProductID" });
        }
    }
}
