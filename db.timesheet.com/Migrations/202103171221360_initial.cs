namespace db.timesheet.com.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        DepartmentID = c.Guid(nullable: false),
                        DesignationID = c.Guid(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 200),
                        UserID = c.String(nullable: false, maxLength: 200),
                        Email = c.String(nullable: false),
                        UserPin = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        CreatedDtim = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(),
                        UpdatedDtim = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .ForeignKey("dbo.Designations", t => t.DesignationID, cascadeDelete: true)
                .Index(t => t.DepartmentID)
                .Index(t => t.DesignationID);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        RecId = c.Int(nullable: false, identity: true),
                        DepartmentCode = c.String(nullable: false),
                        DepartmentName = c.String(nullable: false),
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
                        RecId = c.Int(nullable: false, identity: true),
                        CustomerProductMappingID = c.Guid(nullable: false),
                        DepartmentID = c.Guid(nullable: false),
                        ActivityCode = c.String(nullable: false),
                        ActivityName = c.String(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        CreatedDtim = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(),
                        UpdatedDtim = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CustomerProductMappings", t => t.CustomerProductMappingID, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.CustomerProductMappingID)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.CustomerProductMappings",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        CustomerID = c.Guid(nullable: false),
                        ProductID = c.Guid(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        CreatedDtim = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(),
                        UpdatedDtim = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.ID)
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
                "dbo.Designations",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        RecId = c.Int(nullable: false, identity: true),
                        DesignationCode = c.String(nullable: false),
                        DesignationName = c.String(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        CreatedDtim = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(),
                        UpdatedDtim = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ErrorLogs",
                c => new
                    {
                        RecId = c.Int(nullable: false, identity: true),
                        ClassName = c.String(),
                        MethodName = c.String(),
                        ErrorDescription = c.String(),
                        StackTrace = c.String(),
                        CreatedBy = c.String(nullable: false),
                        CreatedDtim = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.RecId);
            
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
                        TaskDescription = c.String(nullable: false),
                        AccountID = c.Guid(nullable: false),
                        ActivityID = c.Guid(nullable: false),
                        TaskID = c.Guid(nullable: false),
                        FromTime = c.String(nullable: false),
                        ToTime = c.String(nullable: false),
                        TaskDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedBy = c.String(nullable: false),
                        CreatedDtim = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(),
                        UpdatedDtim = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Activities", t => t.ActivityID, cascadeDelete: true)
                .ForeignKey("dbo.Tasks", t => t.TaskID, cascadeDelete: true)
                .Index(t => t.ActivityID)
                .Index(t => t.TaskID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TimeSheets", "TaskID", "dbo.Tasks");
            DropForeignKey("dbo.TimeSheets", "ActivityID", "dbo.Activities");
            DropForeignKey("dbo.Accounts", "DesignationID", "dbo.Designations");
            DropForeignKey("dbo.Accounts", "DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.Activities", "DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.CustomerProductMappings", "ProductID", "dbo.Products");
            DropForeignKey("dbo.CustomerProductMappings", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Activities", "CustomerProductMappingID", "dbo.CustomerProductMappings");
            DropIndex("dbo.TimeSheets", new[] { "TaskID" });
            DropIndex("dbo.TimeSheets", new[] { "ActivityID" });
            DropIndex("dbo.CustomerProductMappings", new[] { "ProductID" });
            DropIndex("dbo.CustomerProductMappings", new[] { "CustomerID" });
            DropIndex("dbo.Activities", new[] { "DepartmentID" });
            DropIndex("dbo.Activities", new[] { "CustomerProductMappingID" });
            DropIndex("dbo.Accounts", new[] { "DesignationID" });
            DropIndex("dbo.Accounts", new[] { "DepartmentID" });
            DropTable("dbo.TimeSheets");
            DropTable("dbo.Tasks");
            DropTable("dbo.ErrorLogs");
            DropTable("dbo.Designations");
            DropTable("dbo.Products");
            DropTable("dbo.Customers");
            DropTable("dbo.CustomerProductMappings");
            DropTable("dbo.Activities");
            DropTable("dbo.Departments");
            DropTable("dbo.Accounts");
        }
    }
}
