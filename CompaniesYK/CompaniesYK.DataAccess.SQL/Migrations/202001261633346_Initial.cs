namespace CompaniesYK.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 225),
                        OrganizationNumber = c.Int(nullable: false),
                        Logo = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        OwnerCompany = c.String(),
                        CompanyId = c.String(maxLength: 128),
                        Name = c.String(maxLength: 100),
                        Adress = c.String(),
                        City = c.String(),
                        Zip = c.String(),
                        Country = c.String(),
                        Longitude = c.String(),
                        Latitude = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stores", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Stores", new[] { "CompanyId" });
            DropTable("dbo.Stores");
            DropTable("dbo.Companies");
        }
    }
}
