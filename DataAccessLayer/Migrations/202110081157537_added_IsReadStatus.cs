﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_IsReadStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "IsReadStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "IsReadStatus");
        }
    }
}
