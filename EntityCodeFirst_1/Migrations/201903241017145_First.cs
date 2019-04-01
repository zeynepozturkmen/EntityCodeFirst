namespace EntityCodeFirst_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(maxLength: 255),
                        Added_Date = c.DateTime(precision: 7, storeType: "datetime2"),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UnitPrice = c.Decimal(precision: 18, scale: 2),
                        UnitInStock = c.Short(),
                        QuantityPerUnit = c.String(maxLength: 30),
                        CategoryID = c.Int(nullable: false),
                        Added_Date = c.DateTime(precision: 7, storeType: "datetime2"),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Lastname = c.String(maxLength: 30),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Birth_Date = c.DateTime(),
                        Gender = c.Boolean(nullable: false),
                        Added_Date = c.DateTime(precision: 7, storeType: "datetime2"),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropTable("dbo.Users");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
