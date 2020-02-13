namespace CompaniesYK.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StoreValidationFix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Stores", "Adress", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Stores", "City", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Stores", "Country", c => c.String(nullable: false, maxLength: 80));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stores", "Country", c => c.String(nullable: false));
            AlterColumn("dbo.Stores", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Stores", "Adress", c => c.String(nullable: false));
        }
    }
}
