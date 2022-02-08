namespace Business_address.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration_Created : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(nullable: false),
                        Sector = c.String(nullable: false),
                        HouseNumber = c.String(),
                        Reference = c.String(),
                        City = c.String(),
                        Client_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "dbo.Businesses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        RNC = c.String(nullable: false, maxLength: 9),
                        Telefono = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Surname = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(maxLength: 10),
                        Born = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        BusinessID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Businesses", t => t.BusinessID, cascadeDelete: true)
                .Index(t => t.BusinessID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "BusinessID", "dbo.Businesses");
            DropForeignKey("dbo.Addresses", "Client_Id", "dbo.Clients");
            DropIndex("dbo.Clients", new[] { "BusinessID" });
            DropIndex("dbo.Addresses", new[] { "Client_Id" });
            DropTable("dbo.Clients");
            DropTable("dbo.Businesses");
            DropTable("dbo.Addresses");
        }
    }
}
