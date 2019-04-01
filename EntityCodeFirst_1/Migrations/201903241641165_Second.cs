namespace EntityCodeFirst_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Gender", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Gender", c => c.Boolean(nullable: false));
        }
    }
}
