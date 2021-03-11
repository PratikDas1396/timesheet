namespace db.timesheet.com.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerProductmapping : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 200),
                        UserEmail = c.String(nullable: false),
                        UserPin = c.String(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        CreatedDtim = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(),
                        UpdatedDtim = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        ActivityCode = c.String(nullable: false),
                        ActivityName = c.String(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        CreatedDtim = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(),
                        UpdatedDtim = c.DateTime(precision: 7, storeType: "datetime2"),
                        customerProductMapping_CustomerID = c.Guid(nullable: false),
                        customerProductMapping_ProductID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CustomerProductMappings", t => new { t.customerProductMapping_CustomerID, t.customerProductMapping_ProductID }, cascadeDelete: true)
                .Index(t => new { t.customerProductMapping_CustomerID, t.customerProductMapping_ProductID });
            
            CreateTable(
                "dbo.CustomerProductMappings",
                c => new
                    {
                        CustomerID = c.Guid(nullable: false),
                        ProductID = c.Guid(nullable: false),
                        ID = c.Guid(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        CreatedDtim = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(),
                        UpdatedDtim = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => new { t.CustomerID, t.ProductID })
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        RecId = c.Int(nullable: false, identity: true),
                        CustomerCode = c.String(nullable: false),
                        CustomerName = c.String(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        CreatedDtim = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(),
                        UpdatedDtim = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        RecId = c.Int(nullable: false, identity: true),
                        ProductCode = c.String(nullable: false),
                        ProductName = c.String(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        CreatedDtim = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(),
                        UpdatedDtim = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        DepartmentCode = c.String(nullable: false),
                        DepartmentName = c.String(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        CreatedDtim = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(),
                        UpdatedDtim = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        DesignationCode = c.String(nullable: false),
                        DesignationName = c.String(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        CreatedDtim = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(),
                        UpdatedDtim = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        RecId = c.Int(nullable: false, identity: true),
                        TaskCode = c.String(nullable: false),
                        TaskDescription = c.String(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        CreatedDtim = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(),
                        UpdatedDtim = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TimeSheets",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        TaskDescription = c.String(),
                        From = c.String(nullable: false),
                        To = c.String(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        CreatedDtim = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(),
                        UpdatedDtim = c.DateTime(precision: 7, storeType: "datetime2"),
                        ActivityCode_ID = c.Guid(nullable: false),
                        TaskCode_ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Activities", t => t.ActivityCode_ID, cascadeDelete: true)
                .ForeignKey("dbo.Tasks", t => t.TaskCode_ID, cascadeDelete: true)
                .Index(t => t.ActivityCode_ID)
                .Index(t => t.TaskCode_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TimeSheets", "TaskCode_ID", "dbo.Tasks");
            DropForeignKey("dbo.TimeSheets", "ActivityCode_ID", "dbo.Activities");
            DropForeignKey("dbo.Activities", new[] { "customerProductMapping_CustomerID", "customerProductMapping_ProductID" }, "dbo.CustomerProductMappings");
            DropForeignKey("dbo.CustomerProductMappings", "ProductID", "dbo.Products");
            DropForeignKey("dbo.CustomerProductMappings", "CustomerID", "dbo.Customers");
            DropIndex("dbo.TimeSheets", new[] { "TaskCode_ID" });
            DropIndex("dbo.TimeSheets", new[] { "ActivityCode_ID" });
            DropIndex("dbo.CustomerProductMappings", new[] { "ProductID" });
            DropIndex("dbo.CustomerProductMappings", new[] { "CustomerID" });
            DropIndex("dbo.Activities", new[] { "customerProductMapping_CustomerID", "customerProductMapping_ProductID" });
            DropTable("dbo.TimeSheets");
            DropTable("dbo.Tasks");
            DropTable("dbo.Designations");
            DropTable("dbo.Departments");
            DropTable("dbo.Products");
            DropTable("dbo.Customers");
            DropTable("dbo.CustomerProductMappings");
            DropTable("dbo.Activities");
            DropTable("dbo.Accounts");
        }
    }
}
