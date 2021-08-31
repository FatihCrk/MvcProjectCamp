namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_update : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Drafts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Drafts",
                c => new
                    {
                        DraftID = c.Int(nullable: false, identity: true),
                        ReceiverMail = c.String(maxLength: 30),
                        Subject = c.String(maxLength: 50),
                        MessageContent = c.String(),
                        MessageDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DraftID);
            
        }
    }
}
