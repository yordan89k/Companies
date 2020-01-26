namespace CompaniesYK.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "Notes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Companies", "Notes");
        }
    }
}
