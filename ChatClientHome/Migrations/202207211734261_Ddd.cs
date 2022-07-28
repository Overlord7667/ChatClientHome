namespace ChatClientHome.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ddd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChatUsers", "Online", c => c.Boolean(nullable: false));
            DropColumn("dbo.ChatUsers", "Onlone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ChatUsers", "Onlone", c => c.Boolean(nullable: false));
            DropColumn("dbo.ChatUsers", "Online");
        }
    }
}
