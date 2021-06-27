namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_gender_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "Gender", c => c.String(maxLength: 1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "Gender");
        }
    }
}
