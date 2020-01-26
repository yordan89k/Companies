namespace CompaniesYK.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stores", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Stores", new[] { "CompanyId" });
            DropPrimaryKey("dbo.Companies");
            DropPrimaryKey("dbo.Stores");
            AlterColumn("dbo.Companies", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Stores", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Stores", "CompanyId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Companies", "Id");
            AddPrimaryKey("dbo.Stores", "Id");
            CreateIndex("dbo.Stores", "CompanyId");
            AddForeignKey("dbo.Stores", "CompanyId", "dbo.Companies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stores", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Stores", new[] { "CompanyId" });
            DropPrimaryKey("dbo.Stores");
            DropPrimaryKey("dbo.Companies");
            AlterColumn("dbo.Stores", "CompanyId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Stores", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Companies", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Stores", "Id");
            AddPrimaryKey("dbo.Companies", "Id");
            CreateIndex("dbo.Stores", "CompanyId");
            AddForeignKey("dbo.Stores", "CompanyId", "dbo.Companies", "Id");
        }
    }
}
