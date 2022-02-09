namespace Business_address.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClientToAddressRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "Client_Id", "dbo.Clients");
            DropIndex("dbo.Addresses", new[] { "Client_Id" });
            RenameColumn(table: "dbo.Addresses", name: "Client_Id", newName: "ClientID");
            AlterColumn("dbo.Addresses", "ClientID", c => c.Int(nullable: false));
            CreateIndex("dbo.Addresses", "ClientID");
            AddForeignKey("dbo.Addresses", "ClientID", "dbo.Clients", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "ClientID", "dbo.Clients");
            DropIndex("dbo.Addresses", new[] { "ClientID" });
            AlterColumn("dbo.Addresses", "ClientID", c => c.Int());
            RenameColumn(table: "dbo.Addresses", name: "ClientID", newName: "Client_Id");
            CreateIndex("dbo.Addresses", "Client_Id");
            AddForeignKey("dbo.Addresses", "Client_Id", "dbo.Clients", "Id");
        }
    }
}
