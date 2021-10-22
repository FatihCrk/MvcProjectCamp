namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_Added_Role : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 1),
                        Description = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Admins", "Role_Id", c => c.Int());
            CreateIndex("dbo.Admins", "Role_Id");
            AddForeignKey("dbo.Admins", "Role_Id", "dbo.Roles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Admins", "Role_Id", "dbo.Roles");
            DropIndex("dbo.Admins", new[] { "Role_Id" });
            DropColumn("dbo.Admins", "Role_Id");
            DropTable("dbo.Roles");
        }
    }
}
