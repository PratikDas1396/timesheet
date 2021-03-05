namespace db.timesheet.com.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
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
                        customerProductMapping_ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CustomerProductMappings", t => t.customerProductMapping_ID, cascadeDelete: true)
                .Index(t => t.customerProductMapping_ID);
            
            CreateTable(
                "dbo.CustomerProductMappings",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        CreatedDtim = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(),
                        UpdatedDtim = c.DateTime(precision: 7, storeType: "datetime2"),
                        CustomerCode_ID = c.Guid(nullable: false),
                        ProductCode_ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.CustomerCode_ID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductCode_ID, cascadeDelete: true)
                .Index(t => t.CustomerCode_ID)
                .Index(t => t.ProductCode_ID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Guid(nullable: false),
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
            DropForeignKey("dbo.Activities", "customerProductMapping_ID", "dbo.CustomerProductMappings");
            DropForeignKey("dbo.CustomerProductMappings", "ProductCode_ID", "dbo.Products");
            DropForeignKey("dbo.CustomerProductMappings", "CustomerCode_ID", "dbo.Customers");
            DropIndex("dbo.TimeSheets", new[] { "TaskCode_ID" });
            DropIndex("dbo.TimeSheets", new[] { "ActivityCode_ID" });
            DropIndex("dbo.CustomerProductMappings", new[] { "ProductCode_ID" });
            DropIndex("dbo.CustomerProductMappings", new[] { "CustomerCode_ID" });
            DropIndex("dbo.Activities", new[] { "customerProductMapping_ID" });
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
